/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_REGISTEREDCOMPONENT_H
#define ROBOTICS_COMMON_REGISTEREDCOMPONENT_H

#include <memory>
#include <string>
#include <open62541/types_generated.h>
#include <open62541/client.h>
#include <vector>
#include <chrono>
#include <functional>
#include <thread>
#include <spdlog/spdlog.h>

#include <common/opcua/helper.hpp>
#include <rl/math/Transform.h>

class RegisteredSkill;

class RegisteredComponent {

public:
    explicit RegisteredComponent(
            std::shared_ptr<spdlog::logger> _logger,
            std::shared_ptr<spdlog::logger> _loggerOpcua,
            std::shared_ptr<const UA_EndpointDescription> endpoint,
            std::string endpointUrl,
            const std::string&  clientCertPath,
            const std::string&  clientKeyPath,
            const std::string&  clientAppUri,
            const std::string&  clientAppName) :
            endpoint(std::move(endpoint)),
            endpointUrl(endpointUrl.length() > 0 && endpointUrl.at(endpointUrl.size()-1) != '/' ? endpointUrl + '/' : endpointUrl),
            skills(),
            nsDiIdx(0),
            nsFortissDiIdx(0),
            clientCertPath(clientCertPath),
            clientKeyPath(clientKeyPath),
            clientAppUri(clientAppUri),
            clientAppName(clientAppName),
            client(nullptr),
            logger(std::move(_logger)),
            loggerOpcua(std::move(_loggerOpcua)) {
    };

    virtual ~RegisteredComponent();

    const std::shared_ptr<const UA_EndpointDescription> endpoint;
    const std::string endpointUrl;
    std::vector<std::shared_ptr<RegisteredSkill>> skills;
    UA_UInt16 nsDiIdx;
    UA_UInt16 nsFortissDiIdx;

    std::function<void()> offlineCallback;


    bool monitorOnline(std::chrono::milliseconds checkInterval);
    void monitorOnlineStop();

    LockedClient getLockedClient() {
        return client.data();
    };

    bool connectClient();
    void disconnectClient();
    bool ensureConnected();

    UA_StatusCode getWorldToRobotTransform(rl::math::Transform *transform);
private:

    const std::string  clientCertPath;
    const std::string  clientKeyPath;
    const std::string  clientAppUri;
    const std::string  clientAppName;

    MutexedClient client;
    UA_Client* clientUnsafe = nullptr;
    std::shared_ptr<spdlog::logger> logger;
    std::shared_ptr<spdlog::logger> loggerOpcua;
    std::thread monitorOnlineThread;
    bool monitorThreadRunning = false;
    UA_UInt32 monId = 0;
    UA_UInt32 subId = 0;
    bool createServerStateSubscription(std::chrono::milliseconds checkInterval);
    bool checkOnline(std::chrono::milliseconds checkInterval);
    std::chrono::steady_clock::time_point lastTimeUpdate = std::chrono::steady_clock::now();

    static void handler_TimeChanged(UA_Client *client, UA_UInt32 subId, void *subContext,
                         UA_UInt32 monId, void *monContext, UA_DataValue *value);

    // Some specific caching variables

    std::mutex worldToRobotTransformMutex;
    std::shared_ptr<rl::math::Transform> worldToRobotTransform = nullptr;
};

#endif //ROBOTICS_COMMON_REGISTEREDCOMPONENT_H
