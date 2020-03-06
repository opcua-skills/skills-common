//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/client/robot/CartesianMoveSkillClient.h>

#include <common/opcua/helper.hpp>

CartesianMoveSkillClient::CartesianMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                                   const std::string &serverURL,
                                                   UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                                   const UA_NodeId &skillNodeId, unsigned short axisCount,
                                                   const std::string &username, const std::string &password) :
        MoveSkillClient(loggerParam, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password),
        SkillClient(loggerParam, serverURL, nsIdxDi, skillNodeId, username, password),
        axisCount(axisCount) {
    initParameter(&targetPositionParameter, "TargetPosition", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                               const_cast<char *>("TargetPosition")));
    initParameter(&axisBoundsParameter, "AxisBounds", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                       const_cast<char *>("AxisBounds")));
}

CartesianMoveSkillClient::~CartesianMoveSkillClient() {
    if (axisBoundsParameter) {
        UA_Variant_clear(&axisBoundsParameter->value);
    }
    delete targetPositionParameter;
    delete axisBoundsParameter;
}

const UA_StatusCode
CartesianMoveSkillClient::setTargetPosition(const UA_ThreeDFrame &targetCartesianPosition) {
    if (targetPositionParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&targetPositionParameter->value);
    UA_StatusCode retval = UA_Variant_setScalarCopy(&targetPositionParameter->value, &targetCartesianPosition,
                                                    &UA_TYPES[UA_TYPES_THREEDFRAME]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy targetCartesianPosition. {}", UA_StatusCode_name(retval));
        return retval;
    }
    return retval;
}

const UA_StatusCode
CartesianMoveSkillClient::setAxisBounds(const UA_Range axisBounds[]) {
    if (axisBoundsParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&axisBoundsParameter->value);

    if (!axisBounds)
        return UA_STATUSCODE_GOOD;


    UA_StatusCode retval = UA_Variant_setArrayCopy(&axisBoundsParameter->value, axisBounds, axisCount,
                                                   &UA_TYPES[UA_TYPES_RANGE]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy axisBounds. {}", UA_StatusCode_name(retval));
        return retval;
    }

    axisBoundsParameter->value.arrayDimensionsSize = 1;
    axisBoundsParameter->value.arrayDimensions = (UA_UInt32 *)UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
    axisBoundsParameter->value.arrayDimensions[0] = axisCount;

    return retval;
}
