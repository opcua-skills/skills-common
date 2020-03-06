//
// Created by profanter on 14/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANPTPMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANPTPMOVESKILL_HPP
#pragma once

#include "PtpMoveSkill.hpp"
#include "CartesianMoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class CartesianPtpMoveSkill;

                template<int AXIS_COUNT>
                class CartesianPtpMoveSkillImpl : virtual public SkillImpl {

                public:
                    friend class CartesianPtpMoveSkill<AXIS_COUNT>;

                protected:
                    virtual bool start(const UA_ThreeDFrame &targetPosition,
                                       const std::string &toolFrame,
                                       const std::array<double, AXIS_COUNT> &maxVelocity,
                                       const std::array<double, AXIS_COUNT> &maxAcceleration,
                                       const std::array<UA_Range, AXIS_COUNT> &axisBounds) = 0;

                    virtual bool halt() = 0;

                    virtual bool resume() = 0;

                    virtual bool suspend() = 0;

                    virtual bool reset() = 0;

                    std::function<void()> moveFinished;
                    std::function<void()> moveErrored;
                };

                template<int AXIS_COUNT>
                class CartesianPtpMoveSkill :
                        virtual public PtpMoveSkill<AXIS_COUNT>,
                        virtual public CartesianMoveSkill<AXIS_COUNT> {

                protected:
                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = PtpMoveSkill<AXIS_COUNT>::readParameters();
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        return CartesianMoveSkill<AXIS_COUNT>::readParameters();
                    }

                public:
                    explicit CartesianPtpMoveSkill(UA_Server
                                                   *server,
                                                   std::shared_ptr<spdlog::logger> &logger,
                                                   const UA_NodeId &skillNodeId,
                                                   const std::string &eventSourceName) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            PtpMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName),
                            CartesianMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName) {

                    }


                    virtual void setImpl(CartesianPtpMoveSkillImpl<AXIS_COUNT> *impl, std::function<void()> implDeleter) {
                        SkillBase::setImpl(impl, implDeleter);

                        this->startCallback = [impl, this]() {
                            if (this->readParameters() != UA_STATUSCODE_GOOD)
                                return false;
                            return impl->start(this->targetPositionParameter.value,
                                               this->toolFrameParameter.value,
                                               this->maxVelocityParameter.value,
                                               this->maxAccelerationParameter.value,
                                               this->axisBoundsParameter.value);
                        };
                        this->haltCallback = std::bind(
                                &CartesianPtpMoveSkillImpl<AXIS_COUNT>::halt, impl);
                        this->resumeCallback = std::bind(
                                &CartesianPtpMoveSkillImpl<AXIS_COUNT>::resume, impl);
                        this->suspendCallback = std::bind(
                                &CartesianPtpMoveSkillImpl<AXIS_COUNT>::suspend, impl);
                        this->resetCallback = std::bind(
                                &CartesianPtpMoveSkillImpl<AXIS_COUNT>::reset, impl);
                        impl->moveErrored = std::bind(
                                &CartesianPtpMoveSkill<AXIS_COUNT>::moveErrored, this);
                        impl->moveFinished = std::bind(
                                &CartesianPtpMoveSkill<AXIS_COUNT>::moveFinished, this);
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANPTPMOVESKILL_HPP
