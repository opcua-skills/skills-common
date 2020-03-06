//
// Created by profanter on 05/09/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_REGISTEREDSKILL_H
#define ROBOTICS_COMMON_REGISTEREDSKILL_H

#include <memory>
#include <open62541/types.h>
#include <spdlog/spdlog.h>
#include <common/client/GenericSkillClient.h>
#include "RegisteredComponent.h"
#include "SkillParameter.h"

class RegisteredSkill {
private:
    std::shared_ptr<RegisteredComponent> parentComponent;
    UA_NodeId skillNodeId;
    UA_NodeId skillTypeId;
    UA_QualifiedName skillTypeName;
    UA_QualifiedName browseName;
    const std::string clientCertPath;
    const std::string clientKeyPath;
    const std::string clientAppUri;
    const std::string clientAppName;

    GenericSkillClient *skillClient = nullptr;
public:
    explicit RegisteredSkill(
            std::shared_ptr<RegisteredComponent> &parentComponent,
            std::shared_ptr<spdlog::logger> &logger,
            UA_NodeId &skillNodeId,
            const std::string& clientCertPath,
            const std::string& clientKeyPath,
            const std::string& clientAppUri,
            const std::string& clientAppName);
    virtual ~RegisteredSkill();

    const UA_NodeId& getSkillTypeId() {
        return skillTypeId;
    }
    std::string getSkillNameStr() {
        return std::string((char*)browseName.name.data, browseName.name.length);
    }
    const UA_QualifiedName& getSkillTypeName() {
        return skillTypeName;
    }
    std::string getSkillTypeNameStr() {
        return std::string((char*)skillTypeName.name.data, skillTypeName.name.length);
    }
    const UA_NodeId& getSkillId() {
        return skillNodeId;
    }

    std::shared_ptr<RegisteredComponent> getParentComponent() {
        return parentComponent;
    }

    std::future<bool> execute(std::shared_ptr<spdlog::logger> &logger, const std::vector<std::shared_ptr<SkillParameter>>& parameters);

    std::future<UA_StatusCode> getFinalResultData(std::shared_ptr<spdlog::logger>& logger, const UA_String& resultData, UA_Variant *data);
};


#endif //ROBOTICS_COMMON_REGISTEREDSKILL_H
