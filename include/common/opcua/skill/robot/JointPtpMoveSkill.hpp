/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_JOINTPTPMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_JOINTPTPMOVESKILL_HPP
#pragma once

#include "PtpMoveSkill.hpp"
#include "JointMoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class JointPtpMoveSkill;

                template<int AXIS_COUNT>
                class JointPtpMoveSkillImpl : virtual public SkillImpl {
                public:
                    friend class JointPtpMoveSkill<AXIS_COUNT>;

                protected:
                    virtual bool start(
                            const std::array<double, AXIS_COUNT>& targetJointPosition,
                            const std::string& toolFrame,
                            const std::array<double, AXIS_COUNT>& maxVelocity,
                            const std::array<double, AXIS_COUNT>& maxAcceleration
                    ) = 0;

                    virtual bool halt() = 0;

                    virtual bool resume() = 0;

                    virtual bool suspend() = 0;

                    virtual bool reset() = 0;

                    std::function<void()> moveFinished;
                    std::function<void()> moveErrored;
                };

                template<int AXIS_COUNT>
                class JointPtpMoveSkill :
                        virtual public PtpMoveSkill<AXIS_COUNT>,
                        virtual public JointMoveSkill<AXIS_COUNT> {

                protected:
                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = PtpMoveSkill<AXIS_COUNT>::readParameters();
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        return JointMoveSkill<AXIS_COUNT>::readParameters();
                    }

                public:
                    explicit JointPtpMoveSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    ) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            PtpMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName),
                            JointMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName) {

                    }


                    virtual void setImpl(
                            JointPtpMoveSkillImpl<AXIS_COUNT>* impl,
                            std::function<void()> implDeleter
                    ) {
                        SkillBase::setImpl(impl, implDeleter);

                        this->startCallback = [impl, this]() {
                            if (this->readParameters() != UA_STATUSCODE_GOOD)
                                return false;
                            return impl->start(this->targetJointPositionParameter.value,
                                               this->toolFrameParameter.value,
                                               this->maxVelocityParameter.value,
                                               this->maxAccelerationParameter.value);
                        };
                        this->haltCallback = std::bind(
                                &JointPtpMoveSkillImpl<AXIS_COUNT>::halt, impl);
                        this->resumeCallback = std::bind(
                                &JointPtpMoveSkillImpl<AXIS_COUNT>::resume, impl);
                        this->suspendCallback = std::bind(
                                &JointPtpMoveSkillImpl<AXIS_COUNT>::suspend, impl);
                        this->resetCallback = std::bind(
                                &JointPtpMoveSkillImpl<AXIS_COUNT>::reset, impl);
                        impl->moveErrored = std::bind(
                                &JointPtpMoveSkill<AXIS_COUNT>::moveErrored, this);
                        impl->moveFinished = std::bind(
                                &JointPtpMoveSkill<AXIS_COUNT>::moveFinished, this);
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_JOINTPTPMOVESKILL_HPP
