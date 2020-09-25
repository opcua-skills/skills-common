/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_FINITESTATEMACHINE_HPP
#define ROBOTICS_FINITESTATEMACHINE_HPP

#include "ProgramState.hpp"
#include "ProgramTransition.hpp"

#include <common/opcua/helper.hpp>
#include <common/opcua/server/OpcUaServer.h>

#ifdef UA_ENABLE_AMALGAMATION
#include "open62541.h"
#else

#include <open62541/server.h>

#endif


namespace fortiss {

    namespace opcua {

        class FiniteStateMachine {
        public:
            explicit FiniteStateMachine(
                    std::shared_ptr<spdlog::logger> logger,
                    std::vector<ProgramState> states,
                    std::vector<ProgramTransition> transitions,
                    std::shared_ptr<fortiss::opcua::OpcUaServer> server,
                    const UA_NodeId& stateMachineNodeId,
                    std::string eventSourceName
            )
                    : server(std::move(server)), logger(std::move(logger)), states(std::move(states)),
                      transitions(std::move(transitions)),
                      stateMachineNodeId(stateMachineNodeId),
                      eventSourceName(std::move(eventSourceName)) {

                if (this->states.empty()) {
                    throw std::runtime_error("Got empty state array");
                }

                if (this->transitions.empty()) {
                    throw std::runtime_error("Got empty transitions array");
                }

                UA_StatusCode retval = addDataSources();
                if (retval != UA_STATUSCODE_GOOD) {
                    throw std::runtime_error("Failed to add data sources with error: "
                                             + std::string(UA_StatusCode_name(retval)));
                }

                // default initialization
                currentState = &this->states[0];
                // default value to avoid segfaults due to being null
                lastTransition = &this->transitions[0];
            }

            virtual ~FiniteStateMachine() = default;

            const ProgramState* getCurrentState() const { return currentState; }

            const ProgramTransition* getLastTransition() const { return lastTransition; }

            virtual bool transition(ProgramStateNumber nextState) = 0;


            bool transition(
                    ProgramStateNumber nextState,
                    const UA_NodeId& eventType
            ) {
                return transition(*currentState, nextState, eventType);
            }

            bool transition(
                    const ProgramState& from,
                    ProgramStateNumber nextState,
                    const UA_NodeId& eventType
            ) {

                std::lock_guard<std::mutex> lock(transitionMutex);

                // get the next transition
                auto nextTransition = std::find_if(transitions.cbegin(), transitions.cend(),
                                                   [from, nextState](auto i) {
                                                       return i.getFrom() == from.getNumber() &&
                                                              i.getTo() == nextState;
                                                   });

                // no proper transition found
                if (nextTransition == transitions.cend()) {
                    logger->warn("Unable to transition: No transition from {} to {}",
                                 ProgramStateName.at(currentState->getNumber()),
                                 ProgramStateName.at(nextState));
                    return false;
                }

                // set the current state
                // If the next state is not in the states vector, then we are transitioning from inside
                // a substatemachine to outside, so keep the current state
                for (const auto& state : states) {
                    if (state.getNumber() == nextTransition->getTo()) {
                        currentState = &state;
                    }
                }

                lastTransition = &*nextTransition;
                return triggerTransitionEvent(from, eventType) == UA_STATUSCODE_GOOD;
            }

            static UA_StatusCode readCurrentStateId(
                    UA_Server* server,
                    const UA_NodeId* sessionId,
                    void* sessionContext,
                    const UA_NodeId* nodeId,
                    void* nodeContext,
                    UA_Boolean sourceTimeStamp,
                    const UA_NumericRange* range,
                    UA_DataValue* dataValue
            ) {
                if (!nodeContext)
                    return UA_STATUSCODE_BADINTERNALERROR;
                auto* self = static_cast<FiniteStateMachine*>(nodeContext);
                const UA_NodeId* stateId = self->getCurrentState()->getId();
                UA_Variant_setScalarCopy(&dataValue->value, stateId, &UA_TYPES[UA_TYPES_NODEID]);
                dataValue->hasValue = true;
                return UA_STATUSCODE_GOOD;
            }

