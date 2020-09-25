/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_SKILLCLIENTPARAMETER_H
#define ROBOTICS_SKILLCLIENTPARAMETER_H

#include <open62541/types.h>
#include <string>
#include <memory>
#include <open62541/types_generated_handling.h>

class SkillClientParameter {
public:
    UA_Variant value;
    const std::string name;
    const std::shared_ptr<UA_NodeId> nodeId;

    explicit SkillClientParameter(const std::string &name, const std::shared_ptr<UA_NodeId> nodeId):
            name(std::move(name)), nodeId(nodeId)
    {
        UA_Variant_init(&value);
    }

    virtual ~SkillClientParameter() {
        UA_Variant_clear(&value);
    }
};


#endif //ROBOTICS_SKILLCLIENTPARAMETER_H
