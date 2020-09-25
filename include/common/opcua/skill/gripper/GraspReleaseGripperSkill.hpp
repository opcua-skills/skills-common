/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_GRIPPER_SKILL_GRIPPER_H
#define ROBOTICS_COMMON_OPCUA_GRIPPER_SKILL_GRIPPER_H
#pragma once

#include <future>
#include <memory>
#include <functional>
#include <utility>
#include "common/opcua/skill/SkillBase.hpp"


namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace gripper {

                class GraspReleaseGripperSkill;

                class GraspReleaseGripperSkillImpl : virtual public SkillImpl {

                public:
                    friend class GraspReleaseGripperSkill;

                protected:
                    virtual bool start() = 0;

                    virtual bool halt() = 0;

                    virtual bool resume() = 0;

                    virtual bool suspend() = 0;

                    virtual bool reset() = 0;

                    std::function<void()> moveFinished;
                    std::function<void()> moveErrored;
                };

                class GraspReleaseGripperSkill : virtual public SkillBase {

                protected:

                    UA_StatusCode readParameters() override {
                        return UA_STATUSCODE_GOOD;
                    }


                public:
                    explicit GraspReleaseGripperSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    )
                            : SkillBase(server, logger, skillNodeId, eventSourceName) {

                        // use dynamic cast to make sure polymorphic resolution is correct
                        auto selfProgram = dynamic_cast<Program*>(this);

                        LockedServer ls = server->getLocked();
                        if (UA_Server_setNodeContext(ls.get(), skillNodeId, selfProgram) != UA_STATUSCODE_GOOD) {
                            throw std::runtime_error("Adding method context failed");
                        }

                    }

                    virtual void setImpl(
                            GraspReleaseGripperSkillImpl* impl,
                            std::function<void()> implDeleter = nullptr
                    ) {
                        SkillBase::setImpl(impl, std::move(implDeleter));

                        this->startCallback = [impl, this]() {
                            if (this->readParameters() != UA_STATUSCODE_GOOD)
                                return false;
                            return impl->start();
                        };
                        this->haltCallback = std::bind(
                                &GraspReleaseGripperSkillImpl::halt, impl);
                        this->resumeCallback = std::bind(
                                &GraspReleaseGripperSkillImpl::resume, impl);
                        this->suspendCallback = std::bind(
                                &GraspReleaseGripperSkillImpl::suspend, impl);
                        this->resetCallback = std::bind(
                                &GraspReleaseGripperSkillImpl::reset, impl);
                        impl->moveErrored = std::bind(
                                &GraspReleaseGripperSkill::gripperErrored, this);
                        impl->moveFinished = std::bind(
                                &GraspReleaseGripperSkill::gripperFinished, this);
                    }

                    void gripperFinished() {
                        if (!transition(ProgramStateNumber::READY)) {
                            logger->error("Failed to make transition after gripper has finished to ready");
                        }
                    }

                    void gripperErrored() {
                        if (!transition(ProgramStateNumber::HALTED)) {
                            logger->error("Failed to make transition after gripper has finished to halted");
                        }
                    }


                };
            }
        }
    }
}


#endif //ROBOTICS_COMMON_OPCUA_GRIPPER_SKILL_GRIPPER_H