            static UA_StatusCode readCurrentState(
                    UA_Server* server,
                    const UA_NodeId* sessionId,
                    void* sessionContext,
                    const UA_NodeId* nodeId,
                    void* nodeContext,
                    UA_Boolean sourceTimeStamp,
                    const UA_NumericRange* range,
                    UA_DataValue* dataValue
            ) {
                if (!nodeContext)
                    return UA_STATUSCODE_BADINTERNALERROR;
                auto* self = static_cast<FiniteStateMachine*>(nodeContext);
                auto stateName = self->getCurrentState()->getName();
                UA_Variant_setScalarCopy(&dataValue->value, &stateName, &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);
                dataValue->hasValue = true;
                return UA_STATUSCODE_GOOD;
            }

            static UA_StatusCode readLastTransition(
                    UA_Server* server,
                    const UA_NodeId* sessionId,
                    void* sessionContext,
                    const UA_NodeId* nodeId,
                    void* nodeContext,
                    UA_Boolean sourceTimeStamp,
                    const UA_NumericRange* range,
                    UA_DataValue* dataValue
            ) {
                if (!nodeContext)
                    return UA_STATUSCODE_BADINTERNALERROR;
                auto* self = static_cast<FiniteStateMachine*>(nodeContext);
                auto transitionName = self->getLastTransition()->getName();
                UA_Variant_setScalarCopy(&dataValue->value, &transitionName, &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);
                dataValue->hasValue = true;
                return UA_STATUSCODE_GOOD;
            }

            static UA_StatusCode readLastTransitionId(
                    UA_Server* server,
                    const UA_NodeId* sessionId,
                    void* sessionContext,
                    const UA_NodeId* nodeId,
                    void* nodeContext,
                    UA_Boolean sourceTimeStamp,
                    const UA_NumericRange* range,
                    UA_DataValue* dataValue
            ) {
                if (!nodeContext)
                    return UA_STATUSCODE_BADINTERNALERROR;
                auto* self = static_cast<FiniteStateMachine*>(nodeContext);
                const UA_NodeId* transitionId = self->getLastTransition()->getId();
                UA_Variant_setScalarCopy(&dataValue->value, transitionId, &UA_TYPES[UA_TYPES_NODEID]);
                dataValue->hasValue = true;
                return UA_STATUSCODE_GOOD;
            }

        protected:
            std::shared_ptr<fortiss::opcua::OpcUaServer> server;
            std::shared_ptr<spdlog::logger> logger;
            const std::vector<ProgramState> states;
            const std::vector<ProgramTransition> transitions;
            ProgramState const* currentState = nullptr;
            ProgramTransition const* lastTransition = nullptr;
            const UA_NodeId stateMachineNodeId;

            virtual void fillTransitionEvent(const UA_NodeId& eventId) const {}


        private:
            std::string eventSourceName;
            std::mutex transitionMutex;

            void fillTransitionEventBase(
                    const UA_NodeId& eventId,
                    const ProgramState& fromState
            ) const {
                UA_UInt16 eventSeverity = 200;

                LockedServer ls = server->getLocked();

                UA_Server_writeObjectProperty_scalar(ls.get(), eventId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("Severity")),
                                                     &eventSeverity,
                                                     &UA_TYPES[UA_TYPES_UINT16]);

                const UA_String evtSourceName = UA_STRING(const_cast<char*>(eventSourceName.c_str()));
                UA_Server_writeObjectProperty_scalar(ls.get(), eventId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("SourceName")),
                                                     &evtSourceName,
                                                     &UA_TYPES[UA_TYPES_STRING]);

