/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_LINEARMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_LINEARMOVESKILL_HPP
#pragma once

#include "MoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                class LinearMoveSkill : virtual public MoveSkill {

                protected:


                    SkillParameter<std::array<double, 6>> maxAccelerationParameter;
                    SkillParameter<std::array<double, 6>> maxVelocityParameter;

                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = MoveSkill::readParameters();

                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        ret = readParameter<std::array<double, 6>, double, 6>(
                                maxAccelerationParameter,
                                [this](
                                        const double& x,
                                        size_t idx
                                ) {
                                    maxAccelerationParameter.value[idx] = x;
                                });
                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        ret = readParameter<std::array<double, 6>, double, 6>(
                                maxVelocityParameter,
                                [this](
                                        const double& x,
                                        size_t idx
                                ) {
                                    maxVelocityParameter.value[idx] = x;
                                });
                        return ret;
                    }

                public:

                    explicit LinearMoveSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    ) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            maxAccelerationParameter(&UA_TYPES[UA_TYPES_DOUBLE], "MaxAcceleration",
                                                     UA_Server_getObjectComponentId(server, *parameterSetNodeId,
                                                                                    UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsForRobIdx),
                                                                                                     const_cast<char*>("MaxAcceleration")))),
                            maxVelocityParameter(&UA_TYPES[UA_TYPES_DOUBLE], "MaxVelocity",
                                                 UA_Server_getObjectComponentId(server, *parameterSetNodeId,
                                                                                UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsForRobIdx),
                                                                                                 const_cast<char*>("MaxVelocity")))) {
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_LINEARMOVESKILL_HPP
