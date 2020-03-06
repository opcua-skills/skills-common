#include <utility>

//
// Created by profanter on 1/11/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_RLROBOTCONTROL_HPP
#define ROBOTICS_RLROBOTCONTROL_HPP
#pragma once

#include "common/logging.h"

#include "common/opcua/skill/robot/CartesianLinearMoveSkill.hpp"
#include "common/opcua/skill/robot/CartesianPtpMoveSkill.hpp"
#include "common/opcua/skill/robot/JointLinearMoveSkill.hpp"
#include "common/opcua/skill/robot/JointPtpMoveSkill.hpp"

#include "common/opcua/robot/RLRobotMove.hpp"
#include "common/opcua/robot/OpcUAMotionDevice.hpp"
#include "common/opcua/robot/CartesianPositionLinearActuator.hpp"
#include "common/opcua/robot/JointPositionLinearActuator.hpp"
#include "common/opcua/robot/CartesianVelocityActuator.hpp"
#include "common/opcua/robot/CartesianForceTorqueActuator.hpp"

#include "for_rob_nodeids.h"

#include "libconfig.h++"

#include <rl/mdl/Dynamic.h>
#include <rl/prog/JointMotion.h>
#include <rl/prog/LinearMotion.h>
#include <rl/prog/JointPositionControl.h>
#include <rl/prog/MotionDevice.h>
#include <rl/hal/DeviceException.h>
#include <rl/hal/ComException.h>
#include <rl/hal/CartesianPositionActuator.h>
#include <rl/hal/Coach.h>
#include <rl/mdl/XmlFactory.h>

#include <rl/math/Vector.h>
#include <rl/math/Polynomial.h>


typedef UA_Frame UA_Frame;

