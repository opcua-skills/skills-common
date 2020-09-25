/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_LOGGING_OPCUA_H
#define ROBOTICS_LOGGING_OPCUA_H
#pragma once


#ifdef UA_ENABLE_AMALGAMATION
#include <open62541.h>
#else
#include <open62541/plugin/log.h>
#endif
#include <spdlog/logger.h>

namespace fortiss {
    namespace log {
        namespace opcua {

            namespace {
                const char *LogsCategoryNames[7] = {"network", "channel", "session", "server", "client", "userland", "security_policy"};
            }

            inline void UA_Log_Spdlog_log(void *context, UA_LogLevel level, UA_LogCategory category, const char *msg, va_list args) {
                auto logger = (spdlog::logger*)context;
                char tmpStr[400];
                snprintf(tmpStr, 400, "[OPC UA/%s] ", LogsCategoryNames[category]);
                char *start = &tmpStr[strlen(tmpStr)];

                vsprintf(start, msg, args);

                size_t len = strlen(tmpStr);
                tmpStr[len] = '\0';

                switch (level) {
                    case UA_LOGLEVEL_TRACE:
                        logger->trace(tmpStr);
                        break;
                    case UA_LOGLEVEL_DEBUG:
                        logger->debug(tmpStr);
                        break;
                    case UA_LOGLEVEL_INFO:
                        logger->info(tmpStr);
                        break;
                    case UA_LOGLEVEL_WARNING:
                        logger->warn(tmpStr);
                        break;
                    case UA_LOGLEVEL_ERROR:
                    case UA_LOGLEVEL_FATAL:
                        logger->error(tmpStr);
                        break;
                }
            }

            inline void
            UA_Log_Spdlog_clear(void *logContext) {
            }
        }
    }
}


#endif //ROBOTICS_LOGGING_OPCUA_H
