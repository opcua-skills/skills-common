//
// Created by profanter on 11/29/18.
// Copyright (c) 2018 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_LOGGING_H
#define ROBOTICS_LOGGING_H
#pragma once

#include "spdlog/spdlog.h"
#include "spdlog/sinks/stdout_color_sinks.h"
#include "spdlog/sinks/rotating_file_sink.h"
#include "spdlog/sinks/basic_file_sink.h"
#include <map>
#include <limits.h>
#include <stdlib.h>
#include <iomanip>

namespace fortiss {
    namespace log {
        namespace {
            class LoggerFactory {
            public:
                static std::string GetCurrentTimeForFileName()
                {
                    auto time = std::time(nullptr);
                    std::stringstream ss;
                    ss << std::put_time(std::localtime(&time), "%F_%T"); // ISO 8601 without timezone information.
                    auto s = ss.str();
                    std::replace(s.begin(), s.end(), ':', '-');
                    return s;
                }

                static int mkpath(std::string s,mode_t mode)
                {
                    size_t pos=0;
                    std::string dir;
                    int mdret;

                    if(s[s.size()-1]!='/'){
                        // force trailing / so we can handle everything in loop
                        s+='/';
                    }

                    while((pos=s.find_first_of('/',pos))!=std::string::npos){
                        dir=s.substr(0,pos++);
                        if(dir.size()==0) continue; // if leading / first time is 0 length
                        if((mdret=mkdir(dir.c_str(),mode)) && errno!=EEXIST){
                            return mdret;
                        }
                    }
                    return mdret;
                }


                static std::shared_ptr<spdlog::logger> createLogger(const ::std::string &loggerName, const ::std::string &logFilePath = "") {

                    std::string logPath = "";
                    if (!logFilePath.empty()) {

                        std::string illegalChars = "\\/:?\"<>|";
                        std::string loggerNameSafe = loggerName;
                        for (auto it = loggerNameSafe.begin() ; it < loggerNameSafe.end() ; ++it){
                            bool found = illegalChars.find(*it) != std::string::npos;
                            if(found){
                                *it = '-';
                            }
                        }

                        logPath = logFilePath + "/" + GetCurrentTimeForFileName() + "-" + loggerNameSafe +  + ".log";
                        mkpath(logFilePath, 0700);
                        spdlog::flush_every(std::chrono::seconds(2));
                    }

                    // This other example use a single logger with multiple sinks.
                    // This means that the same log_msg is forwarded to multiple sinks;
                    // Each sink can have it's own log level and a message will be logged.
                    std::vector<spdlog::sink_ptr> sinks;
                    sinks.push_back(std::make_shared<spdlog::sinks::stdout_color_sink_mt>());
                    // create a thread safe sink which will keep its file size to a maximum of 6MB and a maximum of 3 rotated files.
                    if (!logPath.empty())
                        sinks.push_back( std::make_shared<spdlog::sinks::basic_file_sink_mt>(logPath) );
                    auto console_multisink = std::make_shared<spdlog::logger>(loggerName, sinks.begin(), sinks.end());
                    console_multisink->set_level(spdlog::level::info);
                    sinks[0]->set_level(spdlog::level::trace);  // console. Allow everything.  Default value
                    if (!logPath.empty())
                        sinks[1]->set_level( spdlog::level::trace);  //  regular file. Allow everything.  Default value
                    /*console_multisink.warn("warn: will print only on console and regular file");
                    if( enable_debug )
                    {
                        console_multisink.set_level( spdlog::level::debug); // level of the logger
                        sinks[1]->set_level( spdlog::level::debug);  // regular file
                        sinks[2]->set_level( spdlog::level::debug);  // debug file
                    }
                    console_multisink.debug("Debug: you should see this on console and both files");*/
                    console_multisink->set_pattern("[%D %H:%M:%S.%e] [%^%-8l%$] [%n] %v");
                    console_multisink->flush_on(spdlog::level::warn);
                    return console_multisink;
                }
            };
        }

        static std::shared_ptr<spdlog::logger> __attribute__ ((unused)) get(const ::std::string &loggerName) {
            auto logger = spdlog::get(loggerName);
            if (logger == nullptr) {
                return LoggerFactory::createLogger(loggerName);
            }
            return logger;
        }

    }
}

#endif //ROBOTICS_LOGGING_H
