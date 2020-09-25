/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANMOVESKILL_HPP
#pragma once

#include "MoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class CartesianMoveSkill : virtual public MoveSkill {

                protected:


                    SkillParameter <UA_ThreeDFrame> targetPositionParameter;
                    SkillParameter <std::array<UA_Range, AXIS_COUNT>> axisBoundsParameter;

                    UA_StatusCode readParameters() override {
                        UA_StatusCode ret = MoveSkill::readParameters();

                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        ret = readParameter<UA_ThreeDFrame>(
                                targetPositionParameter,
                                [this](const UA_ThreeDFrame& x) {
                                    UA_ThreeDFrame_copy(&x, &targetPositionParameter.value);
                                });
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        if (axisBoundsParameter.nodeId != NULL) {
                            ret = readParameter<std::array<UA_Range, AXIS_COUNT>, UA_Range, AXIS_COUNT>(
                                    axisBoundsParameter,
                                    [this](
                                            const UA_Range& x,
                                            size_t idx
                                    ) {
                                        UA_Range_copy(&x, &axisBoundsParameter.value[idx]);
                                    });
                        } else {
                            axisBoundsParameter.value = std::array<UA_Range, AXIS_COUNT>();
                        }
                        return ret;
                    }

                public:

                    explicit CartesianMoveSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    ) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            targetPositionParameter(&UA_TYPES[UA_TYPES_THREEDFRAME], "TargetPosition",
                                                    UA_Server_getObjectComponentId(server, *parameterSetNodeId,
                                                                                   UA_QUALIFIEDNAME(
                                                                                           static_cast<UA_UInt16>(nsForRobIdx),
                                                                                           const_cast<char*>("TargetPosition")))),
                            axisBoundsParameter(&UA_TYPES[UA_TYPES_RANGE], "AxisBounds",
                                                UA_Server_getObjectComponentId_or_Null(server, *parameterSetNodeId,
                                                                                       UA_QUALIFIEDNAME(
                                                                                               static_cast<UA_UInt16>(nsForRobIdx),
                                                                                               const_cast<char*>("AxisBounds")))) {
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_CARTESIANMOVESKILL_HPP