                const std::string tmpMessage =
                        "Transition " + std::string((const char*) getLastTransition()->getName().text.data);
                const UA_LocalizedText eventMessage = UA_LOCALIZEDTEXT(const_cast<char*>("en-US"),
                                                                       const_cast<char*>(tmpMessage.c_str()));
                UA_Server_writeObjectProperty_scalar(ls.get(), eventId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("Message")),
                                                     &eventMessage,
                                                     &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);

                const UA_DateTime time = UA_DateTime_now();
                UA_Server_writeObjectProperty_scalar(ls.get(), eventId, UA_QUALIFIEDNAME(0, const_cast<char*>("Time")),
                                                     &time, &UA_TYPES[UA_TYPES_DATETIME]);

                // FromState is a component, so we can't use UA_Server_writeObjectPropertyScalar
                UA_Variant value;
                UA_Variant_init(&value);
                auto fromStateName = fromState.getName();
                UA_Variant_setScalarCopy(&value, &fromStateName, &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);

                UA_RelativePathElement rpe;
                UA_RelativePathElement_init(&rpe);

                rpe.targetName = UA_QUALIFIEDNAME(0, const_cast<char*>("FromState"));
                rpe.referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);

                UA_BrowsePath bp;
                UA_BrowsePath_init(&bp);
                bp.relativePath.elements = &rpe;
                bp.relativePath.elementsSize = 1;
                bp.startingNode = eventId;

                UA_BrowsePathResult bpr = UA_Server_translateBrowsePathToNodeIds(ls.get(), &bp);
                UA_Server_writeValue(ls.get(), bpr.targets[0].targetId.nodeId, value);
                UA_Variant_clear(&value);

                // Use the NodeId while we still have it to write the FromStateId
                const UA_NodeId* fromStateId = fromState.getId();
                UA_Server_writeObjectProperty_scalar(ls.get(), bpr.targets[0].targetId.nodeId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("Id")),
                                                     fromStateId, &UA_TYPES[UA_TYPES_NODEID]);

                // ToState
                UA_LocalizedText toStateName = currentState->getName();
                UA_Variant_setScalarCopy(&value, &toStateName, &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);

                rpe.targetName = UA_QUALIFIEDNAME(0, const_cast<char*>("ToState"));
                UA_BrowsePathResult_clear(&bpr);
                bpr = UA_Server_translateBrowsePathToNodeIds(ls.get(), &bp);
                UA_Server_writeValue(ls.get(), bpr.targets[0].targetId.nodeId, value);
                UA_Variant_clear(&value);

                // Use the NodeId while we still have it to write the ToStateId
                const UA_NodeId* toStateId = currentState->getId();
                UA_Server_writeObjectProperty_scalar(ls.get(), bpr.targets[0].targetId.nodeId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("Id")),
                                                     toStateId, &UA_TYPES[UA_TYPES_NODEID]);

                // Transition
                UA_LocalizedText transitionName = lastTransition->getName();
                UA_Variant_setScalarCopy(&value, &transitionName, &UA_TYPES[UA_TYPES_LOCALIZEDTEXT]);

                rpe.targetName = UA_QUALIFIEDNAME(0, const_cast<char*>("Transition"));

                UA_BrowsePathResult_clear(&bpr);
                bpr = UA_Server_translateBrowsePathToNodeIds(ls.get(), &bp);
                UA_Server_writeValue(ls.get(), bpr.targets[0].targetId.nodeId, value);
                UA_Variant_clear(&value);

                // Use the NodeId while we still have it write the TransitionId
                const UA_NodeId* transitionId = lastTransition->getId();
                UA_Server_writeObjectProperty_scalar(ls.get(), bpr.targets[0].targetId.nodeId,
                                                     UA_QUALIFIEDNAME(0, const_cast<char*>("Id")),
                                                     transitionId, &UA_TYPES[UA_TYPES_NODEID]);

                UA_BrowsePathResult_clear(&bpr);
            }

            UA_StatusCode
            triggerTransitionEvent(
                    const ProgramState& fromState,
                    const UA_NodeId& eventType
            ) const {
                UA_NodeId eventId;

                {
                    LockedServer ls = server->getLocked();
                    UA_StatusCode retval = UA_Server_createEvent(ls.get(), eventType, &eventId);
                    if (retval != UA_STATUSCODE_GOOD) {
                        logger->warn("createEvent failed. StatusCode {}", UA_StatusCode_name(retval));
                        return retval;
                    }

                }
                fillTransitionEventBase(eventId, fromState);
                fillTransitionEvent(eventId);
                {
                    LockedServer ls = server->getLocked();
                    UA_StatusCode retval = UA_Server_triggerEvent(ls.get(), eventId, stateMachineNodeId, nullptr, UA_TRUE);
                    if (retval != UA_STATUSCODE_GOOD) {
                        logger->warn("triggerEvent failed. StatusCode {}", UA_StatusCode_name(retval));
                        return retval;
                    }
                }

                return UA_STATUSCODE_GOOD;
            }

            UA_StatusCode addDataSources() {

                LockedServer ls = server->getLocked();
                auto retval = UA_Server_setNodeContext(ls.get(), stateMachineNodeId, this);
                if (retval != UA_STATUSCODE_GOOD) {
                    return retval;
                }


                UA_DataSource dataSource{};
                dataSource.write = nullptr;
                dataSource.read = &FiniteStateMachine::readCurrentState;
                std::shared_ptr<UA_NodeId> currentStateNodeId =
                        UA_Server_getObjectComponentId(ls.get(), stateMachineNodeId,
                                                       UA_QUALIFIEDNAME(0, const_cast<char*>("CurrentState")));
                UA_Server_setNodeContext(ls.get(), *currentStateNodeId, this);
                retval = UA_Server_setVariableNode_dataSource(ls.get(), *currentStateNodeId,
                                                              dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    return retval;
                }

                dataSource.read = FiniteStateMachine::readCurrentStateId;
                std::shared_ptr<UA_NodeId> currentStateIdNodeId =
                        UA_Server_getObjectPropertyId(ls.get(), *currentStateNodeId,
                                                      UA_QUALIFIEDNAME(0, const_cast<char*>("Id")));
                UA_Server_setNodeContext(ls.get(), *currentStateIdNodeId, this);
                retval = UA_Server_setVariableNode_dataSource(ls.get(),
                                                              *currentStateIdNodeId,
                                                              dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    return retval;
                }

                // LastTransition is optional for FiniteStateMachines
                std::shared_ptr<UA_NodeId> lastTransitionNodeId =
                        UA_Server_getObjectComponentId_or_Null(ls.get(), stateMachineNodeId,
                                                               UA_QUALIFIEDNAME(0, const_cast<char*>("LastTransition")));

                if (!lastTransitionNodeId) {
                    return UA_STATUSCODE_GOOD;
                }
                dataSource.read = FiniteStateMachine::readLastTransition;
                UA_Server_setNodeContext(ls.get(), *lastTransitionNodeId, this);
                retval = UA_Server_setVariableNode_dataSource(ls.get(), *lastTransitionNodeId,
                                                              dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    return retval;
                }

                dataSource.read = FiniteStateMachine::readLastTransitionId;
                std::shared_ptr<UA_NodeId> lastTransitionIdNodeId =
                        UA_Server_getObjectPropertyId(ls.get(), *lastTransitionNodeId,
                                                      UA_QUALIFIEDNAME(0, const_cast<char*>("Id")));
                UA_Server_setNodeContext(ls.get(), *lastTransitionIdNodeId, this);
                retval = UA_Server_setVariableNode_dataSource(ls.get(), *lastTransitionIdNodeId,
                                                              dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    return retval;
                }
                return retval;
            }
        };
    }
}


#endif //ROBOTICS_FINITESTATEMACHINE_HPP
