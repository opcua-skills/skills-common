//
// Created by breitkreuz on 10/07/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/opcua/helper.hpp>
#include <common/client/robot/ForceSkillClient.h>

ForceSkillClient::ForceSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                           const std::string &serverURL, UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                           const UA_NodeId &skillNodeId, const std::string &username,
                                           const std::string &password)
        : SkillClient(loggerParam, serverURL, nsIdxDi, skillNodeId, username, password) {

    initParameter(&maxForceParameter, "MaxForce", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                               const_cast<char *>("MaxForce")));

    UA_NodeId finalResultData;
    fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, skillNodeId,
                                                      UA_QUALIFIEDNAME(0, const_cast<char *>("FinalResultData")),
                                                      &finalResultData);

    fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, finalResultData,
                                                      UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsIdxRobFor),
                                                                       const_cast<char *>("ForcesExceeded")),
                                                      &forcesExceeded);

    fortiss::opcua::UA_Client_findChildWithBrowseName(client, logger, finalResultData,
                                                      UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsIdxRobFor),
                                                                       const_cast<char *>("ForcesMax")),
                                                      &forcesMax);
}

ForceSkillClient::~ForceSkillClient() {
    delete maxForceParameter;
}

const UA_StatusCode ForceSkillClient::setMaxForce(const UA_ThreeDVector force) {

    if (maxForceParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&maxForceParameter->value);
    UA_StatusCode retval = UA_Variant_setScalarCopy(&maxForceParameter->value, &force,
                                                    &UA_TYPES[UA_TYPES_THREEDVECTOR]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy targetCartesianPosition. {}", UA_StatusCode_name(retval));
        return retval;
    }
    return retval;
}

std::array<double, 3> ForceSkillClient::readForcesExceeded() {
    UA_ReadRequest req;
    UA_ReadRequest_init(&req);

    req.nodesToReadSize = 1;
    req.nodesToRead = UA_ReadValueId_new();
    req.nodesToRead->nodeId = forcesExceeded;
    req.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse resp;

    {
        std::lock_guard<std::mutex> lk(clientMutex);
        resp = UA_Client_Service_read(client, req);
    }

    if (resp.resultsSize != 1 || resp.results->status != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Reading exceeded forces failed");
    }

    std::array<double, 3> res({static_cast<UA_ThreeDVector *>(resp.results->value.data)->x,
                               static_cast<UA_ThreeDVector *>(resp.results->value.data)->y,
                               static_cast<UA_ThreeDVector *>(resp.results->value.data)->z});

    UA_ReadRequest_deleteMembers(&req);
    UA_ReadResponse_deleteMembers(&resp);

    return res;
}

std::array<double, 3> ForceSkillClient::readForcesMax() {
    UA_ReadRequest req;
    UA_ReadRequest_init(&req);

    req.nodesToReadSize = 1;
    req.nodesToRead = UA_ReadValueId_new();
    req.nodesToRead->nodeId = forcesMax;
    req.nodesToRead->attributeId = UA_ATTRIBUTEID_VALUE;
    UA_ReadResponse resp;

    {
        std::lock_guard<std::mutex> lk(clientMutex);
        resp = UA_Client_Service_read(client, req);
    }

    if (resp.resultsSize != 1 || resp.results->status != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Reading max forces failed");
    }

    std::array<double, 3> res({static_cast<UA_ThreeDVector *>(resp.results->value.data)->x,
                               static_cast<UA_ThreeDVector *>(resp.results->value.data)->y,
                               static_cast<UA_ThreeDVector *>(resp.results->value.data)->z});

    UA_ReadRequest_deleteMembers(&req);
    UA_ReadResponse_deleteMembers(&resp);

    return res;
}

