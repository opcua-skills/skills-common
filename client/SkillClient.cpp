//
// Created by profanter on 12/20/18.
// Copyright (c) 2018 fortiss GmbH. All rights reserved.
//

#include <string>
#include <stdexcept>
#include <common/client/SkillClient.h>
#include <memory>
#include <mutex>

#include <common/opcua/helper.hpp>
#include <common/logging_opcua.h>
#include <open62541/client.h>

#include <open62541/client_subscriptions.h>
#include <open62541/client_highlevel.h>
#include <open62541/client_config_default.h>
#include <open62541/util.h>


SkillClient::SkillClient(std::shared_ptr<spdlog::logger> loggerParam,
                         const std::string &serverURL,
                         UA_UInt16 nsIdxDi,
                         const UA_NodeId &_skillNodeId,
                         const std::string &username,
                         const std::string &password,
                         bool isParameterSetMandatory,
                         UA_Client *clientParam) :
        nsIdxDi(nsIdxDi), skillNodeId(), logger(std::move(loggerParam)), parameter(),serverURL(serverURL), receivedStatesMutex(), receivedStateAvailable(),
        running(false), subId(0), monId(0), username(username), password(password) {

    if (clientParam == NULL) {
        client = UA_Client_new();

        UA_ClientConfig *clientConfig = UA_Client_getConfig(client);
        UA_ClientConfig_setDefault(clientConfig);
        clientConfig->logger.log = fortiss::log::opcua::UA_Log_Spdlog_log;
        clientConfig->logger.context = logger.get();
        clientConfig->logger.clear = fortiss::log::opcua::UA_Log_Spdlog_clear;
    } else {
        client = clientParam;
    }

    skillNodeId = UA_NODEID_NULL;
    UA_NodeId_copy(&_skillNodeId, &this->skillNodeId);


    if (connect(false) != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Failed to connect to client");
    }

    if (nsIdxDi == 0) {
        UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_DI);
        UA_StatusCode retval = UA_Client_NamespaceGetIndex(client, &nsUri, &nsIdxDi);
        UA_String_clear(&nsUri);
        if (retval != UA_STATUSCODE_GOOD) {
            throw std::runtime_error("Failed get namespace index for DI Namespace." + std::string(UA_StatusCode_name(retval)));
        }
    }

    bool found;
    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(nsIdxDi,
                                                                               const_cast<char *>("ParameterSet")),
                                                              &parameterSetNodeId);
    if (!found) {
        if (isParameterSetMandatory) {
            throw std::runtime_error("Failed to find parameterSetNodeId");
        }
        parameterSetNodeId = UA_NODEID_NULL;
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Start")),
                                                              &startMethodId);
    if (!found) {
        throw std::runtime_error("Failed to find Start Method");
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Reset")),
                                                              &resetMethodId);
    if (!found) {
        throw std::runtime_error("Failed to find Reset Method");
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Suspend")),
                                                              &suspendMethodId);
    if (!found) {
        throw std::runtime_error("Failed to find Suspend Method");
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Resume")),
                                                              &resumeMethodId);
    if (!found) {
        throw std::runtime_error("Failed to find Resume Method");
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Halt")),
                                                              &haltMethodId);
    if (!found) {
        throw std::runtime_error("Failed to find Halt Method");
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("LastTransition")),
                                                              &lastTransitionNumberId);
    if (!found) {
        throw std::runtime_error("Failed to find LastTransition Node");
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("CurrentState")),
                                                              &currentStateId);
    if (!found) {
        throw std::runtime_error("Failed to find CurrentState Node");
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, currentStateId,
                                                              UA_QUALIFIEDNAME(0, const_cast<char*>("Number")),
                                                              &currentStateNumberId);
    if (!found) {
        throw std::runtime_error("Failed to find CurrentState.Number Node");
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                              UA_QUALIFIEDNAME(0,
                                                                               const_cast<char *>("FinalResultData")),
                                                              &finalResultDataNodeId);
    if (!found) {
        finalResultDataNodeId = UA_NODEID_NULL;
    }


    // TODO this only checks the first level children. Also call recursive
    fortiss::opcua::UA_Client_findChildrenWithReferenceType(client, logger, UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE),
                                                 UA_NODEID_NUMERIC(0,
                                                                   UA_NS0ID_HASSUBTYPE),
                                                 &stateTransitionEventTypes, &stateTransitionEventTypesCount);

}

