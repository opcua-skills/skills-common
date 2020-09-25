/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/client/robot/CartesianLinearForceMoveSkillClient.h>

#include <common/opcua/helper.hpp>

CartesianLinearForceMoveSkillClient::CartesianLinearForceMoveSkillClient(
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
)
        : SkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, skillNodeId, username, password, clientCertPath, clientKeyPath, clientAppUri, clientAppName),
          MoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password, clientCertPath, clientKeyPath, clientAppUri,
                          clientAppName),
          CartesianMoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, axisCount, username,
                                   password, clientCertPath, clientKeyPath, clientAppUri, clientAppName),
          LinearMoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password, clientCertPath, clientKeyPath,
                                clientAppUri, clientAppName),
          CartesianLinearMoveSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, axisCount, username,
                                         password, clientCertPath, clientKeyPath, clientAppUri, clientAppName),
          ForceSkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password, clientCertPath, clientKeyPath,
                           clientAppUri, clientAppName) {}

std::future<std::array<double, 3>> CartesianLinearForceMoveSkillClient::moveForce(
        const UA_ThreeDFrame& targetPosition,
        const std::string& toolFrame,
        const double maxVelocity[6],
        const double maxAcceleration[6],
        UA_ThreeDVector maxForce,
        const UA_Range axisBounds[]
) {
    std::stringstream msg;
    msg << "Sending CartesianLinearForceMove: " << targetPosition.cartesianCoordinates.x << " "
        << targetPosition.cartesianCoordinates.y << " " << targetPosition.cartesianCoordinates.z << " "
        << targetPosition.orientation.a * RAD_TO_DEG << " " << targetPosition.orientation.b * RAD_TO_DEG << " "
        << targetPosition.orientation.c * RAD_TO_DEG << " " << maxForce.x << " " << maxForce.y << " " << maxForce.z;
    logger->info(msg.str());
    std::promise<std::array<double, 3>> promiseMoveFinished;

    this->connect();
    // write the parameters
    UA_StatusCode retval;

    bool dummy  __attribute__((unused)) = (!(retval = setToolFrame(toolFrame)) &&
                                           !(retval = setMaxAcceleration(maxAcceleration)) &&
                                           !(retval = setMaxVelocity(maxVelocity)) &&
                                           !(retval = setTargetPosition(targetPosition)) &&
                                           !(retval = setAxisBounds(axisBounds)) &&
                                           !(retval = setMaxForce(maxForce)) &&
                                           !(retval = writeParameter()));
    if (retval != UA_STATUSCODE_GOOD) {
        return fortiss::opcua::setPromiseErrorException<std::array<double, 3>>(&promiseMoveFinished, retval);
    }
    emptyReceivedStates();
    retval = start();
    if (retval != UA_STATUSCODE_GOOD) {
        return fortiss::opcua::setPromiseErrorException<std::array<double, 3>>(&promiseMoveFinished, retval);
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
        return readForcesExceeded();
    });
}
