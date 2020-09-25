/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/opcua/server/OpcUaServer.h>

using namespace fortiss::opcua;

#ifdef UA_ENABLE_AMALGAMATION
#include "open62541.h"
#else
#include <open62541/types.h>
#endif

#include <common/opcua/helper.hpp>
#include <utility>
#include <common/logging.h>

#ifndef ESP_PLATFORM
OpcUaServer::OpcUaServer(
        const libconfig::Setting& settings,
        std::shared_ptr<spdlog::logger> _logger,
        const std::string& appUri,
        const std::string& appName,
        const std::string& certFilesPath,
        std::string clientAppUri,
        std::string clientAppName,
        std::string clientCertFilesPath
) :
        clientAppUri(std::move(clientAppUri)),
        clientAppName(std::move(clientAppName)),
        clientCertFilesPath(std::move(clientCertFilesPath)),
        expectedLdsUri(std::string(settings["lds-uri"].c_str())),
        onLdsData({
                          .filterServerName = "",
                          .callbackOnAnnounceOnly = false,
                          .onServerAnnounce = std::bind(&OpcUaServer::onServerAnnounce, this, std::placeholders::_1, std::placeholders::_1)
                  }),
        logger(std::move(_logger)) {
    loggerUaServer = logger->clone(logger->name() + "-ua-server");
    fortiss::log::LoggerFactory::setLoggerLevel(loggerUaServer, settings["logging"]["level"]["opcua"]);
    loggerUaClient = logger->clone(logger->name() + "-ua-client");
    fortiss::log::LoggerFactory::setLoggerLevel(loggerUaClient, settings["logging"]["level"]["opcua"]);

    serverConfig = (UA_ServerConfig*) UA_malloc(sizeof(UA_ServerConfig));
    if (!serverConfig) {
        logger->error("Can not create server config");
        throw std::runtime_error("Cannot create server config");
    }

    if (fortiss::opcua::initServerConfig(
            loggerUaServer,
            serverConfig,
            appUri,
            appName,
            (UA_UInt16) ((int) settings["opcua"]["port"]),
            settings["opcua"]["encryption"],
            settings["opcua"]["anonymous"],
            certFilesPath) != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Cannot initialize server config");
    }

    server = UA_Server_newWithConfig(serverConfig);
    if (!server) {
        logger->error("Can not create server instance");
        throw std::runtime_error("Cannot create server instance");
    }

}
#endif

OpcUaServer::OpcUaServer(
        std::shared_ptr<spdlog::logger> loggerApp,
        std::shared_ptr<spdlog::logger> loggerUaServer,
        std::shared_ptr<spdlog::logger> loggerUaClient,
        std::string clientAppUri,
        std::string clientAppName,
        std::string clientCertFilesPath,
        std::string expectedLdsUri,
        UA_ServerConfig* uaServerConfig
) :
        clientAppUri(std::move(clientAppUri)),
        clientAppName(std::move(clientAppName)),
        clientCertFilesPath(std::move(clientCertFilesPath)),
        expectedLdsUri(std::move(expectedLdsUri)),
        onLdsData({
                          .filterServerName = "",
                          .callbackOnAnnounceOnly = false,
                          .onServerAnnounce = std::bind(&OpcUaServer::onServerAnnounce, this, std::placeholders::_1, std::placeholders::_1)
                  }),
        logger(std::move(loggerApp)),
        loggerUaServer(std::move(loggerUaServer)),
        loggerUaClient(std::move(loggerUaClient)) {

    // this is not a deep copy, therefore the server config needs to persist outside of this method
    serverConfig = uaServerConfig;

    server = UA_Server_newWithConfig(serverConfig);
    if (!server) {
        logger->error("Can not create server instance");
        throw std::runtime_error("Cannot create server instance");
    }

}

OpcUaServer::~OpcUaServer() {

    std::lock_guard<std::recursive_mutex> lc(fortiss::opcua::serverMutex);
    // cppcheck-suppress knownConditionTrueFalse
    if (clientRegister != nullptr) {
        UA_StatusCode retval = UA_Server_unregister_discovery(server, clientRegister);
        if (retval != UA_STATUSCODE_GOOD) {
            logger->error("Can not unregister from discovery server: {}", UA_StatusCode_name(retval));
        }
        UA_Client_disconnect(clientRegister);
        UA_Client_delete(clientRegister);
    }

    if (server) {
        UA_Server_run_shutdown(server);
        UA_Server_delete(server);
    }
    UA_free(serverConfig);
}

UA_ServerConfig* OpcUaServer::getServerConfig() {
    // no need to lock here, the server config cannot be changed after Server is running
    return UA_Server_getConfig(server);
}