SkillClient::~SkillClient() {
    stopThreaded();

    UA_Array_delete(stateTransitionEventTypes, stateTransitionEventTypesCount, &UA_TYPES[UA_TYPES_NODEID]);
    UA_Client_delete(client);
}

#define EVENT_FILTER_SELECT_COUNT 8

bool SkillClient::getEventFilter(UA_EventFilter *filter) {
    UA_EventFilter_init(filter);

    auto *selectClauses = (UA_SimpleAttributeOperand *)
            UA_Array_new(EVENT_FILTER_SELECT_COUNT, &UA_TYPES[UA_TYPES_SIMPLEATTRIBUTEOPERAND]);
    if (!selectClauses)
        return false;

    for (size_t i = 0; i < EVENT_FILTER_SELECT_COUNT; ++i) {
        UA_SimpleAttributeOperand_init(&selectClauses[i]);
    }

    selectClauses[0].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[0].browsePathSize = 1;
    selectClauses[0].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[0].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[0].browsePath) {
        UA_SimpleAttributeOperand_deleteMembers(selectClauses);
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[0].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[0].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "EventType");

    selectClauses[1].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[1].browsePathSize = 1;
    selectClauses[1].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[1].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[1].browsePath) {
        UA_SimpleAttributeOperand_deleteMembers(selectClauses);
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[1].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[1].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "Severity");

    selectClauses[2].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[2].browsePathSize = 1;
    selectClauses[2].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[2].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[2].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[2].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[2].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "Message");

    selectClauses[3].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[3].browsePathSize = 1;
    selectClauses[3].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[3].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[3].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[3].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[3].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "FromState");

    selectClauses[4].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[4].browsePathSize = 1;
    selectClauses[4].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[4].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[4].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[4].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[4].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "ToState");

    selectClauses[5].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[5].browsePathSize = 1;
    selectClauses[5].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[5].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[5].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[5].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[5].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "Transition");

    selectClauses[6].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[6].browsePathSize = 1;
    selectClauses[6].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[6].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[6].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[6].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[6].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "IntermediateResult");


    selectClauses[7].typeDefinitionId = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    selectClauses[7].browsePathSize = 1;
    selectClauses[7].browsePath = (UA_QualifiedName *)
            UA_Array_new(selectClauses[7].browsePathSize, &UA_TYPES[UA_TYPES_QUALIFIEDNAME]);
    if (!selectClauses[7].browsePath) {
        UA_SimpleAttributeOperand_delete(selectClauses);
        return false;
    }
    selectClauses[7].attributeId = UA_ATTRIBUTEID_VALUE;
    selectClauses[7].browsePath[0] = UA_QUALIFIEDNAME_ALLOC(0, "Time");

    filter->selectClauses = selectClauses;
    filter->selectClausesSize = EVENT_FILTER_SELECT_COUNT;

    return true;
}

