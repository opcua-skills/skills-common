#include <utility>

//
// Created by profanter on 15/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_OPCUA_SKILL_PARAMETER_HPP
#define ROBOTICS_COMMON_OPCUA_SKILL_PARAMETER_HPP

namespace fortiss {

    namespace opcua {
        namespace skill {

            template<typename T>
            class SkillParameter {

            public:
                T value;
                const UA_DataType* type;
                const std::string name;
                const std::shared_ptr<UA_NodeId> nodeId;

                explicit SkillParameter(const UA_DataType* type, std::string name, const std::shared_ptr<UA_NodeId> nodeId):
                    value(), type(type), name(std::move(name)), nodeId(nodeId)
                {
                }
            };
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_SKILL_PARAMETER_HPP
