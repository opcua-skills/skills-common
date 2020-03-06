//
// Created by profanter on 14/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_JOINTLINEARMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_JOINTLINEARMOVESKILL_HPP
#pragma once

#include "LinearMoveSkill.hpp"
#include "JointMoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class JointLinearMoveSkill;

                template<int AXIS_COUNT>
                class JointLinearMoveSkillImpl : virtual public SkillImpl {
                public:
                    friend class JointLinearMoveSkill<AXIS_COUNT>;

                protected:
                    virtual bool start(const std::array<double, AXIS_COUNT> &targetJointPosition,
                                       const std::string &toolFrame,
                                       const std::array<double, 6> &maxVelocity,
                                       const std::array<double, 6> &maxAcceleration) = 0;

                    virtual bool halt() = 0;

                    virtual bool resume() = 0;

                    virtual bool suspend() = 0;

                    virtual bool reset() = 0;

                    std::function<void()> moveFinished;
                    std::function<void()> moveErrored;
                };

                template<int AXIS_COUNT>
                class JointLinearMoveSkill :
                        virtual public LinearMoveSkill,
                        virtual public JointMoveSkill<AXIS_COUNT> {

                protected:
                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = LinearMoveSkill::readParameters();
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        return JointMoveSkill<AXIS_COUNT>::readParameters();
                    }

                public:
                    explicit JointLinearMoveSkill(UA_Server
                                                  *server,
                                                  std::shared_ptr<spdlog::logger> &logger,
                                                  const UA_NodeId &skillNodeId,
                                                  const std::string &eventSourceName) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            LinearMoveSkill(server, logger, skillNodeId, eventSourceName),
                            JointMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName) {
                    }

                    virtual void setImpl(JointLinearMoveSkillImpl<AXIS_COUNT> *impl, std::function<void()> implDeleter) {
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
                                &JointLinearMoveSkillImpl<AXIS_COUNT>::halt, impl);
                        this->resumeCallback = std::bind(
                                &JointLinearMoveSkillImpl<AXIS_COUNT>::resume, impl);
                        this->suspendCallback = std::bind(
                                &JointLinearMoveSkillImpl<AXIS_COUNT>::suspend, impl);
                        this->resetCallback = std::bind(
                                &JointLinearMoveSkillImpl<AXIS_COUNT>::reset, impl);
                        impl->moveErrored = std::bind(
                                &JointLinearMoveSkill<AXIS_COUNT>::moveErrored, this);
                        impl->moveFinished = std::bind(
                                &JointLinearMoveSkill<AXIS_COUNT>::moveFinished, this);
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_JOINTLINEARMOVESKILL_HPP
