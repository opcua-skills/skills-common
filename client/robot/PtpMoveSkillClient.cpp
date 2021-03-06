/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/client/robot/PtpMoveSkillClient.h>

PtpMoveSkillClient::PtpMoveSkillClient(
        const std::shared_ptr<spdlog::logger>& loggerApp,
        const std::shared_ptr<spdlog::logger>& loggerOpcua,
        const std::string& serverURL,
        UA_UInt16 nsIdxDi,
        UA_UInt16 nsIdxRobFor,
        const UA_NodeId& skillNodeId,
        unsigned short axisCount,
        const std::string& username,
        const std::string& password,
        const std::string& clientCertPath,
        const std::string& clientKeyPath,
        const std::string& clientAppUri,
        const std::string& clientAppName
) :
        SkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, skillNodeId, username, password, clientCertPath, clientKeyPath, clientAppUri, clientAppName),
        MoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password, clientCertPath, clientKeyPath, clientAppUri,
                        clientAppName),
        axisCount(axisCount) {

    initParameter(&maxVelocityParameter, "MaxVelocity", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                         const_cast<char*>("MaxVelocity")));
    initParameter(&maxAccelerationParameter, "MaxAcceleration", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                                 const_cast<char*>("MaxAcceleration")));
}

PtpMoveSkillClient::~PtpMoveSkillClient() {
    UA_Variant_clear(&maxVelocityParameter->value);
    UA_Variant_clear(&maxAccelerationParameter->value);
    delete maxVelocityParameter;
    delete maxAccelerationParameter;
}

const UA_StatusCode
PtpMoveSkillClient::setMaxAcceleration(const double maxAcceleration[]) {

    if (maxAccelerationParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&maxAccelerationParameter->value);

    if (!maxAcceleration)
        return UA_STATUSCODE_GOOD;

    UA_StatusCode retval = UA_Variant_setArrayCopy(&maxAccelerationParameter->value, &maxAcceleration[0], axisCount,
                                                   &UA_TYPES[UA_TYPES_DOUBLE]);


    maxAccelerationParameter->value.arrayDimensionsSize = 1;
    maxAccelerationParameter->value.arrayDimensions = (UA_UInt32*) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
    maxAccelerationParameter->value.arrayDimensions[0] = axisCount;

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy maxAcceleration. {}", UA_StatusCode_name(retval));
        return retval;
    }

    return retval;
}


const UA_StatusCode
PtpMoveSkillClient::setMaxVelocity(const double maxVelocity[]) {

    if (maxVelocityParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&maxVelocityParameter->value);

    if (!maxVelocity)
        return UA_STATUSCODE_GOOD;
    UA_StatusCode retval = UA_Variant_setArrayCopy(&maxVelocityParameter->value, maxVelocity, axisCount,
                                                   &UA_TYPES[UA_TYPES_DOUBLE]);

    maxVelocityParameter->value.arrayDimensionsSize = 1;
    maxVelocityParameter->value.arrayDimensions = (UA_UInt32*) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
    maxVelocityParameter->value.arrayDimensions[0] = axisCount;

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy maxVelocity. {}", UA_StatusCode_name(retval));
        return retval;
    }

    return retval;
}
