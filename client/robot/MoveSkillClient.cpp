//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <common/client/robot/MoveSkillClient.h>


#include <memory>
#include <exception>
#include <iterator>
#include <for_rob_nodeids.h>

#include <common/opcua/helper.hpp>


MoveSkillClient::MoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                 UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor, const UA_NodeId &skillNodeId,
                                 const std::string &username, const std::string &password) :
        SkillClient(loggerParam, serverURL, nsIdxDi, skillNodeId, username, password) {

    initParameter(&toolFrameParameter, "ToolFrame", UA_QUALIFIEDNAME(nsIdxRobFor, const_cast<char *>("ToolFrame")));
}

MoveSkillClient::~MoveSkillClient() {
    UA_Variant_clear(&toolFrameParameter->value);
    delete toolFrameParameter;
}

const UA_StatusCode
MoveSkillClient::setToolFrame(const std::string &toolFrame) {

    if (toolFrameParameter == nullptr)
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant_clear(&toolFrameParameter->value);

    const UA_String val = {
            toolFrame.length(),
            (UA_Byte*)const_cast<char*>(toolFrame.c_str())
    };

    UA_StatusCode retval = UA_Variant_setScalarCopy(&toolFrameParameter->value, &val,
                                                    &UA_TYPES[UA_TYPES_STRING]);

    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Failed to copy toolFrame. {}", UA_StatusCode_name(retval));
        return retval;
    }

    return retval;
}