void SkillClient::eventHandler(UA_UInt32 subId, UA_UInt32 monId, void *monContext, size_t nEventFields,
                               UA_Variant *eventFields) {
    if (nEventFields < 1)
        return;
    if (!UA_Variant_hasScalarType(&eventFields[0], &UA_TYPES[UA_TYPES_NODEID])) {
        // ignore if first event field is not of type nodeid
        logger->debug("Ignoring event. First event field is expected to be a NodeId, but is a {}", eventFields[0].type->typeName);
        return;
    }

    auto *eventType = (UA_NodeId *) eventFields[0].data;

    UA_NodeId programTransitionType = UA_NODEID_NUMERIC(0, UA_NS0ID_PROGRAMTRANSITIONEVENTTYPE);
    bool isValidEventType = UA_NodeId_equal(eventType, &programTransitionType);

    // also check for subtypes of program transition event type
    for (size_t i=0; i<stateTransitionEventTypesCount && !isValidEventType; i++) {
        isValidEventType = UA_NodeId_equal(eventType, &stateTransitionEventTypes[i]);
    }

    if (!isValidEventType) {
        UA_String nodeIdStr = UA_STRING_NULL;
        UA_NodeId_toString(eventType, &nodeIdStr);
        logger->warn("Ignoring event. It is not of type ProgramTransitionType, but {}", std::string((char *) nodeIdStr.data, (int) nodeIdStr.length));
        UA_String_deleteMembers(&nodeIdStr);
        return;
    }

    // i=1 is Severity, skip it for now

    if (nEventFields < EVENT_FILTER_SELECT_COUNT) {
        logger->warn("Ignoring event. Not all selected fields are returned");
        return;
    }

    // the other fields have to be of type localized text (see event filter above).
    for (size_t i = 2; i < 6; ++i) {
        if (!UA_Variant_hasScalarType(&eventFields[i], &UA_TYPES[UA_TYPES_LOCALIZEDTEXT])) {
            logger->warn("Expected event field to be of type LocalizedText, but got {} at field {}. Ignoring event.", eventFields[i].type->typeName, i);
            return;
        }
    }

    auto *message = (UA_LocalizedText *) eventFields[2].data;
    auto *fromState = (UA_LocalizedText *) eventFields[3].data;
    auto *toState = (UA_LocalizedText *) eventFields[4].data;
    auto *transition = (UA_LocalizedText *) eventFields[5].data;

    if (!UA_Variant_hasScalarType(&eventFields[7], &UA_TYPES[UA_TYPES_DATETIME])) {
        logger->warn("Expected event field to be of type DateTime, but got {} at field {}. Ignoring event.", eventFields[7].type->typeName, 7);
        return;
    }

    auto *time = (UA_DateTime *) eventFields[7].data;

    handleTransitionEvent(time, message, fromState, toState, transition);

}

void SkillClient::handleTransitionEvent(const UA_DateTime *time,
                                        const UA_LocalizedText *message,
                                        const UA_LocalizedText *fromState,
                                        const UA_LocalizedText *toState,
                                        const UA_LocalizedText *transition) {
    UA_DateTimeStruct dt = UA_DateTime_toStruct(*time);
    logger->warn("Received Transition: {} --- {} ---> {} at {:04d}-{:02d}-{:02d}T{:02d}:{:02d}:{:02d}.{:03d}{:03d}",
                 std::string((char *) fromState->text.data, (int) fromState->text.length),
                 std::string((char *) transition->text.data, (int) transition->text.length),
                 std::string((char *) toState->text.data, (int) toState->text.length),
                 dt.year,
                 dt.month,
                 dt.day,
                 dt.hour,
                 dt.min,
                 dt.sec,
                 dt.milliSec,
                 dt.microSec);

    // FIXME use hasCause reference instead of string matching
    fortiss::opcua::ProgramStateNumber newState;

    UA_String readyState = UA_STRING(const_cast<char*>("Ready"));
    UA_String haltedState = UA_STRING(const_cast<char*>("Halted"));
    UA_String runningState = UA_STRING(const_cast<char*>("Running"));
    UA_String suspendedState = UA_STRING(const_cast<char*>("Suspended"));

    // substates of FinishStateMachine.
    // TODO this is a dirty hack to quickly get substate machines mapped to the main states.
    // TODO the best approach would be to browse the substate machine and automatically detect the states.

    UA_String successState = UA_STRING(const_cast<char*>("Success"));
    UA_String forceExceeded = UA_STRING(const_cast<char*>("ForceExceeded"));


    if (UA_String_equal(&toState->text, &readyState))
        newState = fortiss::opcua::ProgramStateNumber::READY;
    else if (UA_String_equal(&toState->text, &haltedState))
        newState = fortiss::opcua::ProgramStateNumber::HALTED;
    else if (UA_String_equal(&toState->text, &runningState))
        newState = fortiss::opcua::ProgramStateNumber::RUNNING;
    else if (UA_String_equal(&toState->text, &suspendedState))
        newState = fortiss::opcua::ProgramStateNumber::SUSPENDED;
    else if (UA_String_equal(&toState->text, &successState))
        newState = fortiss::opcua::ProgramStateNumber::READY;
    else if (UA_String_equal(&toState->text, &forceExceeded))
        newState = fortiss::opcua::ProgramStateNumber::HALTED;
    else {
        logger->warn("Received invalid state: {}", std::string((char *) toState->text.data, (int) toState->text.length));
        return;
    }

    {
        std::lock_guard<std::mutex> lock(receivedStatesMutex);
        receivedStates.push(newState);
    }
    receivedStateAvailable.notify_one();
}


