/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <memory>
#include <exception>
#include <iterator>
#include <for_rob_nodeids.h>
#include <common/client/gripper/GripperSkillClient.h>

#include <common/opcua/helper.hpp>
#include <open62541/plugin/log_stdout.h>


GripperSkillClient::GripperSkillClient(
        const std::shared_ptr<spdlog::logger>& loggerApp,
        const std::shared_ptr<spdlog::logger>& loggerOpcua,
        const std::string& serverURL,
        UA_UInt16 nsIdxDi,
        const UA_NodeId& skillNodeId
) :
        SkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, skillNodeId, "", "", false) {

}

std::future<void> GripperSkillClient::move() {

    std::promise<void> promiseMoveFinished;

    emptyReceivedStates();
    UA_StatusCode retval = start();
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