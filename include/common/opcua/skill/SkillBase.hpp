/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_SKILL_BASE_H
#define ROBOTICS_COMMON_OPCUA_SKILL_BASE_H
#pragma once

#include <utility>
#include <future>
#include <memory>
#include <vector>
#include "common/opcua/Program.hpp"
#include "common/opcua/helper.hpp"
#include "SkillParameter.hpp"
#include "SkillImpl.hpp"

#include "fortiss_device_nodeids.h"


#define NAMESPACE_URI_FORTISS_DEVICE "https://fortiss.org/UA/Device/"

namespace fortiss {

    namespace opcua {
        namespace skill {

            class SkillBase : public Program {
            private:

                SkillImpl* impl = nullptr;
                std::function<void()> implDeleter = nullptr;

            public:
                explicit SkillBase(
                        const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                        const std::shared_ptr<spdlog::logger>& logger,
                        const UA_NodeId& skillNodeId,
                        const std::string& eventSourceName
                ) :
                        Program(logger,
                                generateStates(server),
                                generateTransitions(server),
                                server, skillNodeId, eventSourceName),
                        skillTransitionEventTypeId(UA_NODEID_NUMERIC(fortiss::opcua::UA_Server_getNamespaceIdByName(
                                server, NAMESPACE_URI_FORTISS_DEVICE), UA_FORTISS_DEVICEID_SKILLTRANSITIONEVENTTYPE)) {
                    // halted state location
                    currentState = &states[0];

                    // default value to avoid segfaults due to being null
                    lastTransition = &transitions[0];
                }

                ~SkillBase() override {
                    if (implDeleter != nullptr)
                        implDeleter();
                };

                bool transition(ProgramStateNumber nextState) override {
                    return Program::transition(nextState, skillTransitionEventTypeId);
                }

                SkillImpl* getImpl() const {
                    return this->impl;
                }

            protected:

                std::function<bool()> startCallback;
                std::function<bool()> resumeCallback;
                std::function<bool()> resetCallback;
                std::function<bool()> suspendCallback;
                std::function<bool()> haltCallback;

                void setImpl(
                        SkillImpl* i,
                        std::function<void()> deleter
                ) {
                    this->impl = i;
                    this->implDeleter = std::move(deleter);
                }


                const UA_NodeId skillTransitionEventTypeId;

                template<typename T>
                UA_StatusCode readParameter(
                        const SkillParameter<T>& parameter,
                        const std::function<void(const T&)>& set
                ) {
                    return readParameter<T, T, 1>(parameter, [set](
                            const T& x,
                            size_t index
                    ) {
                        set(x);
                    });
                }

                template<typename T, typename U>
                UA_StatusCode readParameter(
                        const SkillParameter<T>& parameter,
                        const std::function<void(const U&)>& set
                ) {
                    return readParameter<T, U, 1>(parameter, [set](
                            const U& x,
                            size_t index
                    ) {
                        set(x);
                    });
                }

