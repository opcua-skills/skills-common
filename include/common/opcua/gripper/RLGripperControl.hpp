/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_RLGRIPPERCONTROL_HPP
#define ROBOTICS_RLGRIPPERCONTROL_HPP

#include <rl/hal/Gripper.h>
#include <common/opcua/skill/gripper/GraspReleaseGripperSkill.hpp>
#include <libconfig.h++>
#include <utility>
#include "RLGripperGraspImpl.hpp"
#include "RLGripperReleaseImpl.hpp"

namespace fortiss {
    namespace opcua {
        namespace gripper {

            class RlGripperControl {
            public:
                explicit RlGripperControl(
                        std::shared_ptr<spdlog::logger>  _logger,
                        const libconfig::Setting& settings,
                        rl::hal::Gripper* gripperDevice,
                        std::shared_ptr<fortiss::opcua::OpcUaServer> _server,
                        const UA_NodeId releaseSkillId,
                        const UA_NodeId graspSkillId
                ) :
                        gripper(gripperDevice),
                        server(std::move(_server)),
                        logger(std::move(_logger)),
                        simulation(settings["simulation"]),
                        releaseSkillId(releaseSkillId),
                        graspSkillId(graspSkillId) {
                    logger->info("Initializing Gripper");
                    initSkills();
                }

                virtual ~RlGripperControl() {
                    if (gripper) {
                        gripper->stop();
                        delete gripper;
                    }
                }

                virtual bool connect() {
                    if (!releaseSkill->transition(fortiss::opcua::ProgramStateNumber::READY)) {
                        logger->error("Can not transition skill to ready");
                        return false;
                    }
                    if (!graspSkill->transition(fortiss::opcua::ProgramStateNumber::READY)) {
                        logger->error("Can not transition skill to ready");
                        return false;
                    }
                    return true;
                }

                virtual RlGripperState getGripperState() = 0;

                bool step() {

                    releaseImpl->step();
                    graspImpl->step();
                    return true;
                }

                void stop() {
                    gripper->stop();
                }

                void shutdown() {
                    gripper->stop();
                }

            protected:

                rl::hal::Gripper* gripper;
                const std::shared_ptr<fortiss::opcua::OpcUaServer> server;
                std::shared_ptr<spdlog::logger> logger;

                bool simulation;

                std::function<bool()> startMoveGripperCallback;


                std::unique_ptr<fortiss::opcua::skill::gripper::GraspReleaseGripperSkill> releaseSkill;
                std::unique_ptr<fortiss::opcua::skill::gripper::GraspReleaseGripperSkill> graspSkill;
            private:


                const UA_NodeId releaseSkillId;
                const UA_NodeId graspSkillId;

                std::shared_ptr<fortiss::RLGripperReleaseImpl> releaseImpl;
                std::shared_ptr<fortiss::RLGripperGraspImpl> graspImpl;

                void initSkills() {
                    releaseSkill = std::make_unique<fortiss::opcua::skill::gripper::GraspReleaseGripperSkill>
                            (server, logger,
                             releaseSkillId,
                             "ReleaseGripper Skill");

                    releaseImpl = std::make_shared<fortiss::RLGripperReleaseImpl>(logger,
                                                                                  gripper, simulation);
                    releaseImpl->startMoveGripperCallback = [this]() {
                        if (startMoveGripperCallback)
                            return startMoveGripperCallback();
                        return true;
                    };
                    releaseSkill->setImpl(releaseImpl.get());


                    graspSkill = std::make_unique<fortiss::opcua::skill::gripper::GraspReleaseGripperSkill>
                            (server, logger,
                             graspSkillId,
                             "CloseGripper Skill");
                    graspImpl = std::make_shared<fortiss::RLGripperGraspImpl>(logger,
                                                                              gripper, simulation);
                    graspImpl->startMoveGripperCallback = [this]() {
                        if (startMoveGripperCallback)
                            return startMoveGripperCallback();
                        return true;
                    };
                    graspSkill->setImpl(graspImpl.get());

                }
            };
        }
    }
}

#endif //ROBOTICS_RLGRIPPERCONTROL_HPP
