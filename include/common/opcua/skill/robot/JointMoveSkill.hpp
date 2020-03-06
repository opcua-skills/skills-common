//
// Created by profanter on 14/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_JOINTMOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_JOINTMOVESKILL_HPP
#pragma once

#include "MoveSkill.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                template<int AXIS_COUNT>
                class JointMoveSkill : virtual public MoveSkill {

                protected:

                    SkillParameter<std::array<double, AXIS_COUNT>> targetJointPositionParameter;

                    virtual UA_StatusCode readParameters() override {
                        UA_StatusCode ret = MoveSkill::readParameters();

                        if (ret != UA_STATUSCODE_GOOD)
                            return ret;

                        ret = readParameter<std::array<double, AXIS_COUNT>, double, AXIS_COUNT>(
                                targetJointPositionParameter,
                                [this](const double &x, size_t idx) {
                                    targetJointPositionParameter.value[idx] = x;
                                });
                        return ret;
                    }

                public:

                    explicit JointMoveSkill(UA_Server
                                            *server,
                                            std::shared_ptr<spdlog::logger> &logger,
                                            const UA_NodeId &skillNodeId,
                                            const std::string &eventSourceName) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            MoveSkill(server, logger, skillNodeId, eventSourceName),
                            targetJointPositionParameter(&UA_TYPES[UA_TYPES_DOUBLE], "TargetJointPosition",
                                                UA_Server_getObjectComponentId(server, *parameterSetNodeId,
                                                                               UA_QUALIFIEDNAME(
                                                                                       static_cast<UA_UInt16>(nsForRobIdx),
                                                                                       const_cast<char *>("TargetJointPosition")))) {
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_JOINTMOVESKILL_HPP