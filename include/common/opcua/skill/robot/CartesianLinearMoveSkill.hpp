/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANLINEARMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANLINEARMOVESKILL_HPP
#pragma once

#include "LinearMoveSkill.hpp"
#include "CartesianMoveSkill.hpp"
#include "common/opcua/skill/SkillImpl.hpp"


namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class CartesianLinearMoveSkill;

                template<int AXIS_COUNT>
                class CartesianLinearMoveSkillImpl : virtual public SkillImpl {

                public:
                    friend class CartesianLinearMoveSkill<AXIS_COUNT>;

                protected:
                    virtual bool start(
                            const UA_ThreeDFrame& targetPosition,
                            const std::string& toolFrame,
                            const std::array<double, 6>& maxVelocity,
                            const std::array<double, 6>& maxAcceleration,
                            const std::array<UA_Range, AXIS_COUNT>& axisBounds
                    ) = 0;

                    virtual bool halt() = 0;

                    virtual bool resume() = 0;

                    virtual bool suspend() = 0;

                    virtual bool reset() = 0;

                    std::function<void()> moveFinished;
                    std::function<void()> moveErrored;
                };

                template<int AXIS_COUNT>
                class CartesianLinearMoveSkill :
                        virtual public LinearMoveSkill,
                        virtual public CartesianMoveSkill<AXIS_COUNT> {

                protected:
                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = LinearMoveSkill::readParameters();
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        return CartesianMoveSkill<AXIS_COUNT>::readParameters();
                    }

                public:
                    explicit CartesianLinearMoveSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    ) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            LinearMoveSkill(server, logger, skillNodeId, eventSourceName),
                            CartesianMoveSkill<AXIS_COUNT>(server, logger, skillNodeId, eventSourceName) {
                    }


                    virtual void setImpl(
                            CartesianLinearMoveSkillImpl<AXIS_COUNT>* impl,
                            std::function<void()> implDeleter
                    ) {
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
                                &CartesianLinearMoveSkillImpl<AXIS_COUNT>::halt, impl);
                        this->resumeCallback = std::bind(
                                &CartesianLinearMoveSkillImpl<AXIS_COUNT>::resume, impl);
                        this->suspendCallback = std::bind(
                                &CartesianLinearMoveSkillImpl<AXIS_COUNT>::suspend, impl);
                        this->resetCallback = std::bind(
                                &CartesianLinearMoveSkillImpl<AXIS_COUNT>::reset, impl);
                        impl->moveErrored = std::bind(
                                &CartesianLinearMoveSkill<AXIS_COUNT>::moveErrored, this);
                        impl->moveFinished = std::bind(
                                &CartesianLinearMoveSkill<AXIS_COUNT>::moveFinished, this);
                    }


                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANLINEARMOVESKILL_HPP
