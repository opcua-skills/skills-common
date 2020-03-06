//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/client/robot/CartesianPtpMoveSkillClient.h>
#include <common/opcua/helper.hpp>

CartesianPtpMoveSkillClient::CartesianPtpMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                                         const std::string &serverURL,
                                                         UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                                         const UA_NodeId &skillNodeId, unsigned short axisCount,
                                                         const std::string &username, const std::string &password) :
        CartesianMoveSkillClient(loggerParam, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, axisCount, username,
                                 password),
        PtpMoveSkillClient(loggerParam, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, axisCount, username, password),
        MoveSkillClient(loggerParam, serverURL, nsIdxDi, nsIdxRobFor, skillNodeId, username, password),
        SkillClient(loggerParam, serverURL, nsIdxDi, skillNodeId, username, password) {

}

std::future<void> CartesianPtpMoveSkillClient::move(const UA_ThreeDFrame &targetPosition,
                                                    const std::string &toolFrame,
                                                    const double maxVelocity[],
                                                    const double maxAcceleration[],
                                                    const UA_Range axisBounds[]) {
    std::stringstream msg;
    msg << "Sending CartesianPtpMove: " << targetPosition.cartesianCoordinates.x << " "
        << targetPosition.cartesianCoordinates.y << " " << targetPosition.cartesianCoordinates.z << " "
        << targetPosition.orientation.a * RAD_TO_DEG << " " << targetPosition.orientation.b * RAD_TO_DEG << " "
        << targetPosition.orientation.c * RAD_TO_DEG;
    logger->info(msg.str());
    std::promise<void> promiseMoveFinished;

    // write the parameters
    UA_StatusCode retval;

    bool dummy  __attribute__((unused)) = (!(retval = setToolFrame(toolFrame)) &&
                                           !(retval = setMaxAcceleration(maxAcceleration)) &&
                                           !(retval = setMaxVelocity(maxVelocity)) &&
                                           !(retval = setTargetPosition(targetPosition)) &&
                                           !(retval = setAxisBounds(axisBounds)) &&
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

