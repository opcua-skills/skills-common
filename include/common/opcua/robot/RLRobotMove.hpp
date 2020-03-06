//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_RLROBOTMOVE_HPP
#define ROBOTICS_RLROBOTMOVE_HPP

#include "RLRobotDevice.hpp"

#include "common/opcua/robot/impl/JointPtpMoveImpl.hpp"
#include "common/opcua/robot/impl/JointLinearMoveImpl.hpp"
#include "common/opcua/robot/impl/CartesianPtpMoveImpl.hpp"
#include "common/opcua/robot/impl/CartesianLinearMoveImpl.hpp"

#include <rl/hal/Exception.h>
#include <rl/hal/Coach.h>
#include <rl/mdl/XmlFactory.h>
#include <libconfig.h++>

typedef UA_Frame UA_Frame;

namespace fortiss {
    namespace opcua {
        namespace robot {
            template<int AXIS_COUNT>
            class RlRobotMove {

            private:
                UA_Server *uaServer;

                std::shared_ptr<spdlog::logger> logger;

                RlRobotDevice *robotDevice = nullptr;
                std::thread *progDeviceThread = nullptr;
                std::exception_ptr runException;
                rl::hal::CyclicDevice *coachDevice = nullptr;

                rl::math::Transform toolOffset;

                std::mutex stepMutex;

                bool connected = false;

                bool simulation = false;
                const libconfig::Setting &settings;

                void initRl(rl::hal::CyclicDevice *device) {

                    // Create another instance of the kinematic to be thread safe
                    rl::mdl::XmlFactory mdlFactory;
                    std::shared_ptr<rl::mdl::Dynamic> kinematic = std::dynamic_pointer_cast<rl::mdl::Dynamic>(mdlFactory.create(settings["mdlFile"]));

                    if (simulation && !device) {
                        logger->info("rlCoachMdl {} {} & ", settings["scene"], settings["mdlFile"]);
                        device = new rl::hal::Coach(kinematic->getDof(), ::std::chrono::milliseconds(8), 0,
                                                    settings["ip"]);
                        coachDevice = device;
                        logger->info("Initializing coach (IP: {})", settings["ip"]);
                    } else if (!device) {
                        throw rl::hal::Exception("Robot set to simulation but instance or robot not given.");
                    }

                    robotDevice = new RlRobotDevice(device, kinematic, &stepMutex);

                }

            public:
                explicit RlRobotMove(const std::shared_ptr<spdlog::logger> &_logger,
                                     const libconfig::Setting &robotSettings,
                                     rl::hal::CyclicDevice *robotDevice,
                                     UA_Server *uaServer) :
                        uaServer(uaServer),
                        logger(_logger),
                        runException(nullptr),
                        toolOffset(rl::math::Transform::Identity()),
                        stepMutex(),
                        connected(false), simulation(robotSettings["simulation"]),
                        settings(robotSettings) {
                    initRl(robotDevice);
                }


                virtual ~RlRobotMove() {
                    robotDevice->stop(true);
                    stop();
                    if (progDeviceThread->joinable())
                        progDeviceThread->join();
                    delete progDeviceThread;
                    delete robotDevice;
                    if (coachDevice)
                        delete coachDevice;
                }


                virtual std::promise<void> connect() {


                    runException = nullptr;
                    std::promise<void> deviceRunning;
                    if (connected) {
                        deviceRunning.set_value();
                        return deviceRunning;
                    }

                    robotDevice->addRunningCallback([&deviceRunning, this](bool run) {
                        if (run)
                            deviceRunning.set_value();
                        connected = run;
                    });

                    logger->info("Connecting to robot ...");

                    progDeviceThread = new std::thread([this](void) {
                        try {
                            robotDevice->run();
                        } catch (const rl::hal::Exception &rlex) {
                            runException = std::current_exception();
                        }
                    });


                    return deviceRunning;
                }


                const ::rl::math::Vector getJointPosition() {
                    ::rl::hal::JointPositionSensor *positionSensor = dynamic_cast< ::rl::hal::JointPositionSensor *>(robotDevice->getDevice());
                    rl::math::Vector currentPos;
                    stepMutex.lock();
                    currentPos = positionSensor->getJointPosition();
                    stepMutex.unlock();
                    return currentPos;
                }


                void setJointPosition(const ::rl::math::Vector& pos) {
                    ::rl::hal::JointPositionActuator *positionActuator = dynamic_cast< ::rl::hal::JointPositionActuator *>(robotDevice->getDevice());
                    stepMutex.lock();
                    positionActuator->setJointPosition(pos);
                    stepMutex.unlock();
                }

                void setToolOffset(const rl::math::Transform &offset) {
                    toolOffset = offset;
                }

                const rl::math::Transform getToolOffset() {
                    return toolOffset;
                }

                bool isConnected() const {
                    return connected;
                }

                rl::hal::CyclicDevice *getRobot() {
                    return robotDevice->getDevice();
                }

                bool step() {
                    if (!connected)
                        return false;

                    if (runException) {
                        connected = false;
                        std::rethrow_exception(runException);
                    }
                    return true;
                }

                void stop() {
                    if (!connected)
                        return;

                    logger->info("Stopping the robot ...");

                    robotDevice->stop(true);
                }


                void addSkill(RLSkillImpl* skill) {
                    robotDevice->addSkill(skill);
                }
            };
        }
    }
}

#endif //ROBOTICS_RLROBOTMOVE_HPP