void SkillClient::eventHandlerCallback(UA_Client *client,
                                       UA_UInt32 subId, void *subContext,
                                       UA_UInt32 monId, void *monContext,
                                       size_t nEventFields, UA_Variant *eventFields) {
    if (!subContext)
        return;
    auto *self = static_cast<SkillClient *>(subContext);

    self->eventHandler(subId, monId, monContext, nEventFields, eventFields);
}

bool SkillClient::step(UA_UInt16 timeout) {
    if (UA_Client_getState(client) == UA_CLIENTSTATE_DISCONNECTED) {
        return true;
    }
    UA_StatusCode retVal;
    {
        std::lock_guard<std::mutex> lk(clientMutex);
        retVal = UA_Client_run_iterate(client, timeout);
    }
    if (retVal != UA_STATUSCODE_GOOD) {
        logger->error("Client_run_iterate error: {}", UA_StatusCode_name(retVal));
        return false;
    }
    return true;
}

UA_StatusCode SkillClient::connect(bool addSubscription) {
    if (UA_Client_getState(client) >= UA_CLIENTSTATE_SESSION) {
        UA_Client_run_iterate(client, 5);
        if (UA_Client_getState(client) >= UA_CLIENTSTATE_SESSION) {
            return UA_STATUSCODE_GOOD;
        }
    }

    UA_StatusCode retval;
    if (username.empty()) {
        if (!password.empty()) {
            logger->warn("Password provided but no user. Attempting to connect without login...");
        } else {
            logger->info("Attempting to connect without login...");
        }
        retval = UA_Client_connect(client, serverURL.c_str());
    } else {
        logger->info("Attempting to connect with username: {}", username);
        retval = UA_Client_connect_username(client, serverURL.c_str(), username.c_str(), password.c_str());
    }

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not connect to kb {}. Error {}", serverURL.c_str(), UA_StatusCode_name(retval));
        return retval;
    }

    logger->info("Connected");

    if (retval != UA_STATUSCODE_GOOD) {
    }
    if (addSubscription)
        addEventSubscription();
    return UA_STATUSCODE_GOOD;
}

