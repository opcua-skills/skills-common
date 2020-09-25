/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_PROGRAMSTATE_H
#define ROBOTICS_COMMON_OPCUA_PROGRAMSTATE_H
#pragma once

#include <utility>
#include <map>
#include <memory>

#ifdef UA_ENABLE_AMALGAMATION
#include "open62541.h"
#else

#include <open62541/types.h>

#endif

namespace fortiss {

    namespace opcua {

        enum class ProgramStateNumber : UA_UInt32 {
            INVALID = 0,
            HALTED = 11,
            READY = 12,
            RUNNING = 13,
            SUSPENDED = 14
        };

        const std::map<ProgramStateNumber, std::string> ProgramStateName = {
                {ProgramStateNumber::INVALID,   "INVALID"},
                {ProgramStateNumber::HALTED,    "HALTED"},
                {ProgramStateNumber::READY,     "READY"},
                {ProgramStateNumber::RUNNING,   "RUNNING"},
                {ProgramStateNumber::SUSPENDED, "SUSPENDED"},
        };

        class ProgramState {
        public:
            ProgramState() = delete;

            explicit ProgramState(
                    const ProgramStateNumber number,
                    std::shared_ptr<UA_NodeId> id,
                    const UA_LocalizedText name
            )
                    : number(number), id(std::move(id)), name(name) {
            };

            const UA_LocalizedText getName() const { return name; };

            const UA_NodeId* getId() const { return id.get(); };

            const ProgramStateNumber getNumber() const { return number; };

        private:
            const ProgramStateNumber number;
            const std::shared_ptr<UA_NodeId> id;
            const UA_LocalizedText name;
        };
    }
}

#endif //ROBOTICS_COMMON_OPCUA_PROGRAMSTATE_H
