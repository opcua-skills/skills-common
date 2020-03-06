//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/client/robot/JointMoveSkillClient.h>

#include <common/opcua/helper.hpp>

JointMoveSkillClient::JointMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                           const std::string &serverURL,
                                           UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                           const UA_NodeId &skillNodeId, unsigned short axisCount,
                                           const std::string &username, const std::string &password) :
        MoveSkillClient(loggerParam, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password),
        SkillClient(loggerParam, serverURL, nsIdxDi, skillNodeId, username, password),
        axisCount(axisCount) {

    initParameter(&targetJointPositionParameter, "TargetJointPosition", UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                                         const_cast<char *>("TargetJointPosition")));

}

JointMoveSkillClient::~JointMoveSkillClient() {
    delete targetJointPositionParameter;
}

const UA_StatusCode
JointMoveSkillClient::setTargetJointPosition(const double targetJointPosition[]) {
    if (targetJointPositionParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&targetJointPositionParameter->value);
    UA_StatusCode retval = UA_Variant_setArrayCopy(&targetJointPositionParameter->value, targetJointPosition,
                                                   axisCount,
                                                   &UA_TYPES[UA_TYPES_DOUBLE]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy targetJointPosition. {}", UA_StatusCode_name(retval));
        return retval;
    }

    return retval;
}
