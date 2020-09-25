/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_SKILLDETECTOR_H
#define ROBOTICS_COMMON_SKILLDETECTOR_H

#include <spdlog/spdlog.h>
#include <open62541/types_generated.h>

#include <utility>
#include <map>

#include "RegisteredSkill.h"

namespace std {
    template<>
    struct less<const UA_NodeId> {
        bool operator()(
                const UA_NodeId& lhs,
                const UA_NodeId& rhs
        ) const {
            return UA_NodeId_order(&lhs, &rhs) == UA_ORDER_LESS;
        }
    };
}

class SkillDetector {

public:
    explicit SkillDetector(
            std::shared_ptr<spdlog::logger> _loggerApp,
            std::shared_ptr<spdlog::logger> _loggerOpcua,
            std::string clientCertPath,
            std::string clientKeyPath,
            std::string clientAppUri,
            std::string clientAppName,
            std::chrono::milliseconds monitorOnlineInterval = std::chrono::milliseconds(0));

    SkillDetector(const SkillDetector& d) = delete;

    virtual ~SkillDetector();

    void componentConnected(
            const std::shared_ptr<const UA_RegisteredServer>& registeredServer,
            const std::shared_ptr<const UA_EndpointDescription>& endpoint
    );

    void componentConnected(
            const std::shared_ptr<const UA_ServerOnNetwork>& registeredServer,
            const std::shared_ptr<const UA_EndpointDescription>& endpoint
    );

    void componentDisconnected(
            const std::shared_ptr<const UA_RegisteredServer>& registeredServer
    );

    void componentDisconnected(
            const std::shared_ptr<const UA_ServerOnNetwork>& registeredServer
    );

    void onServerAnnounce(
            const UA_ServerOnNetwork* serverOnNetwork,
            UA_Boolean isServerAnnounce
    );

    void onServerRegister(const UA_RegisteredServer* registeredServer);

    std::multimap<const std::string, std::shared_ptr<RegisteredSkill>> registeredSkills;
    std::map<const std::string, std::shared_ptr<RegisteredComponent>> registeredComponents;

    std::shared_ptr<RegisteredComponent> getComponentForEndpoint(const std::string& endpointUrl);

    std::vector<std::shared_ptr<RegisteredComponent>> getComponentForAppUri(const std::string& appUri);

    std::vector<std::shared_ptr<RegisteredComponent>> getComponentForAppName(const std::string& appName);

    std::vector<std::shared_ptr<RegisteredSkill>> getSkillForEndpoint(
            const std::string& endpointUrl,
            const std::string& skillType
    );

    std::shared_ptr<RegisteredSkill> getSkillForEndpointAndBrowseName(
            const std::string& endpointUrl,
            const std::string& skillBrowseName
    );

private:

    std::shared_ptr<spdlog::logger> logger;
    std::shared_ptr<spdlog::logger> loggerOpcua;

    struct ServerKnownData {
        UA_DateTime startTime = 0;
        std::chrono::time_point<std::chrono::steady_clock> lastAnnounce = std::chrono::time_point<std::chrono::steady_clock>::min();
        std::shared_ptr<UA_EndpointDescription> endpoint = nullptr;
    };

    std::mutex registeredMapMutex;
    std::map<std::string, std::shared_ptr<ServerKnownData>> registeredMap;

    const std::string clientCertPath;
    const std::string clientKeyPath;
    const std::string clientAppUri;
    const std::string clientAppName;
    const std::chrono::milliseconds monitorOnlineInterval;

    bool addSkillsFromComponent(
            const std::string& serverUri,
            std::shared_ptr<RegisteredComponent>& component
    );

    bool addSkillsFromController(
            std::shared_ptr<RegisteredComponent>& component,
            const std::shared_ptr<UA_NodeId>& controllerId
    );

    bool removeSkillsFromComponent(
            const std::string& serverUri,
            const std::shared_ptr<RegisteredComponent>& component
    );

    bool findAllSkillControllerNodes(
            std::shared_ptr<RegisteredComponent>& component,
            std::vector<std::shared_ptr<UA_NodeId>>& controllerIds
    );

    bool addServerKnown(
            const std::set<std::string>& discoveryUrls,
            UA_DateTime startTime,
            std::shared_ptr<UA_EndpointDescription>* endpoint
    );

    bool isServerKnown(
            const std::set<std::string>& discoveryUrls,
            bool &error,
            bool* startTimeMatches = nullptr,
            UA_DateTime* currentStartTime = nullptr,
            std::shared_ptr<UA_EndpointDescription>* endpoint = nullptr
    );

    bool isServerRecentlyAnnounced(
            const std::set<std::string>& discoveryUrls,
            bool* startTimeMatches = nullptr,
            UA_DateTime* currentStartTime = nullptr,
            std::shared_ptr<UA_EndpointDescription>* endpoint = nullptr
    );

    void removeServerKnown(
            const std::set<std::string>& discoveryUrls
    );


    std::shared_ptr<UA_EndpointDescription> findAvailableEndpoint(
            const std::set<std::string>& discoveryUrls
    );

    static std::set<std::string> getDiscoveryUrls(const std::shared_ptr<UA_RegisteredServer>& registeredServer);

    static std::set<std::string> getDiscoveryUrls(const std::shared_ptr<UA_ServerOnNetwork>& serverOnNetwork);

};


#endif //ROBOTICS_COMMON_SKILLDETECTOR_H