void SkillClient::addEventSubscription() {

    if (subId != 0 && monId != 0)
        return;

    /* Create a subscription */
    UA_CreateSubscriptionRequest subRequest = UA_CreateSubscriptionRequest_default();
    UA_CreateSubscriptionResponse subResponse = UA_Client_Subscriptions_create(client, subRequest,
                                                                               this, nullptr, nullptr);
    if (subResponse.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        UA_Client_disconnect(client);
        UA_Client_delete(client);
        throw std::runtime_error(
                "Failed to create subscription, status code " +
                std::string(UA_StatusCode_name(subResponse.responseHeader.serviceResult)));
    }

    subId = subResponse.subscriptionId;

    /* Add a MonitoredItem */
    UA_MonitoredItemCreateRequest item;
    UA_MonitoredItemCreateRequest_init(&item);
    item.itemToMonitor.nodeId = skillNodeId;
    item.itemToMonitor.attributeId = UA_ATTRIBUTEID_EVENTNOTIFIER;
    item.monitoringMode = UA_MONITORINGMODE_REPORTING;

    item.requestedParameters.filter.encoding = UA_EXTENSIONOBJECT_DECODED;
    UA_EventFilter filter;
    if (!getEventFilter(&filter)) {
        throw std::runtime_error("Cannot create event filter");
    }
    item.requestedParameters.filter.content.decoded.data = &filter;
    item.requestedParameters.filter.content.decoded.type = &UA_TYPES[UA_TYPES_EVENTFILTER];
    // set a minimum queue size of > 2 so that we get all the events, if the robot already reached the position and sends
    // two events at the same time.
    item.requestedParameters.queueSize = 20;
    item.requestedParameters.discardOldest = true;

    UA_MonitoredItemCreateResult result =
            UA_Client_MonitoredItems_createEvent(client, subId,
                                                 UA_TIMESTAMPSTORETURN_BOTH, item,
                                                 nullptr, &SkillClient::eventHandlerCallback, nullptr);

    if (result.statusCode != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Failed to add MonitoredItem, status code " + std::string(UA_StatusCode_name(result.statusCode)));
    }

    monId = result.monitoredItemId;

    UA_MonitoredItemCreateResult_deleteMembers(&result);
    UA_Array_delete(filter.selectClauses, filter.selectClausesSize, &UA_TYPES[UA_TYPES_SIMPLEATTRIBUTEOPERAND]);
}

void SkillClient::removeEventSubscription() {
    if (subId == 0)
        return;
    UA_Client_Subscriptions_deleteSingle(client, subId);
    subId = 0;
    monId = 0;
}

UA_StatusCode SkillClient::disconnect() {
    return UA_Client_disconnect(client);
}

void SkillClient::threadWorker() {
    bool success = true;
    while (running && success) {
        success &= this->step(0);
        std::this_thread::sleep_for(std::chrono::milliseconds(1));
    }
    running = false;
}

void SkillClient::runThreaded() {
    if (running)
        return;
    this->connect();
    this->addEventSubscription();
    running = true;
    stepperThread = std::thread([&] { threadWorker(); });

}

void SkillClient::stopThreaded() {
    if (!running)
        return;
    running = false;
    stepperThread.join();
    removeEventSubscription();
    disconnect();
}

UA_StatusCode SkillClient::start() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client, skillNodeId, startMethodId, 0, nullptr, nullptr, nullptr);
}

UA_StatusCode SkillClient::reset() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client, skillNodeId, resetMethodId, 0, nullptr, nullptr, nullptr);
}

UA_StatusCode SkillClient::suspend() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client, skillNodeId, suspendMethodId, 0, nullptr, nullptr, nullptr);
}

UA_StatusCode SkillClient::resume() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client, skillNodeId, resumeMethodId, 0, nullptr, nullptr, nullptr);
}

UA_StatusCode SkillClient::halt() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client, skillNodeId, haltMethodId, 0, nullptr, nullptr, nullptr);
}

std::future<void>
SkillClient::resetWait() {
    emptyReceivedStates();
    std::promise<void> promiseWait;
    UA_StatusCode retval = reset();
    if (retval != UA_STATUSCODE_GOOD) {
        return fortiss::opcua::setPromiseErrorException<void>(&promiseWait, retval);
    }
    return std::async([this]() {
        fortiss::opcua::ProgramStateNumber newState = getNextState().get();
        if (newState != fortiss::opcua::ProgramStateNumber::READY) {
            logger->error("Did not change to expected Running state.");
            throw fortiss::opcua::StatusCodeException(UA_STATUSCODE_BADINVALIDSTATE);
        }
        return;
    });
}