UA_StatusCode OpcUaServer::init(
        bool registerWithLds,
        const std::function<void(
                const UA_ServerOnNetwork*,
                UA_Boolean isServerAnnounce
        )>& _onServerAnnounceCallback
) {

    UA_StatusCode retval = UA_Server_run_startup(server);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Starting up the server failed with " + std::string(UA_StatusCode_name(retval)));
        return retval;
    }

    if (!registerWithLds)
        return UA_STATUSCODE_GOOD;

    this->onServerAnnounceCallback = _onServerAnnounceCallback;

    fortiss::opcua::UA_Server_onServerAnnounce(server, onLdsData);

    std::string endpoint;

    UA_ServerConfig* conf = UA_Server_getConfig(server);
    for (size_t i = 0; i < conf->networkLayersSize; i++) {
        if (!endpoint.empty())
            endpoint += ", ";
        endpoint += std::string((char*) conf->networkLayers[i].discoveryUrl.data, conf->networkLayers[i].discoveryUrl.length);
    }

    logger->info("OPC UA Server initialized: {}", endpoint);

    return UA_STATUSCODE_GOOD;
}

void OpcUaServer::iterate(bool waitInternal) {
    std::lock_guard<std::recursive_mutex> lc(fortiss::opcua::serverMutex);
    UA_Server_run_iterate(server, waitInternal);
}

LockedServer OpcUaServer::getLocked() {
    return LockedServer{server, fortiss::opcua::serverMutex};
}

void OpcUaServer::onServerAnnounce(
        const UA_ServerOnNetwork* serverOnNetwork,
        UA_Boolean isServerAnnounce
) {

    if (expectedLdsUri != "disabled" && strncmp((char*) serverOnNetwork->serverName.data, expectedLdsUri.c_str(),
                                                std::min(serverOnNetwork->serverName.length, expectedLdsUri.size())) == 0) {
        if (!isServerAnnounce && periodicCallbackId != 0) {
            logger->info("LDS Server {} shut down. Removing periodic register.", expectedLdsUri);
            // delete and stop periodic register
            UA_Server_removeRepeatedCallback(server, periodicCallbackId);
            periodicCallbackId = 0;
            currentLdsStartTime = 0;
            currentRegisteredLdsUri = "";
            currentLdsServerAnnounceTime = std::chrono::time_point<std::chrono::steady_clock>::min();
            UA_Client_disconnect(clientRegister);
            UA_Client_delete(clientRegister);
            clientRegister = nullptr;
            return;
        }

        if ((currentLdsServerAnnounceTime > std::chrono::time_point<std::chrono::steady_clock>::min()) &&
            (std::chrono::duration_cast<std::chrono::seconds>(std::chrono::steady_clock::now() - currentLdsServerAnnounceTime).count() < 5)) {
            // it could be the case that during startup the LDS announces itself multiple times.
            // To avoid that we create many periodic server register for the same LDS instance we ignore multiple announces within the first few
            // seconds.
            logger->debug("Ignore LDS Server announce {} as it was already announced recently.", expectedLdsUri);
            return;
        }

        UA_DateTime serverStartupTime;

        std::string clientCert = clientCertFilesPath.empty() ? "" : clientCertFilesPath + "_cert.der";
        std::string clientKey = clientCertFilesPath.empty() ? "" : clientCertFilesPath + "_key.der";
        UA_StatusCode retval = fortiss::opcua::UA_Client_getStartTime(
                logger,
                loggerUaClient,
                clientCert,
                clientKey,
                clientAppUri,
                clientAppName,
                serverOnNetwork,
                &serverStartupTime
        );
        if (retval != UA_STATUSCODE_GOOD) {
            logger->error("Could not read StartTime from LDS: {}", UA_StatusCode_name(retval));
            return;
        }

        if (serverStartupTime == 0) {
            logger->error("Did not get valid StarTime from LDS Server.");
            return;
        }

        if (!currentRegisteredLdsUri.empty()) {
            // we are already registered to an LDS. Check if this is the same LDS (compare startup time) or if it is a new one.

            if (serverStartupTime == currentLdsStartTime) {
                logger->debug("Already registered with LDS server {}. StartTime matches.", expectedLdsUri);
                currentLdsServerAnnounceTime = std::chrono::steady_clock::now();
                return;
            }

            logger->info("LDS server change detected. Removing old periodic register and creating new one.");

            // at this point we have a new LDS server and there's already a register setup. Stop that one and register with new LDS
            UA_Server_removeRepeatedCallback(server, periodicCallbackId);
            periodicCallbackId = 0;
            currentLdsStartTime = 0;
            currentRegisteredLdsUri = "";
            currentLdsServerAnnounceTime = std::chrono::time_point<std::chrono::steady_clock>::min();
            if (clientRegister) {
                UA_Client_disconnect(clientRegister);
                UA_Client_delete(clientRegister);
            }
            clientRegister = nullptr;
        }

        currentRegisteredLdsUri = expectedLdsUri;
        currentLdsStartTime = serverStartupTime;
        currentLdsServerAnnounceTime = std::chrono::steady_clock::now();

        if (periodicCallbackId != 0 && clientRegister) {
            // This case should never happen if previous checks correctly work and unregister before re-registering.
            throw std::runtime_error("Server is already registering!");
        }

        fortiss::opcua::UA_Server_setPeriodicRegister(
                server,
                logger,
                loggerUaClient,
                clientCert,
                clientKey,
                clientAppUri,
                clientAppName,
                serverOnNetwork,
                &periodicCallbackId,
                &clientRegister);
    } else if (onServerAnnounceCallback) {
        onServerAnnounceCallback(serverOnNetwork, isServerAnnounce);
    }
}
