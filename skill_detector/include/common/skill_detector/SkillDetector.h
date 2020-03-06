//
// Created by profanter on 13/08/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_SKILLDETECTOR_H
#define ROBOTICS_COMMON_SKILLDETECTOR_H

#include <spdlog/spdlog.h>
#include <open62541/types_generated.h>
#include <open62541/client_config.h>

#include <utility>
#include <map>

#include "RegisteredSkill.h"

namespace std
{
    template<> struct less<const UA_NodeId>
    {
        bool operator() (const UA_NodeId& lhs, const UA_NodeId& rhs) const
        {
            return UA_NodeId_order(&lhs, &rhs) == UA_ORDER_LESS;
        }
    };
}

class SkillDetector {

public:
    explicit SkillDetector(
            std::shared_ptr<spdlog::logger> _logger,
            const std::string&  clientCertPath,
            const std::string&  clientKeyPath,
            const std::string&  clientAppUri,
            const std::string&  clientAppName,
            std::chrono::milliseconds monitorOnlineInterval = std::chrono::milliseconds(0));

    SkillDetector(const SkillDetector& d) = delete;

    virtual ~SkillDetector();

    void componentConnected(
            const std::shared_ptr<const UA_RegisteredServer>& registeredServer,
            const std::shared_ptr<const UA_EndpointDescription>& endpoint);
    void componentConnected(
            const std::shared_ptr<const UA_ServerOnNetwork>& registeredServer,
            const std::shared_ptr<const UA_EndpointDescription>& endpoint);

    void componentDisconnected(
            const std::shared_ptr<const UA_RegisteredServer>& registeredServer);
    void componentDisconnected(
            const std::shared_ptr<const UA_ServerOnNetwork>& registeredServer);

    std::multimap<const std::string, std::shared_ptr<RegisteredSkill>> registeredSkills;
    std::map<const std::string, std::shared_ptr<RegisteredComponent>> registeredComponents;

    std::shared_ptr<RegisteredComponent> getComponentForEndpoint(const std::string& endpointUrl);
    std::vector<std::shared_ptr<RegisteredComponent>> getComponentForAppUri(const std::string& appUri);
    std::vector<std::shared_ptr<RegisteredComponent>> getComponentForAppName(const std::string& appName);
    std::vector<std::shared_ptr<RegisteredSkill>> getSkillForEndpoint(const std::string& endpointUrl, const std::string& skillType);
private:

    std::shared_ptr<spdlog::logger> logger;
    std::shared_ptr<spdlog::logger> loggerClient;

    const std::string clientCertPath;
    const std::string clientKeyPath;
    const std::string clientAppUri;
    const std::string clientAppName;
    const std::chrono::milliseconds monitorOnlineInterval;

    bool addSkillsFromComponent(const std::string& serverUri, std::shared_ptr<RegisteredComponent>& component);
    bool addSkillsFromController(
            std::shared_ptr<RegisteredComponent>& component,
            const std::shared_ptr<UA_NodeId>& controllerId);

    bool removeSkillsFromComponent(const std::string& serverUri, const std::shared_ptr<RegisteredComponent>& component);

    bool findAllSkillControllerNodes(
            std::shared_ptr<RegisteredComponent>& component,
            std::vector<std::shared_ptr<UA_NodeId>>& controllerIds);

};


#endif //ROBOTICS_COMMON_SKILLDETECTOR_H