namespace fortiss {
    namespace opcua {
        namespace robot {
            template<int AXIS_COUNT>
            class RlRobotControl
                    : public fortiss::opcua::robot::OpcUAMotionDevice<AXIS_COUNT> {
            private:

                const UA_NodeId skillsNodeId;

                bool robotSupportsToolOffset;
                bool robotSupportsStatus;

                std::shared_ptr<rl::mdl::Dynamic> kinematic;

            public:

                /**
                 *
                 * @param robotSupportsToolOffset Indicates if this specific robot supports tool offsets.
                 *      A robot can have a tool attached or not. A tool is attached via the corresponding OPC UA method.
                 *      If robotSupportsToolOffset is true, then the tool attaching is forwarded to the underlying robot driver.
                 *      If it is false, the tool offset is stored and subtracted from the received cartesian position.
                 *
                 *      If there is no tool, then this variable has no effect.
                 *      If there is a tool attached then the received cartesian positions are assumed in tool frame.
                 *      If robotSupportsToolOffset is true, then the received cartesian position is directly forwarded to the robot driver.
                 *      If it is false, the attached tool offset is subtracted from the received position and then forwarded to the robot driver.
                 *
                 * @param robotSupportsStatus Indicates if this specific robot supports status reporting.
                 *      If this is set to false, the move is finished as soon as the target position is reached (checked in every step)
                 *      If set to true, the specific robot implementation needs to check the current robot status and wait for state changes.
                 *      It then should call moveStopped() after the robot has stopped, which will then check if the position is reached or not.
                 */
                explicit RlRobotControl(const std::shared_ptr<spdlog::logger> &_logger,
                                        const libconfig::Setting &robotSettings,
                                        rl::hal::CyclicDevice *robotDevice,
                                        UA_Server *uaServer,
                                        const UA_NodeId controllerNodeId,
                                        const UA_NodeId skillsNodeId,
                                        bool robotSupportsToolOffset = false,
                                        bool robotSupportsStatus = false) :
                        fortiss::opcua::robot::OpcUAMotionDevice<AXIS_COUNT>(uaServer, controllerNodeId, _logger),
                        skillsNodeId(skillsNodeId),
                        robotSupportsToolOffset(robotSupportsToolOffset),
                        robotSupportsStatus(robotSupportsStatus),
                        worldToRobotTransform(getWorldToRobotTransform(_logger, robotSettings, uaServer, controllerNodeId)),
                        uaServer(uaServer),
                        logger(_logger),
                        robotMove(logger, robotSettings, robotDevice, uaServer),
                        skillMutex() {

                    rl::mdl::XmlFactory mdlFactory;
                    kinematic = std::dynamic_pointer_cast<rl::mdl::Dynamic>(
                            mdlFactory.create(robotSettings["mdlFile"]));


                    initCallbacks();
                }

                virtual ~RlRobotControl() {
                    shutdown();
                    for (auto s : skills) {
                        delete s;
                    }
                }

                std::shared_ptr<rl::mdl::Dynamic> getKinematic() {
                    return kinematic;
                }

                bool isConnected() {
                   return robotMove.isConnected();
                }

                virtual bool connect() {
                    if (robotMove.isConnected())
                        return false;

                    std::promise<void> deviceRunning = robotMove.connect();

                    std::future_status status = deviceRunning.get_future().wait_for(std::chrono::seconds(4));

                    if (status == std::future_status::timeout) {
                        logger->error("Connection timeout!");
                        return false;
                    }

                    logger->info("Robot initialized");

                    for (auto skill : skills) {
                        if (!skill->transition(fortiss::opcua::ProgramStateNumber::READY)) {
                            logger->error("Can not transition skill to ready");
                            return false;
                        }
                    }

                    return true;
                }

                virtual bool step() {
                    try {
                        robotMove.step();
                    } catch (const rl::hal::DeviceException &e) {
                        logger->critical("Robot Step failed with DeviceException: {}", e.what());
                        return false;
                    } catch (const rl::hal::ComException &e) {
                        logger->critical("Robot Step failed with ComException: {}", e.what());
                        return false;
                    } catch (const std::exception &e) {
                        logger->critical("Robot Step failed with Exception: {}", e.what());
                        return false;
                    }

                    return true;
                }

                virtual void moveStopped() {
                    for (auto skill: skills) {
                        skill->moveErrored();
                    }
                    logger->info("Move ERROR");
                }


                virtual void moveReset() {
                    for (auto skill: skills) {
                        skill->moveReset();
                    }
                    logger->info("Move Reset");
                }

                virtual void stop() {
                    robotMove.stop();
                }

                virtual void shutdown() {
                    stop();
                    logger->info("Shutting down the robot ...");
                }

                rl::hal::CyclicDevice *getRobot() {
                    return robotMove.getRobot();
                }

                const UA_NodeId& getSkillsNodeId() const {
                    return skillsNodeId;
                }

                const rl::math::Transform worldToRobotTransform;

            protected:

                UA_Server *uaServer;

                std::shared_ptr<spdlog::logger> logger;

                RlRobotMove<AXIS_COUNT> robotMove;

                std::unique_ptr<fortiss::opcua::skill::SkillRunMutex> skillMutex;

                std::vector<fortiss::opcua::skill::robot::MoveSkill *> skills;

                virtual ::rl::math::Vector getJointPosition() override {
                    return robotMove.getJointPosition();
                }

                virtual void initCallbacks() {

                    this->setToolCallback = std::bind(
                            &RlRobotControl<AXIS_COUNT>::setTool, this,
                            std::placeholders::_1, std::placeholders::_2, std::placeholders::_3, std::placeholders::_4,
                            std::placeholders::_5);
                    this->clearToolCallback = std::bind(
                            &RlRobotControl<AXIS_COUNT>::clearTool, this);

                }

                void addSkill(fortiss::opcua::skill::robot::MoveSkill *skill, RLSkillImpl* impl) {
                    if (skill->getImpl() != impl) {
                        throw std::runtime_error("Skill has different implementation");
                    }

                    robotMove.addSkill(impl);
                    skills.push_back(skill);
                }

                bool addDefaultCartesianLinearMoveSkill() {
                    UA_NodeId cartesianLinearMoveSkillId = UA_NODEID_NULL;

                    bool found = UA_Server_findChildOfType(uaServer, logger, skillsNodeId, UA_NODEID_NUMERIC(
                            fortiss::opcua::UA_Server_getNamespaceIdByName(
                                    uaServer, NAMESPACE_URI_FOR_ROB),
                            UA_FOR_ROBID_CARTESIANLINEARMOVESKILLTYPE), &cartesianLinearMoveSkillId);
                    if (!found) {
                        logger->error("No or multiple CartesianLinearMoveSkillType found on the server.");
                        return false;
                    }

                    auto cartesianLinearMoveImpl = new CartesianLinearMoveImpl<AXIS_COUNT>(logger,
                                                                                           std::bind(
                                                                                                   &RlRobotMove<AXIS_COUNT>::getJointPosition,
                                                                                                   &robotMove),
                                                                                           std::bind(
                                                                                                   &RlRobotMove<AXIS_COUNT>::setJointPosition,
                                                                                                   &robotMove, std::placeholders::_1),
                                                                                           dynamic_cast<rl::hal::CyclicDevice *>(robotMove.getRobot())->getUpdateRate(),
                                                                                           kinematic,
                                                                                           robotSupportsToolOffset,
                                                                                           std::bind(
                                                                                                   &RlRobotMove<AXIS_COUNT>::getToolOffset,
                                                                                                   &robotMove));
                    auto cartesianLinearMoveSkill =
                            new fortiss::opcua::skill::robot::CartesianLinearMoveSkill<AXIS_COUNT>
                                    (uaServer, logger, cartesianLinearMoveSkillId,
                                     "CartesianLinearMoveSkill");
                    cartesianLinearMoveSkill->setImpl(cartesianLinearMoveImpl, [cartesianLinearMoveImpl]() {
                        delete cartesianLinearMoveImpl;
                    });
                    cartesianLinearMoveImpl->addRunMutex(skillMutex.get());
                    addSkill(cartesianLinearMoveSkill, cartesianLinearMoveImpl);

                    return true;
                }

                bool addDefaultCartesianPtpMoveSkill() {

                    UA_NodeId cartesianPtpMoveSkillId = UA_NODEID_NULL;
                    bool found = UA_Server_findChildOfType(uaServer, logger, skillsNodeId, UA_NODEID_NUMERIC(
                            fortiss::opcua::UA_Server_getNamespaceIdByName(
                                    uaServer, NAMESPACE_URI_FOR_ROB),
                            UA_FOR_ROBID_CARTESIANPTPMOVESKILLTYPE), &cartesianPtpMoveSkillId);
                    if (!found) {
                        logger->error("No or multiple CartesianPtpMoveSkillType found on the server.");
                        return false;
                    }

                    auto cartesianPtpMoveImpl = new CartesianPtpMoveImpl<AXIS_COUNT>(logger,
                                                                                     std::bind(
                                                                                             &RlRobotMove<AXIS_COUNT>::getJointPosition,
                                                                                             &robotMove),
                                                                                     std::bind(
                                                                                             &RlRobotMove<AXIS_COUNT>::setJointPosition,
                                                                                             &robotMove, std::placeholders::_1),
                                                                                     dynamic_cast<rl::hal::CyclicDevice *>(robotMove.getRobot())->getUpdateRate(),
                                                                                     kinematic);

                    auto cartesianPtpMoveSkill = new fortiss::opcua::skill::robot::CartesianPtpMoveSkill<AXIS_COUNT>
                            (uaServer, logger, cartesianPtpMoveSkillId,
                             "CartesianPtpMoveSkill");
                    cartesianPtpMoveSkill->setImpl(cartesianPtpMoveImpl, [cartesianPtpMoveImpl]() {
                        delete cartesianPtpMoveImpl;
                    });
                    cartesianPtpMoveImpl->addRunMutex(skillMutex.get());
                    addSkill(cartesianPtpMoveSkill, cartesianPtpMoveImpl);

                    return true;
                }

                bool addDefaultJointLinearMoveSkill() {

                    UA_NodeId jointLinearMoveSkillId = UA_NODEID_NULL;


                    bool found = UA_Server_findChildOfType(uaServer, logger, skillsNodeId, UA_NODEID_NUMERIC(
                            fortiss::opcua::UA_Server_getNamespaceIdByName(
                                    uaServer, NAMESPACE_URI_FOR_ROB),
                            UA_FOR_ROBID_JOINTLINEARMOVESKILLTYPE), &jointLinearMoveSkillId);
                    if (!found) {
                        logger->error("No or multiple JointLinearMoveSkillType found on the server.");
                        return false;
                    }

                    auto jointLinearMoveImpl = new JointLinearMoveImpl<AXIS_COUNT>(logger,
                                                                                   std::bind(
                                                                                           &RlRobotMove<AXIS_COUNT>::getJointPosition,
                                                                                           &robotMove),
                                                                                   std::bind(
                                                                                           &RlRobotMove<AXIS_COUNT>::setJointPosition,
                                                                                           &robotMove, std::placeholders::_1),
                                                                                   dynamic_cast<rl::hal::CyclicDevice *>(robotMove.getRobot())->getUpdateRate(),
                                                                                   kinematic);

                    auto jointLinearMoveSkill = new fortiss::opcua::skill::robot::JointLinearMoveSkill<AXIS_COUNT>
                            (uaServer, logger, jointLinearMoveSkillId,
                             "JointLinearMoveSkill");
                    jointLinearMoveSkill->setImpl(jointLinearMoveImpl, [jointLinearMoveImpl]() {
                        delete jointLinearMoveImpl;
                    });
                    jointLinearMoveImpl->addRunMutex(skillMutex.get());
                    addSkill(jointLinearMoveSkill, jointLinearMoveImpl);

                    return true;
                }

                bool addDefaultJointPtpMoveSkill() {

                    UA_NodeId jointPtpMoveSkillId = UA_NODEID_NULL;


                    bool found = UA_Server_findChildOfType(uaServer, logger, skillsNodeId, UA_NODEID_NUMERIC(
                            fortiss::opcua::UA_Server_getNamespaceIdByName(
                                    uaServer, NAMESPACE_URI_FOR_ROB),
                            UA_FOR_ROBID_JOINTPTPMOVESKILLTYPE), &jointPtpMoveSkillId);
                    if (!found) {
                        logger->error("No or multiple JointPtpMoveSkillType found on the server.");
                        return false;
                    }


                    auto jointPtpMoveImpl = new JointPtpMoveImpl<AXIS_COUNT>(logger,
                                                                             std::bind(
                                                                                     &RlRobotMove<AXIS_COUNT>::getJointPosition,
                                                                                     &robotMove),
                                                                             std::bind(
                                                                                     &RlRobotMove<AXIS_COUNT>::setJointPosition,
                                                                                     &robotMove, std::placeholders::_1),
                                                                             dynamic_cast<rl::hal::CyclicDevice *>(robotMove.getRobot())->getUpdateRate(),
                                                                             kinematic);

                    auto jointPtpMoveSkill = new fortiss::opcua::skill::robot::JointPtpMoveSkill<AXIS_COUNT>
                            (uaServer, logger, jointPtpMoveSkillId,
                             "JointPtpMoveSkill");
                    jointPtpMoveSkill->setImpl(jointPtpMoveImpl, [jointPtpMoveImpl]() {
                        delete jointPtpMoveImpl;
                    });
                    jointPtpMoveImpl->addRunMutex(skillMutex.get());
                    addSkill(jointPtpMoveSkill, jointPtpMoveImpl);

                    return true;
                }


                virtual bool setTool(const std::string &name, const UA_ThreeDFrame &frame, const double mass,
                                     const UA_ThreeDFrame &centerOfMass, const UA_ThreeDVector &inertia) {

                    rl::math::Transform toolOffset;
                    toolOffset = ::rl::math::AngleAxis(
                            frame.orientation.c,
                            ::rl::math::Vector3::UnitZ()
                    ) * ::rl::math::AngleAxis(
                            frame.orientation.b,
                            ::rl::math::Vector3::UnitY()
                    ) * ::rl::math::AngleAxis(
                            frame.orientation.a,
                            ::rl::math::Vector3::UnitX()
                    );
                    toolOffset.translation().x() = frame.cartesianCoordinates.x;
                    toolOffset.translation().y() = frame.cartesianCoordinates.y;
                    toolOffset.translation().z() = frame.cartesianCoordinates.z;

                    robotMove.setToolOffset(toolOffset);

                    return true;
                }

                bool clearTool() {
                    robotMove.setToolOffset(rl::math::Transform::Identity());
                    return true;
                }

            private:

                static rl::math::Transform getWorldToRobotTransform(
                        const std::shared_ptr<spdlog::logger> &logger,
                        const libconfig::Setting &robotSettings,
                        UA_Server *uaServer,
                        const UA_NodeId controllerNodeId) {
                    if (robotSettings.exists("world_to_robot_transform")) {
                        UA_ThreeDFrame worldToRobotFrame = {
                                .cartesianCoordinates = {
                                        .x = robotSettings["world_to_robot_transform"]["x"],
                                        .y = robotSettings["world_to_robot_transform"]["y"],
                                        .z = robotSettings["world_to_robot_transform"]["z"]
                                },
                                .orientation = {
                                        .a = robotSettings["world_to_robot_transform"]["a"],
                                        .b = robotSettings["world_to_robot_transform"]["b"],
                                        .c = robotSettings["world_to_robot_transform"]["c"]
                                }
                        };

                        // Set the variable in the nodeset

                        // First get ParameterSet child
                        std::shared_ptr<UA_NodeId> parameterSet = fortiss::opcua::UA_Server_getObjectComponentId_or_Null(
                                uaServer, controllerNodeId,
                                UA_QUALIFIEDNAME(fortiss::opcua::UA_Server_getNamespaceIdByName(
                                        uaServer, NAMESPACE_URI_DI), const_cast<char*>("ParameterSet")));
                        if (!parameterSet) {
                            logger->error("world_to_robot_transform is set in the settings, but ParameterSet Node not found.");
                            throw std::runtime_error("world_to_robot_transform is set in the settings, but ParameterSet Node not found.");
                        }

                        // Then the WorldToRobotBase
                        std::shared_ptr<UA_NodeId> worldToRobotBaseId = fortiss::opcua::UA_Server_getObjectComponentId_or_Null(
                                uaServer, *parameterSet,
                                UA_QUALIFIEDNAME(fortiss::opcua::UA_Server_getNamespaceIdByName(
                                        uaServer, NAMESPACE_URI_FOR_ROB), const_cast<char*>("WorldToRobotBase")));
                        if (!worldToRobotBaseId) {
                            logger->error("world_to_robot_transform is set in the settings, but WorldToRobotBase Node not found.");
                            throw std::runtime_error("world_to_robot_transform is set in the settings, but WorldToRobotBase Node not found.");
                        }

                        UA_Variant var;
                        UA_Variant_init(&var);
                        UA_Variant_setScalar(&var, &worldToRobotFrame, &UA_TYPES[UA_TYPES_THREEDFRAME]);
                        UA_StatusCode retval = UA_Server_writeValue(uaServer, *worldToRobotBaseId, var);
                        if (retval != UA_STATUSCODE_GOOD) {
                            logger->error("Writing to WorldToRobotBase Node failed with: {}", UA_StatusCode_name(retval));
                            throw std::runtime_error("Writing to WorldToRobotBase Node failed");
                        }

                        rl::math::Transform worldToRobot;
                        worldToRobot = ::rl::math::AngleAxis(
                                worldToRobotFrame.orientation.c,
                                ::rl::math::Vector3::UnitZ()
                        ) * ::rl::math::AngleAxis(
                                worldToRobotFrame.orientation.b,
                                ::rl::math::Vector3::UnitY()
                        ) * ::rl::math::AngleAxis(
                                worldToRobotFrame.orientation.a,
                                ::rl::math::Vector3::UnitX()
                        );
                        worldToRobot.translation().x() = worldToRobotFrame.cartesianCoordinates.x;
                        worldToRobot.translation().y() = worldToRobotFrame.cartesianCoordinates.y;
                        worldToRobot.translation().z() = worldToRobotFrame.cartesianCoordinates.z;
                        return worldToRobot;
                    } else {
                        return rl::math::Transform::Identity();
                    }
                }
            };
        }
    }
}

#endif //ROBOTICS_RLROBOTCONTROL_HPP
