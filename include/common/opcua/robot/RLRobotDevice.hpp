//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_RLROBOTDEVICE_HPP
#define ROBOTICS_RLROBOTDEVICE_HPP

#include <chrono>
#include <thread>
#include <rl/util/thread.h>
#include <rl/hal/CyclicDevice.h>
#include <rl/hal/Exception.h>
#include <common/opcua/robot/impl/RLSkillImpl.hpp>

namespace fortiss {
    namespace opcua {
        namespace robot {
            class RlRobotDevice {

            private:

                ::std::vector<::std::function<void(const bool &)>> connectedCallbacks;

                ::rl::hal::CyclicDevice *device;
                std::shared_ptr<rl::mdl::Dynamic> kinematic;
                std::mutex* stepMutex;

                bool running;

                bool isCurrentlyRunning = false;

                ::std::vector<::std::function<void(const bool &)>> runningCallbacks;

                ::std::vector<RLSkillImpl*> skills;

            public:
                explicit RlRobotDevice(::rl::hal::CyclicDevice *_device, std::shared_ptr<rl::mdl::Dynamic> _kinematic,
                        std::mutex* _stepMutex) :
                        connectedCallbacks(),
                        device(_device),
                        kinematic(_kinematic),
                        stepMutex(_stepMutex),
                        running(false),
                        runningCallbacks(),
                        skills() {
                }

                virtual ~RlRobotDevice() {
                    stop(true);
                };

                void addConnectedCallback(const ::std::function<void(const bool &)> &callback) {
                    this->connectedCallbacks.push_back(callback);
                }

                void addRunningCallback(const ::std::function<void(const bool &)> &callback) {
                    this->runningCallbacks.push_back(callback);
                }

                void addSkill(RLSkillImpl* skill) {
                    this->skills.push_back(skill);
                }

                void clearConnectedCallbacks()
                {
                    this->connectedCallbacks.clear();
                }

                void clearRunningCallbacks()
                {
                    this->runningCallbacks.clear();
                }

                ::rl::hal::CyclicDevice *getDevice() const {
                    return device;
                }

                void run()
                {
                    ::rl::util::this_thread::set_priority(::rl::util::this_thread::get_priority_max());

                    isCurrentlyRunning = true;
                    this->running = true;

                    try {
                        this->device->open();

                        for (::std::size_t i = 0; i < this->connectedCallbacks.size(); ++i) {
                            this->connectedCallbacks[i](true);
                        }

                        ::std::chrono::steady_clock::time_point time = ::std::chrono::steady_clock::now();
                        ::std::chrono::steady_clock::duration updateRate = ::std::chrono::duration_cast<::std::chrono::steady_clock::duration>(
                                this->device->getUpdateRate());

                        do {
                            time += updateRate;
                            ::std::this_thread::sleep_until(time);
                            this->device->start();
                        } while (!this->device->isRunning() && this->running);
                        if (!this->running) {
                            isCurrentlyRunning = false;
                            return;
                        }
                        // reset time to now, since start may take longer than updateRate
                        auto remainingMs = std::chrono::duration_cast<std::chrono::milliseconds>(
                                time - ::std::chrono::steady_clock::now());
                        if (remainingMs.count() < 0) {
                            time = ::std::chrono::steady_clock::now();
                        }

                        for (::std::size_t i = 0; i < this->runningCallbacks.size(); ++i) {
                            this->runningCallbacks[i](true);
                        }

                        while (this->running) {
                            this->step();
                            time += updateRate;
                            for (::std::size_t i = 0; i < this->skills.size(); ++i) {
                                // pass another instance of the kinematic to be thread safe
                                if (this->skills[i]->isActive())
                                    skills[i]->step(kinematic.get());
                            }
                            ::std::this_thread::sleep_until(time);

                        }

                        do {
                            time += updateRate;
                            ::std::this_thread::sleep_until(time);
                            this->device->stop();
                        } while (this->device->isRunning() && this->running);
                        if (!this->running) {
                            isCurrentlyRunning = false;
                            return;
                        }

                        for (::std::size_t i = 0; i < this->runningCallbacks.size(); ++i) {
                            this->runningCallbacks[i](false);
                        }

                        this->device->close();

                        for (::std::size_t i = 0; i < this->connectedCallbacks.size(); ++i) {
                            this->connectedCallbacks[i](false);
                        }
                        isCurrentlyRunning = false;
                    }
                    catch (rl::hal::Exception& ex) {
                        isCurrentlyRunning = false;
                        throw ex;
                    }

                }

                void stop(bool wait, bool forceClose = true)
                {
                    this->running = false;
                    if (wait) {
                        std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();

                        while(isCurrentlyRunning && (!forceClose || (forceClose && (std::chrono::duration_cast<std::chrono::seconds>(std::chrono::steady_clock::now() - begin).count() < 2)))) {
                            std::this_thread::yield();
                            std::this_thread::sleep_for(std::chrono::microseconds(1));
                        }

                        if (isCurrentlyRunning && forceClose) {
                            this->device->close();
                        }
                        while(isCurrentlyRunning) {
                            std::this_thread::yield();
                            std::this_thread::sleep_for(std::chrono::microseconds(1));
                        }
                    }
                }

            protected:
                virtual void step()
                {
                    stepMutex->lock();
                    this->device->step();
                    stepMutex->unlock();
                }

            };
        }
    }
}

#endif //ROBOTICS_RLROBOTDEVICE_HPP