UA_StatusCode SkillClient::readVariable(const UA_NodeId& node, UA_Variant* data) {
    UA_ReadRequest request;
    UA_ReadRequest_init(&request);
    request.nodesToReadSize = 1;
    request.nodesToRead = UA_ReadValueId_new();
    UA_ReadValueId_init(request.nodesToRead);
    UA_NodeId_copy(&node, &request.nodesToRead->nodeId);
    request.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse response;
    {
        std::lock_guard<std::mutex> lk(clientMutex);
        response = UA_Client_Service_read(client, request);
    }
    UA_ReadRequest_clear(&request);

    if (response.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        UA_ReadResponse_clear(&response);
        return response.responseHeader.serviceResult;
    }


    if (response.resultsSize != 1) {
        UA_ReadResponse_clear(&response);
        return UA_STATUSCODE_BADINVALIDSTATE;
    }

    UA_StatusCode retval = UA_Variant_copy(&response.results[0].value, data);
    UA_ReadResponse_clear(&response);
    return retval;
}

const fortiss::opcua::ProgramStateNumber SkillClient::getCurrentState() {

    UA_Variant var;
    UA_Variant_init(&var);
    UA_StatusCode retval = readVariable(currentStateNumberId, &var);
    if (retval != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Cannot read node: " + std::string(UA_StatusCode_name(retval)));
    }
    if (var.type != &UA_TYPES[UA_TYPES_UINT32]) {
        throw std::runtime_error("Cannot read node. Is not of type UInt32");
    }
    fortiss::opcua::ProgramStateNumber number = *(static_cast<fortiss::opcua::ProgramStateNumber *>(var.data));

    UA_Variant_clear(&var);
    return number;
}

const fortiss::opcua::ProgramTransitionNumber SkillClient::getLastTransition() {
    UA_ReadRequest request;
    UA_ReadRequest_init(&request);
    request.nodesToReadSize = 1;
    request.nodesToRead = UA_ReadValueId_new();
    UA_ReadValueId_init(request.nodesToRead);
    UA_NodeId_copy(&lastTransitionNumberId, &request.nodesToRead->nodeId);
    request.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse response;
    {
        std::lock_guard<std::mutex> lk(clientMutex);
        response = UA_Client_Service_read(client, request);
    }
    if (response.resultsSize != 1 || response.results->value.type != &UA_TYPES[UA_TYPES_UINT32]) {
        throw std::runtime_error("Cannot read node");
    }

    UA_ReadRequest_clear(&request);

    fortiss::opcua::ProgramTransitionNumber number = *(static_cast<fortiss::opcua::ProgramTransitionNumber *>(response.results->value.data));
    UA_ReadResponse_clear(&response);
    return number;
}

void SkillClient::emptyReceivedStates() {
    std::queue<fortiss::opcua::ProgramStateNumber>().swap(receivedStates);
}

std::future<fortiss::opcua::ProgramStateNumber> SkillClient::getNextState() {
    if (receivedStates.size() == 0) {

        // wait until we receive a new state
        return std::async([this]() {
            std::unique_lock<std::mutex> lock(receivedStatesMutex);
            receivedStateAvailable.wait(lock, [this]{
                return (receivedStates.size());
            });
            //after wait, we own the lock
            if (receivedStates.size()) {
                fortiss::opcua::ProgramStateNumber state = receivedStates.front();
                if (eventFoundCallback) {
                    eventFoundCallback(receivedStates.front());
                }
                receivedStates.pop();
                return state;
            }

            return fortiss::opcua::ProgramStateNumber::INVALID;
        });
    }
    std::promise<fortiss::opcua::ProgramStateNumber> promiseState;
    promiseState.set_value(receivedStates.front());
    if (eventFoundCallback) {
        eventFoundCallback(receivedStates.front());
    }
    receivedStates.pop();
    return promiseState.get_future();

}

