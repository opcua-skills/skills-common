//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_ROBOT_SKILLS_JOINTPTPMOVEIMPL_HPP
#define ROBOTICS_ROBOT_SKILLS_JOINTPTPMOVEIMPL_HPP

#include "common/opcua/skill/robot/JointPtpMoveSkill.hpp"
#include "common/opcua/robot/PtpInterpolator.hpp"
#include "RLSkillImpl.hpp"

namespace fortiss {
    namespace opcua {
        namespace robot {

            template<int AXIS_COUNT>
            class JointPtpMoveImpl : virtual public fortiss::opcua::skill::robot::JointPtpMoveSkillImpl<AXIS_COUNT>,
                                     virtual public RLSkillImpl {

            private:

                PtpInterpolator *interpolator = nullptr;
                rl::math::Vector targetJointPosition;
                std::function<void(const rl::math::Vector &)> setJointPosition;
                ::std::chrono::nanoseconds updateRate;
                bool active = false;

                std::chrono::steady_clock::time_point skillStartTime;
                size_t stepsExecuted = 0;

                // The interpolator is deleted during the halt method so make sure it cannot be called
                // at the same time as step
                std::mutex stepMutex;

            public:
                explicit JointPtpMoveImpl(const std::shared_ptr<spdlog::logger> &logger,
                                          const std::function<const rl::math::Vector()>& getJointPosition,
                                          const std::function<void(const rl::math::Vector& pos)>& setJointPosition,
                                          ::std::chrono::nanoseconds updateRate,
                                          const std::shared_ptr<rl::mdl::Dynamic> &kinematic) :
                        RLSkillImpl(logger, getJointPosition, kinematic),
                        interpolator(),
                        setJointPosition(setJointPosition),
                        updateRate(updateRate),
                        skillStartTime() {
                    if (kinematic->getDof() != AXIS_COUNT)
                        throw std::runtime_error("AXIS_COUNT does not match DOF");

                }

                virtual ~JointPtpMoveImpl() {
                    if (interpolator)
                        delete interpolator;
                }

            protected:

                bool start(const std::array<double, AXIS_COUNT> &targetJointPositionArr,
                           const std::string &toolFrame,
                           const std::array<double, AXIS_COUNT> &maxVelocity,
                           const std::array<double, AXIS_COUNT> &maxAcceleration) override {

                    if (interpolator != nullptr) {
                        logger->error("Interpolator is already initialized. This can not be...");
                        return false;
                    }

                    targetJointPosition = rl::math::Vector::Zero(AXIS_COUNT);
                    for (unsigned int i = 0; i < AXIS_COUNT; i++)
                        targetJointPosition[i] = targetJointPositionArr[i];

                    std::stringstream ss;
                    ss << "Moving (Joint PTP): ";
                    for (unsigned int i = 0; i < AXIS_COUNT; i++) {
                        ss << " ";
                        ss << targetJointPosition[i] * RAD_TO_DEG;
                    }
                    logger->info(ss.str());

                    rl::math::Vector maxVelo = this->kinematic->getSpeed();
                    rl::math::Vector maxAccel = rl::math::Vector::Constant(kinematic->getDofPosition(),
                                                                           100 * rl::math::DEG2RAD);

                    if (*std::max_element(maxVelocity.begin(), maxVelocity.end()) > 0) {
                        for (size_t i = 0; i < AXIS_COUNT; i++) {
                            maxVelo[i] = maxVelocity[i];
                        }
                    }
                    if (*std::max_element(maxAcceleration.begin(), maxAcceleration.end()) > 0) {
                        for (size_t i = 0; i < AXIS_COUNT; i++) {
                            maxAccel[i] = maxAcceleration[i];
                        }
                    }

                    interpolator = new PtpInterpolator(kinematic, getJointPosition(),
                                                       targetJointPosition, maxVelo, maxAccel);

                    if (!interpolator->isValid(updateRate)) {
                        logger->error("Failed calculating joint interpolation");
                        delete interpolator;
                        return false;
                    }
                    skillStartTime = std::chrono::steady_clock::now();
                    stepsExecuted = 0;
                    active = true;
                    return true;
                };

                bool halt() override {
                    stepMutex.lock();
                    active = false;
                    delete interpolator;
                    interpolator = nullptr;
                    stepMutex.unlock();
                    return true;
                };

                bool resume() override {
                    return false;

                };

                bool suspend() override {
                    return false;

                };

                bool reset() override {
                    return false;

                };

                void step(rl::mdl::Dynamic *kinematicRunner) override {
                    stepMutex.lock();

                    // The interpolator could be null if the mutex was just released
                    if (!interpolator) {
                        stepMutex.unlock();
                        return;
                    }

                    auto timeSteps = interpolator->getTimeStep(updateRate);

                    if (stepsExecuted >= timeSteps.second) {
                        active = false;
                        this->moveFinished();
                        logger->info("Move finished");
                        delete interpolator;
                        interpolator = nullptr;
                        stepMutex.unlock();
                        return;
                    }

                    //std::chrono::steady_clock::time_point currentTime = std::chrono::steady_clock::now();
                    ::rl::math::Real ti = ((double)++stepsExecuted) * timeSteps.first;

                    ::rl::math::Vector q0 = getJointPosition();
                    kinematicRunner->setPosition(q0);
                    kinematicRunner->forwardPosition();

                    ::rl::math::Vector qt;
                    ::rl::math::Vector qdt;

                    bool success = interpolator->getInterpolatedJointPosition(kinematicRunner, q0, ti, updateRate, &qt, &qdt);

                    if (!success) {
                        active = false;
                        std::stringstream ss;
                        ss << qt.transpose() * rl::math::RAD2DEG;
                        logger->error("Can not calculate next interpolation. Joint limits exceeded: {}", ss.str());
                        delete interpolator;
                        this->moveErrored();
                        stepMutex.unlock();
                        return;
                    }

                    setJointPosition(qt);
                    stepMutex.unlock();
                }

                bool isActive() override {
                    return active;
                }
            };
        }
    }
}


#endif //ROBOTICS_ROBOT_SKILLS_JOINTPTPMOVEIMPL_HPP