                template<typename T, typename U, size_t COUNT>
                UA_StatusCode readParameter(
                        const SkillParameter<T>& parameter,
                        const std::function<void(
                                const U&,
                                size_t index
                        )>& set
                ) {
                    UA_Variant var;

                    {
                        LockedServer ls = server->getLocked();
                        UA_StatusCode retval = UA_Server_readValue(ls.get(), *parameter.nodeId,
                                                                   &var);
                        if (retval != UA_STATUSCODE_GOOD) {
                            logger->warn("Reading Parameter '{}' failed with {}",
                                         parameter.name, UA_StatusCode_name(retval));
                            return retval;
                        }
                    }
                    if (var.type == NULL) {
                        // parameter not set
                    } else {
                        if (COUNT > 1) {
                            // check if we got the correct array size
                            if (var.arrayLength != COUNT) {
                                logger->warn("Reading Parameter '{}' failed. Array length is not expected length: {}", parameter.name, COUNT);
                                UA_Variant_clear(&var);
                                return UA_STATUSCODE_BADINVALIDARGUMENT;
                            }
                        } else {
                            if (var.arrayLength > 1) {
                                logger->warn("Reading Parameter '{}' failed. Got value with array length, but expected scalar.", parameter.name);
                                UA_Variant_clear(&var);
                                return UA_STATUSCODE_BADINVALIDARGUMENT;
                            }
                        }

                        if (var.type == &UA_TYPES[UA_TYPES_EXTENSIONOBJECT]) {
                            const UA_ExtensionObject* extObj = static_cast<const UA_ExtensionObject*>(var.data);
                            if (extObj->encoding != UA_EXTENSIONOBJECT_DECODED) {
                                logger->warn("Reading Parameter '{}' failed. Recieved encoded ExtObj.", parameter.name);
                                UA_Variant_clear(&var);
                                return UA_STATUSCODE_BADINVALIDARGUMENT;
                            }

                            for (size_t idx = 0; idx < COUNT; idx++) {
                                if (extObj[idx].content.decoded.type != parameter.type) {
                                    logger->warn("Reading Parameter '{}' failed. Invalid value type.", parameter.name);
                                    UA_Variant_clear(&var);
                                    return UA_STATUSCODE_BADINVALIDARGUMENT;
                                }

                                const U* data = static_cast<const U*>(extObj[idx].content.decoded.data);
                                set(*data, idx);
                            }
                        } else {
                            if (var.type != parameter.type) {
                                logger->warn("Reading Parameter '{}' failed. Invalid value type.", parameter.name);
                                UA_Variant_clear(&var);
                                return UA_STATUSCODE_BADINVALIDARGUMENT;
                            }
                            const U* data = static_cast<const U*>(var.data);
                            for (size_t idx = 0; idx < COUNT; idx++) {
                                set(data[idx], idx);
                            }
                        }


                    }
                    UA_Variant_clear(&var);

                    return UA_STATUSCODE_GOOD;
                }


                virtual UA_StatusCode readParameters() = 0;

