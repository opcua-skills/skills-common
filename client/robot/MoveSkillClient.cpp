/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/client/robot/MoveSkillClient.h>


#include <memory>
#include <exception>
#include <iterator>
#include <for_rob_nodeids.h>

#include <common/opcua/helper.hpp>


MoveSkillClient::MoveSkillClient(
        const std::shared_ptr<spdlog::logger>& loggerApp,
        const std::shared_ptr<spdlog::logger>& loggerOpcua,
        const std::string& serverURL,
        UA_UInt16 nsIdxDi,
        UA_UInt16 nsIdxRobFor,
        const UA_NodeId& skillNodeId,
        const std::string& username,
        const std::string& password,
        const std::string& clientCertPath,
        const std::string& clientKeyPath,
        const std::string& clientAppUri,
        const std::string& clientAppName
) :
        SkillClient(loggerApp, loggerOpcua, serverURL, nsIdxDi, skillNodeId, username, password, clientCertPath, clientKeyPath, clientAppUri, clientAppName) {

    initParameter(&toolFrameParameter, "ToolFrame", UA_QUALIFIEDNAME(nsIdxRobFor, const_cast<char*>("ToolFrame")));
}

MoveSkillClient::~MoveSkillClient() {
    UA_Variant_clear(&toolFrameParameter->value);
    delete toolFrameParameter;
}

const UA_StatusCode
MoveSkillClient::setToolFrame(const std::string& toolFrame) {

    if (toolFrameParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&toolFrameParameter->value);

    const UA_String val = {
            toolFrame.length(),
            (UA_Byte*) const_cast<char*>(toolFrame.c_str())
    };

    UA_StatusCode retval = UA_Variant_setScalarCopy(&toolFrameParameter->value, &val,
                                                    &UA_TYPES[UA_TYPES_STRING]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy toolFrame. {}", UA_StatusCode_name(retval));
        return retval;
    }

    return retval;
}

