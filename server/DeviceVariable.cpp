/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/opcua/server/DeviceVariable.h>
#include <common/opcua/server/OpcUaServer.h>
#include <common/opcua/helper.hpp>


using namespace fortiss::opcua;

DeviceVariable::DeviceVariable(
        const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
        const UA_DataType* type,
        void* value,
        const UA_NodeId nodeId,
        size_t arrayLength,
        size_t arrayDimensionsSize,
        UA_UInt32 *arrayDimensions
) {
    dataValuePtr = &dataValue;
    UA_ValueBackend valueBackend;
    dataValue.value.storageType = UA_VARIANT_DATA_NODELETE;
    dataValue.value.type = type;
    dataValue.value.arrayLength = arrayLength;
    dataValue.value.arrayDimensions = arrayDimensions;
    dataValue.value.arrayDimensionsSize = arrayDimensionsSize;
    dataValue.value.data = value;
    dataValue.hasSourceTimestamp = false;

    valueBackend.backendType = UA_VALUEBACKENDTYPE_EXTERNAL;
    valueBackend.backend.external.value = &dataValuePtr;
    valueBackend.backend.external.callback.userWrite = NULL;
    valueBackend.backend.external.callback.notificationRead = NotificationRead;
    LockedServer ls = server->getLocked();
    UA_StatusCode retval = UA_Server_setVariableNode_valueBackend(ls.get(), nodeId, valueBackend);
    if (retval != UA_STATUSCODE_GOOD) {
        throw fortiss::opcua::StatusCodeException(retval);
    }
}

DeviceVariable::DeviceVariable(
        UA_Server* server,
        const UA_DataType* type,
        void* value,
        const UA_NodeId nodeId,
        size_t arrayLength,
        size_t arrayDimensionsSize,
        UA_UInt32 *arrayDimensions
) {
    dataValuePtr = &dataValue;
    UA_ValueBackend valueBackend;
    dataValue.value.storageType = UA_VARIANT_DATA_NODELETE;
    dataValue.value.type = type;
    dataValue.value.arrayLength = arrayLength;
    dataValue.value.arrayDimensions = arrayDimensions;
    dataValue.value.arrayDimensionsSize = arrayDimensionsSize;
    dataValue.value.data = value;
    dataValue.hasSourceTimestamp = false;

    valueBackend.backendType = UA_VALUEBACKENDTYPE_EXTERNAL;
    valueBackend.backend.external.value = &dataValuePtr;
    valueBackend.backend.external.callback.userWrite = NULL;
    valueBackend.backend.external.callback.notificationRead = NotificationRead;
    UA_StatusCode retval = UA_Server_setVariableNode_valueBackend(server, nodeId, valueBackend);
    if (retval != UA_STATUSCODE_GOOD) {
        throw fortiss::opcua::StatusCodeException(retval);
    }
}

UA_StatusCode DeviceVariable::NotificationRead(UA_Server *server, const UA_NodeId *sessionId,
                                      void *sessionContext, const UA_NodeId *nodeid,
                                      void *nodeContext, const UA_NumericRange *range) {
    return UA_STATUSCODE_GOOD;
}