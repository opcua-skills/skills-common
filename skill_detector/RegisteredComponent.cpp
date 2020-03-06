//
// Created by profanter on 05/09/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/skill_detector/RegisteredComponent.h>
#include <open62541/client_subscriptions.h>
#include <common/opcua/helper.hpp>
#include <open62541/client_highlevel.h>
#include <di_nodeids.h>
#include <for_rob_nodeids.h>
#include <rob_nodeids.h>

RegisteredComponent::~RegisteredComponent() {
    monitorOnlineStop();

    disconnectClient();
}

bool RegisteredComponent::monitorOnline(std::chrono::milliseconds checkInterval) {
    if (this->monitorThreadRunning)
        return false;
    if (checkInterval.count() <= 0)
        return false;
    if (!this->client.data().get())
        return false;

    if (!createServerStateSubscription(checkInterval)) {
        return false;
    }

    this->monitorThreadRunning = true;
    long interval = checkInterval.count();

    this->monitorOnlineThread = std::thread([&, interval]() {


        while(this->monitorThreadRunning) {
            if (!this->checkOnline(std::chrono::milliseconds(interval))) {
                if (this->offlineCallback)
                    this->offlineCallback();
                break;
            }
            std::this_thread::sleep_for(std::chrono::milliseconds(interval));
        }
        this->monitorThreadRunning = false;
    });
    return true;
}

void RegisteredComponent::monitorOnlineStop() {
    if (!this->monitorThreadRunning)
        return;

    this->monitorThreadRunning = false;

    if (subId == 0)
        return;
    {
        LockedClient lc = this->getLockedClient();
        UA_Client_Subscriptions_deleteSingle(lc.get(), subId);
    }
    subId = 0;
    monId = 0;
}

bool RegisteredComponent::createServerStateSubscription(std::chrono::milliseconds checkInterval) {
    if (subId != 0 || monId != 0)
        return false;

    /* Create a subscription */
    UA_CreateSubscriptionRequest subRequest = UA_CreateSubscriptionRequest_default();
    subRequest.requestedPublishingInterval = checkInterval.count();
    subRequest.maxNotificationsPerPublish = 1;
    UA_CreateSubscriptionResponse subResponse;
    {
        LockedClient lc = this->getLockedClient();
        subResponse = UA_Client_Subscriptions_create(lc.get(), subRequest,
                                                                                   this, nullptr, nullptr);
    }
    if (subResponse.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        logger->error("Failed to create monitor-online subscription: {}", UA_StatusCode_name(subResponse.responseHeader.serviceResult));
        return false;
    }

    subId = subResponse.subscriptionId;

    /* Add a MonitoredItem */
    UA_MonitoredItemCreateRequest item =
            UA_MonitoredItemCreateRequest_default(UA_NODEID_NUMERIC(0, UA_NS0ID_SERVER_SERVERSTATUS_CURRENTTIME));
    item.requestedParameters.samplingInterval = checkInterval.count();
    UA_MonitoredItemCreateResult result;
    {
        LockedClient lc = this->getLockedClient();
        result =
                UA_Client_MonitoredItems_createDataChange(lc.get(), subResponse.subscriptionId,
                                                          UA_TIMESTAMPSTORETURN_BOTH,
                                                          item, NULL, RegisteredComponent::handler_TimeChanged, NULL);
    }

    if (result.statusCode != UA_STATUSCODE_GOOD) {
        logger->error("Failed to add MonitoredItem, status code {}", UA_StatusCode_name(result.statusCode));
        return false;
    }

    monId = result.monitoredItemId;

    UA_MonitoredItemCreateResult_deleteMembers(&result);

    return true;
}


void RegisteredComponent::handler_TimeChanged(UA_Client *client, UA_UInt32 subId, void *subContext,
                                UA_UInt32 monId, void *monContext, UA_DataValue *value) {
    if (!subContext)
        return;

    RegisteredComponent *self = static_cast<RegisteredComponent*>(subContext);
    self->lastTimeUpdate = std::chrono::steady_clock::now();
}

bool RegisteredComponent::checkOnline(std::chrono::milliseconds checkInterval) {
    if (!this->client.data().get())
        return false;
    if (subId == 0 || monId == 0)
        return false;

    LockedClient lc = this->getLockedClient();

    if (UA_Client_getState(lc.get()) == UA_CLIENTSTATE_DISCONNECTED) {
        return false;
    }
    UA_StatusCode retVal;
    retVal = UA_Client_run_iterate(lc.get(), 0);
    if (retVal != UA_STATUSCODE_GOOD) {
        logger->error("Client_run_iterate error: {}", UA_StatusCode_name(retVal));
        return false;
    }

    double diff = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::steady_clock::now() - lastTimeUpdate).count();
    return diff < checkInterval.count() * 1.5;
}

void RegisteredComponent::disconnectClient() {
    if (clientUnsafe) {
        UA_Client_disconnect(clientUnsafe);
        UA_Client_delete(clientUnsafe);
    }
    clientUnsafe = nullptr;
    this->client = MutexedClient(nullptr);
}

bool RegisteredComponent::connectClient() {
    if (clientUnsafe)
        return true;

    clientUnsafe = fortiss::opcua::UA_Helper_getClientForEndpoint(
            endpoint.get(),
            logger,
            clientCertPath,
            clientKeyPath,
            clientAppUri,
            clientAppName
    );

    client = MutexedClient(clientUnsafe);

    UA_StatusCode retval = UA_Client_connect(client.data().get(), endpointUrl.c_str());
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not connect to {}: {}", endpointUrl, UA_StatusCode_name(retval));
        UA_Client_delete(client.data().get());
        client.data() = nullptr;
        return false;
    }

    return true;
}


