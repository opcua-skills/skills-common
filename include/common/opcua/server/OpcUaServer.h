/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef FORTISS_ROBOTICS_OPCUASERVER_H
#define FORTISS_ROBOTICS_OPCUASERVER_H

#ifdef UA_ENABLE_AMALGAMATION
#include "open62541.h"
#else

#include <open62541/server.h>

#endif

#include <spdlog/logger.h>

#ifndef ESP_PLATFORM
#include <libconfig.h++>
#endif

#include <common/synchronized.hpp>

// use recursive mutex to allow multiple locks within the same thread, but not between different threads
typedef locked_ptr<UA_Server, std::recursive_mutex> LockedServer;
typedef synchronized<UA_Server> MutexedServer;

namespace fortiss {

    namespace opcua {

        struct serverOnNetworkCallbackData {
            const std::string filterServerName;
            const bool callbackOnAnnounceOnly;
            std::function<void(
                    const UA_ServerOnNetwork*,
                    UA_Boolean isServerAnnounce
            )> onServerAnnounce;
        };

        class OpcUaServer {
        private:

            const std::string clientAppUri;
            const std::string clientAppName;
            const std::string clientCertFilesPath;
            const std::string expectedLdsUri;

            UA_Client* clientRegister = nullptr;
            UA_UInt64 periodicCallbackId = 0;
            const struct fortiss::opcua::serverOnNetworkCallbackData onLdsData;
            std::string currentRegisteredLdsUri = "";
            UA_DateTime currentLdsStartTime = 0;
            std::chrono::time_point<std::chrono::steady_clock> currentLdsServerAnnounceTime = std::chrono::time_point<std::chrono::steady_clock>::min();
            std::function<void(
                    const UA_ServerOnNetwork*,
                    UA_Boolean
            )> onServerAnnounceCallback = nullptr;

        protected:
            std::shared_ptr<spdlog::logger> logger;
            std::shared_ptr<spdlog::logger> loggerUaServer;
            std::shared_ptr<spdlog::logger> loggerUaClient;


            UA_Server* server = nullptr;

            UA_ServerConfig* serverConfig = nullptr;

            void onServerAnnounce(
                    const UA_ServerOnNetwork* serverOnNetwork,
                    UA_Boolean isServerAnnounce
            );

        public:
#ifndef ESP_PLATFORM
            explicit OpcUaServer(
                    const libconfig::Setting& settings,
                    std::shared_ptr<spdlog::logger> logger,
                    const std::string& appUri,
                    const std::string& appName,
                    const std::string& certFilesPath,
                    std::string clientAppUri,
                    std::string clientAppName,
                    std::string clientCertFilesPath = ""
            );
#endif

            explicit OpcUaServer(
                    std::shared_ptr<spdlog::logger> loggerApp,
                    std::shared_ptr<spdlog::logger> loggerUaServer,
                    std::shared_ptr<spdlog::logger> loggerUaClient,
                    std::string clientAppUri,
                    std::string clientAppName,
                    std::string clientCertFilesPath,
                    std::string expectedLdsUri,
                    UA_ServerConfig* uaServerConfig
            );

            virtual ~OpcUaServer();

            UA_ServerConfig* getServerConfig();

            UA_StatusCode init(
                    bool registerWithLds = true,
                    const std::function<void(
                            const UA_ServerOnNetwork*,
                            UA_Boolean isServerAnnounce
                    )>& onServerAnnounce = nullptr
            );

            void iterate(bool waitInternal = false);

            LockedServer getLocked();
        };
    }
}


#endif //FORTISS_ROBOTICS_OPCUASERVER_H
