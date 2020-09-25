/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/client/robot/JointLinearMoveSkillClient.h>
#include <common/opcua/helper.hpp>

JointLinearMoveSkillClient::JointLinearMoveSkillClient(
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
        JointMoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, axisCount, username, password, clientCertPath, clientKeyPath,
                             clientAppUri, clientAppName),
        LinearMoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password, clientCertPath, clientKeyPath,
                              clientAppUri, clientAppName) {}

std::future<void> JointLinearMoveSkillClient::move(
        const double targetJointPosition[],
        const std::string& toolFrame,
        const double maxVelocity[6],
        const double maxAcceleration[6]
) {
    std::stringstream msg;
    msg << "Sending JointPtpMove: ";
    for (int i = 0; i < axisCount; i++)
        msg << targetJointPosition[i] << " ";
    logger->info(msg.str());
    std::promise<void> promiseMoveFinished;
    this->connect();

    UA_StatusCode retval;
    bool dummy  __attribute__((unused)) = (!(retval = setToolFrame(toolFrame)) &&
                                           !(retval = setMaxAcceleration(maxAcceleration)) &&
                                           !(retval = setMaxVelocity(maxVelocity)) &&
                                           !(retval = setTargetJointPosition(targetJointPosition)) &&
                                           !(retval = writeParameter()));
    if (retval != UA_STATUSCODE_GOOD) {
        return fortiss::opcua::setPromiseErrorException<void>(&promiseMoveFinished, retval);
    }
    emptyReceivedStates();
    retval = start();
    if (retval != UA_STATUSCODE_GOOD) {
        return fortiss::opcua::setPromiseErrorException<void>(&promiseMoveFinished, retval);
    }
    return std::async([this]() {
        fortiss::opcua::ProgramStateNumber newState = getNextState().get();
        if (newState != fortiss::opcua::ProgramStateNumber::RUNNING) {
            logger->error("Did not change to expected Running state.");
            throw fortiss::opcua::StatusCodeException(UA_STATUSCODE_BADINVALIDSTATE);
        }
        newState = getNextState().get();
        if (newState != fortiss::opcua::ProgramStateNumber::READY) {
            logger->error("Did not change to expected READY state.");
            throw fortiss::opcua::StatusCodeException(UA_STATUSCODE_BADINVALIDSTATE);
        }
        return;
    });
}

