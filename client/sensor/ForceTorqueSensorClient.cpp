/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <utility>

//
// Created by breitkreuz on 5/03/19.
//

#include <mutex>
#include <spdlog/logger.h>
#include <common/opcua/helper.hpp>
#include <common/logging_opcua.h>
#include <di_nodeids.h>
#include "open62541/client_config_default.h"

#include <common/client/sensor/ForceTorqueSensorClient.h>

ForceTorqueSensorClient::ForceTorqueSensorClient(std::shared_ptr<spdlog::logger> _logger,
                                                 const std::string &serverURL, UA_UInt16 nsIdxForRobDevice,
                                                 const UA_NodeId &sensorNodeId) : logger(std::move(_logger)) {
    client = std::shared_ptr<UA_Client>(UA_Client_new(), [=](UA_Client *_client) {
        UA_Client_disconnect(_client);
        UA_Client_delete(_client);
    });

    UA_ClientConfig *clientConfig = UA_Client_getConfig(client.get());
    UA_ClientConfig_setDefault(clientConfig);
    clientConfig->logger.log = fortiss::log::opcua::UA_Log_Spdlog_log;
    clientConfig->logger.context = logger.get();
    clientConfig->logger.clear = fortiss::log::opcua::UA_Log_Spdlog_clear;

    UA_StatusCode retval = UA_Client_connect(client.get(), serverURL.c_str());
    if (retval != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Can not connect to server " + serverURL + ". Error: " + UA_StatusCode_name(retval));
    }

    initializeNodeIds(sensorNodeId, nsIdxForRobDevice);
}

void ForceTorqueSensorClient::initializeNodeIds(const UA_NodeId &sensorNodeId, UA_UInt16 nsIdxForRobDevice) {
    UA_BrowseRequest request;
    UA_BrowseRequest_init(&request);
    request.nodesToBrowse = static_cast<UA_BrowseDescription *>(UA_Array_new(2, &UA_TYPES[UA_TYPES_BROWSEDESCRIPTION]));
    request.nodesToBrowseSize = 2;
    UA_NodeId_copy(&sensorNodeId, &request.nodesToBrowse[0].nodeId);
    for (int i = 0; i < 2; i++) {
        request.nodesToBrowse[i].browseDirection = UA_BROWSEDIRECTION_FORWARD;
        request.nodesToBrowse[i].resultMask = UA_BROWSERESULTMASK_ALL;
    }
    request.nodesToBrowse[0].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);

    auto response = UA_Client_Service_browse(client.get(), request);
    UA_BrowseRequest_clear(&request);

    if (response.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        UA_StatusCode retval = response.responseHeader.serviceResult;
        UA_BrowseResponse_clear(&response);
        throw std::runtime_error("Browsing for force/torque nodes failed " + std::string(UA_StatusCode_name(retval)));
    }

    if (response.resultsSize != 2) {
        auto results = response.resultsSize;
        UA_BrowseResponse_clear(&response);
        throw std::runtime_error(
                "Received incorrect number of force/torque nodes, expected 2 but received " + std::to_string(results));
    }

    auto forceName = UA_QUALIFIEDNAME(nsIdxForRobDevice, const_cast<char *>("ForceSensor"));
    auto torqueName = UA_QUALIFIEDNAME(nsIdxForRobDevice, const_cast<char *>("TorqueSensor"));

    bool forceFound = false;
    bool torqueFound = false;

    UA_NodeId tmpForce{};
    UA_NodeId tmpTorque{};

    for (size_t i = 0; i < response.resultsSize && !(forceFound && torqueFound); i++) {
        for (size_t j = 0; j < response.results[i].referencesSize; j++) {
            auto &&tmpName = &response.results[i].references[j].browseName;
            if (UA_QualifiedName_equal(tmpName, &forceName)) {
                UA_NodeId_copy(&response.results[i].references[j].nodeId.nodeId, &tmpForce);
                forceFound = true;
            } else if (UA_QualifiedName_equal(tmpName, &torqueName)) {
                UA_NodeId_copy(&response.results[i].references[j].nodeId.nodeId, &tmpTorque);
                torqueFound = true;
            }
        }
    }

    UA_BrowseResponse_clear(&response);

    if (!forceFound || !torqueFound) {
        throw std::runtime_error("Unable to find force node or torque node");
    }

    forceName = UA_QUALIFIEDNAME(nsIdxForRobDevice, const_cast<char *>("Force"));
    auto found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, tmpForce, forceName,
                                                                   &forcesId);

    if (!found) {
        throw std::runtime_error("Unable to find Force array from ForceSensor node");
    }

    torqueName = UA_QUALIFIEDNAME(nsIdxForRobDevice, const_cast<char *>("Torque"));
    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, tmpTorque, torqueName, &torquesId);

    if (!found) {
        throw std::runtime_error("Unable to find Torque array from TorqueSensor node");
    }
}

const rl::math::Vector3 ForceTorqueSensorClient::getForce() const {
    rl::math::Vector3 res;
    res[0] = forceTorque[0];
    res[1] = forceTorque[1];
    res[2] = forceTorque[2];
    return res;
}

const rl::math::Vector3 ForceTorqueSensorClient::getTorque() const {
    rl::math::Vector3 res;
    res[0] = forceTorque[4];
    res[1] = forceTorque[5];
    res[2] = forceTorque[6];
    return res;
}

const rl::math::Vector6 ForceTorqueSensorClient::getForceTorque() const {
    return rl::math::Vector6(forceTorque);
}

void ForceTorqueSensorClient::readForce() {
    UA_ReadRequest request;
    UA_ReadRequest_init(&request);
    request.nodesToReadSize = 1;
    request.nodesToRead = UA_ReadValueId_new();
    UA_ReadValueId_init(request.nodesToRead);
    UA_NodeId_copy(&forcesId, &request.nodesToRead->nodeId);
    request.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse response;
    response = UA_Client_Service_read(client.get(), request);
    if (response.resultsSize != 1 || response.results->value.type != &UA_TYPES[UA_TYPES_DOUBLE]) {
        throw std::runtime_error("Cannot read node");
    }

    UA_ReadRequest_clear(&request);

    auto forces = static_cast<double *>(response.results->value.data);
    for (int i = 0; i < 3; i++)
        forceTorque[i] = forces[i];

    UA_ReadResponse_clear(&response);
}

void ForceTorqueSensorClient::readTorque() {
    UA_ReadRequest request;
    UA_ReadRequest_init(&request);
    request.nodesToReadSize = 1;
    request.nodesToRead = UA_ReadValueId_new();
    UA_ReadValueId_init(request.nodesToRead);
    UA_NodeId_copy(&torquesId, &request.nodesToRead->nodeId);
    request.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse response;
    response = UA_Client_Service_read(client.get(), request);
    if (response.resultsSize != 1 || response.results->value.type != &UA_TYPES[UA_TYPES_DOUBLE]) {
        throw std::runtime_error("Cannot read node");
    }

    UA_ReadRequest_clear(&request);

    auto torques = static_cast<double *>(response.results->value.data);
    for (int i = 0; i < 3; i++)
        forceTorque[i + 3] = torques[i];

    UA_ReadResponse_clear(&response);
}

void ForceTorqueSensorClient::step() {
    readForce();
    readTorque();
}