                UA_StatusCode startMethod(
                        const UA_NodeId* sessionId,
                        void* sessionHandle,
                        const UA_NodeId* methodId,
                        void* methodContext,
                        const UA_NodeId* objectId,
                        void* objectContext,
                        size_t inputSize,
                        const UA_Variant* input,
                        size_t outputSize,
                        UA_Variant* output
                ) override {
                    this->readParameters();

                    if (startCallback) {
                        bool success = startCallback();
                        if (!success) {
                            logger->error("startCallback returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }
                    return UA_STATUSCODE_GOOD;
                }

                UA_StatusCode resumeMethod(
                        const UA_NodeId* sessionId,
                        void* sessionHandle,
                        const UA_NodeId* methodId,
                        void* methodContext,
                        const UA_NodeId* objectId,
                        void* objectContext,
                        size_t inputSize,
                        const UA_Variant* input,
                        size_t outputSize,
                        UA_Variant* output
                ) override {
                    if (resumeCallback) {
                        bool success = resumeCallback();
                        if (!success) {
                            logger->error("resumeCallback returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }
                    return UA_STATUSCODE_GOOD;

                }

                UA_StatusCode resetMethod(
                        const UA_NodeId* sessionId,
                        void* sessionHandle,
                        const UA_NodeId* methodId,
                        void* methodContext,
                        const UA_NodeId* objectId,
                        void* objectContext,
                        size_t inputSize,
                        const UA_Variant* input,
                        size_t outputSize,
                        UA_Variant* output
                ) override {
                    if (resetCallback) {
                        bool success = resetCallback();
                        if (!success) {
                            logger->error("resetCallback returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }
                    return UA_STATUSCODE_GOOD;

                }

                UA_StatusCode haltMethod(
                        const UA_NodeId* sessionId,
                        void* sessionHandle,
                        const UA_NodeId* methodId,
                        void* methodContext,
                        const UA_NodeId* objectId,
                        void* objectContext,
                        size_t inputSize,
                        const UA_Variant* input,
                        size_t outputSize,
                        UA_Variant* output
                ) override {
                    if (haltCallback) {
                        bool success = haltCallback();
                        if (!success) {
                            logger->error("haltCallback returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }
                    return UA_STATUSCODE_GOOD;

                }

                UA_StatusCode suspendMethod(
                        const UA_NodeId* sessionId,
                        void* sessionHandle,
                        const UA_NodeId* methodId,
                        void* methodContext,
                        const UA_NodeId* objectId,
                        void* objectContext,
                        size_t inputSize,
                        const UA_Variant* input,
                        size_t outputSize,
                        UA_Variant* output
                ) override {
                    if (suspendCallback) {
                        bool success = suspendCallback();
                        if (!success) {
                            logger->error("suspendCallback returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }
                    return UA_STATUSCODE_GOOD;

                }

            private:
                static const std::vector<ProgramState> generateStates(const std::shared_ptr<fortiss::opcua::OpcUaServer>& server) {

                    LockedServer ls = server->getLocked();

                    return {ProgramState(ProgramStateNumber::HALTED,
                                         UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                        UA_QUALIFIEDNAME(0, const_cast<char*>("Halted"))),
                                         UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Halted"))),
                            ProgramState(ProgramStateNumber::READY,
                                         UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                        UA_QUALIFIEDNAME(0, const_cast<char*>("Ready"))),
                                         UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Ready"))),
                            ProgramState(ProgramStateNumber::RUNNING,
                                         UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                        UA_QUALIFIEDNAME(0, const_cast<char*>("Running"))),
                                         UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Running"))),
                            ProgramState(ProgramStateNumber::SUSPENDED,
                                         UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                        UA_QUALIFIEDNAME(0, const_cast<char*>("Suspended"))),
                                         UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Suspended")))};
                }

                static const std::vector<ProgramTransition>
                generateTransitions(const std::shared_ptr<fortiss::opcua::OpcUaServer>& server) {

                    LockedServer ls = server->getLocked();

                    return {ProgramTransition(ProgramTransitionNumber::HALTED_TO_READY,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("HaltedToReady"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Halted to Ready")),
                                              ProgramStateNumber::HALTED, ProgramStateNumber::READY),
                            ProgramTransition(ProgramTransitionNumber::READY_TO_RUNNING,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("ReadyToRunning"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Ready to Running")),
                                              ProgramStateNumber::READY, ProgramStateNumber::RUNNING),
                            ProgramTransition(ProgramTransitionNumber::RUNNING_TO_HALTED,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("RunningToHalted"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Running to Halted")),
                                              ProgramStateNumber::RUNNING, ProgramStateNumber::HALTED),
                            ProgramTransition(ProgramTransitionNumber::RUNNING_TO_READY,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("RunningToReady"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Running to Ready")),
                                              ProgramStateNumber::RUNNING, ProgramStateNumber::READY),
                            ProgramTransition(ProgramTransitionNumber::RUNNING_TO_SUSPENDED,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("RunningToSuspended"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"),
                                                               const_cast<char*>("Running to Suspended")),
                                              ProgramStateNumber::RUNNING, ProgramStateNumber::SUSPENDED),
                            ProgramTransition(ProgramTransitionNumber::SUSPENDED_TO_RUNNING,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("SuspendedToRunning"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"),
                                                               const_cast<char*>("Suspended to Running")),
                                              ProgramStateNumber::SUSPENDED, ProgramStateNumber::RUNNING),
                            ProgramTransition(ProgramTransitionNumber::SUSPENDED_TO_HALTED,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("SuspendedToHalted"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"),
                                                               const_cast<char*>("Suspended to Halted")),
                                              ProgramStateNumber::SUSPENDED, ProgramStateNumber::HALTED),
                            ProgramTransition(ProgramTransitionNumber::SUSPENDED_TO_READY,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("SuspendedToReady"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Suspended to Ready")),
                                              ProgramStateNumber::SUSPENDED, ProgramStateNumber::READY),
                            ProgramTransition(ProgramTransitionNumber::READY_TO_HALTED,
                                              UA_Server_getObjectComponentId(ls.get(), UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMSTATEMACHINETYPE),
                                                                             UA_QUALIFIEDNAME(0,
                                                                                              const_cast<char*>("ReadyToHalted"))),
                                              UA_LOCALIZEDTEXT(const_cast<char*>("en-US"), const_cast<char*>("Ready to Halted")),
                                              ProgramStateNumber::READY, ProgramStateNumber::HALTED)};
                }

            };


        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_SKILL_BASE_H