void SkillClient::setEventFoundCallback(const std::function<bool(const fortiss::opcua::ProgramStateNumber)> &callback) {
    eventFoundCallback = callback;
}

UA_StatusCode SkillClient::writeParameter() {

    if (parameter.size() == 0)
        return UA_STATUSCODE_GOOD;

    UA_WriteRequest wReq;
    UA_WriteRequest_init(&wReq);

    wReq.nodesToWrite = (UA_WriteValue*) UA_Array_new(parameter.size(), &UA_TYPES[UA_TYPES_WRITEVALUE]);
    wReq.nodesToWriteSize = parameter.size();

    for (std::vector<SkillClientParameter*>::iterator it = parameter.begin() ; it != parameter.end(); ++it) {
        size_t idx = it - parameter.begin();
        SkillClientParameter *param = (*it);
        UA_NodeId_copy(param->nodeId.get(), &wReq.nodesToWrite[idx].nodeId);
        wReq.nodesToWrite[idx].attributeId = UA_ATTRIBUTEID_VALUE;
        wReq.nodesToWrite[idx].value.hasValue = true;
        UA_Variant_copy(&param->value, &wReq.nodesToWrite[idx].value.value);
    }


    UA_WriteResponse wResp;
    {
        std::lock_guard<std::mutex> lk(clientMutex);
        wResp = UA_Client_Service_write(client, wReq);
    }

    UA_StatusCode response = wResp.responseHeader.serviceResult;
    if (response != UA_STATUSCODE_GOOD) {
        logger->error("Failed to write parameters. {}", UA_StatusCode_name(wResp.responseHeader.serviceResult));
    } else if (wResp.resultsSize != parameter.size()) {
        logger->error("Failed to write parameters. Result size is not as expected");
        response = UA_STATUSCODE_BADINTERNALERROR;
    } else {
        for (std::vector<SkillClientParameter*>::iterator it = parameter.begin() ; it != parameter.end(); ++it) {
            size_t idx = it - parameter.begin();
            SkillClientParameter *param = (*it);
            if (wResp.results[idx] != UA_STATUSCODE_GOOD) {
                response = wResp.results[idx];
                logger->error("Failed to write parameter {}. {}", param->name, UA_StatusCode_name(response));
            }
        }
    }

    UA_WriteRequest_deleteMembers(&wReq);
    UA_WriteResponse_deleteMembers(&wResp);
    return response;
}

bool SkillClient::initParameter(SkillClientParameter** param, const std::string &name, const UA_QualifiedName &browseName) {

    UA_NodeId *foundId = UA_NodeId_new();

    bool found = fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, parameterSetNodeId,
                                                                   browseName,
                                                                   foundId);
    if (!found) {
        UA_NodeId_delete(foundId);
        return false;
    }

    *param = new SkillClientParameter(name, std::shared_ptr<UA_NodeId>(foundId, UA_NodeId_delete));

    parameter.push_back(*param);

    return true;
}


std::future<UA_StatusCode> SkillClient::getFinalResultData(const UA_String& resultData, UA_Variant *data) {
    return std::async([this, resultData, data]() {

        if (UA_NodeId_equal(&finalResultDataNodeId, &UA_NODEID_NULL))
            return UA_STATUSCODE_BADNODEIDINVALID;

        UA_NodeId finalResultDataId;
        bool found;

        {
            std::lock_guard<std::mutex> lk(clientMutex);
            found = fortiss::opcua::UA_Client_findChildWithName(client, logger, finalResultDataNodeId,
                                                                      resultData,
                                                                      &finalResultDataId);
        }

        if (!found) {
            return UA_STATUSCODE_BADNODEIDUNKNOWN;
        }

        return readVariable(finalResultDataId, data);
    });
}