UA_StatusCode RegisteredComponent::getWorldToRobotTransform(rl::math::Transform *transform) {
    std::lock_guard<std::mutex> lk(worldToRobotTransformMutex);
    if (worldToRobotTransform) {
        *transform = *worldToRobotTransform;
        return UA_STATUSCODE_GOOD;
    }

    UA_Variant worldToRobotVar;
    UA_Variant_init(&worldToRobotVar);
    {
        LockedClient lc = this->getLockedClient();

        UA_UInt16 nsRobIdx;
        {
            UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_ROB);
            UA_StatusCode retval = UA_Client_NamespaceGetIndex(lc.get(), &nsUri, &nsRobIdx);
            UA_String_clear(&nsUri);
            if (retval != UA_STATUSCODE_GOOD) {
                logger->error("Can not get namespace index of {} from {}: {}", NAMESPACE_URI_ROB, this->endpointUrl, UA_StatusCode_name(retval));
                return retval;
            }
        }
        UA_UInt16 nsForRobIdx;
        {
            UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_FOR_ROB);
            UA_StatusCode retval = UA_Client_NamespaceGetIndex(lc.get(), &nsUri, &nsForRobIdx);
            UA_String_clear(&nsUri);
            if (retval != UA_STATUSCODE_GOOD) {
                logger->error("Can not get namespace index of {} from {}: {}", NAMESPACE_URI_FOR_ROB, this->endpointUrl, UA_StatusCode_name(retval));
                return retval;
            }
        }

        UA_NodeId motionSystemId;
        UA_NodeId deviceSetNodeId = UA_NODEID_NUMERIC(this->nsDiIdx, UA_DIID_DEVICESET);
        if (!fortiss::opcua::UA_Client_findChildOfType(lc.get(), logger, deviceSetNodeId,
                                                       UA_NODEID_NUMERIC(nsRobIdx, UA_ROBID_MOTIONDEVICESYSTEMTYPE), &motionSystemId)) {
            logger->error("No MotionDeviceSystemType found on {}", this->endpointUrl);
            return UA_STATUSCODE_BADNOTFOUND;
        }
        UA_NodeId_clear(&deviceSetNodeId);

        UA_NodeId motionDevicesId;
        if (!fortiss::opcua::UA_Client_findChildWithBrowseName(lc.get(), logger, motionSystemId,
                                                       UA_QUALIFIEDNAME(nsRobIdx, const_cast<char*>("MotionDevices")), &motionDevicesId)) {
            logger->error("No MotionDevices found on {}", this->endpointUrl);
            return UA_STATUSCODE_BADNOTFOUND;
        }
        UA_NodeId_clear(&motionSystemId);


        UA_NodeId motionDeviceId;
        if (!fortiss::opcua::UA_Client_findChildOfType(lc.get(), logger, motionDevicesId,
                                                       UA_NODEID_NUMERIC(nsForRobIdx, UA_FOR_ROBID_FORTISSMOTIONDEVICETYPE), &motionDeviceId)) {
            logger->error("No MotionDeviceType found on {}", this->endpointUrl);
            return UA_STATUSCODE_BADNOTFOUND;
        }
        UA_NodeId_clear(&motionDevicesId);

        std::vector<UA_QualifiedName> path;
        path.emplace_back(UA_QUALIFIEDNAME(this->nsDiIdx, const_cast<char*>("ParameterSet")));
        path.emplace_back(UA_QUALIFIEDNAME(nsForRobIdx, const_cast<char*>("WorldToRobotBase")));

        UA_NodeId worldToRobotBaseId;
        if (!fortiss::opcua::UA_Client_findBrowsePath(lc.get(), logger, motionDeviceId, path, &worldToRobotBaseId)) {
            logger->error("No WorldToRobotBase found on {}", this->endpointUrl);
            return UA_STATUSCODE_BADNOTFOUND;
        }
        UA_NodeId_clear(&motionDeviceId);

        if (const UA_StatusCode ret = UA_Client_readValueAttribute(lc.get(), worldToRobotBaseId, &worldToRobotVar) != UA_STATUSCODE_GOOD) {
            logger->error("Could not read WorldToRobotBase: {}", UA_StatusCode_name(ret));
            return ret;
        }
        UA_NodeId_clear(&worldToRobotBaseId);
    }

    if (worldToRobotVar.type != &UA_TYPES[UA_TYPES_THREEDFRAME]) {
        logger->error("Invalid type of WorldToRobotBase");
        return UA_STATUSCODE_BADTYPEMISMATCH;
    }
    auto *frame = (UA_ThreeDFrame*)worldToRobotVar.data;

    rl::math::Transform parsedFrame;

    parsedFrame = ::rl::math::AngleAxis(
            frame->orientation.c,
            ::rl::math::Vector3::UnitZ()
    ) * ::rl::math::AngleAxis(
            frame->orientation.b,
            ::rl::math::Vector3::UnitY()
    ) * ::rl::math::AngleAxis(
            frame->orientation.a,
            ::rl::math::Vector3::UnitX()
    );
    parsedFrame.translation().x() = frame->cartesianCoordinates.x;
    parsedFrame.translation().y() = frame->cartesianCoordinates.y;
    parsedFrame.translation().z() = frame->cartesianCoordinates.z;

    UA_Variant_clear(&worldToRobotVar);

    if (!worldToRobotTransform)
        worldToRobotTransform = std::make_shared<rl::math::Transform>();

    *worldToRobotTransform = parsedFrame;
    *transform = *worldToRobotTransform;
    return UA_STATUSCODE_GOOD;
}
