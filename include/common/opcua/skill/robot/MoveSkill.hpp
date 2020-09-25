/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_OPCUA_ROBOT_MOVESKILL_HPP
#define ROBOTICS_COMMON_OPCUA_ROBOT_MOVESKILL_HPP
#pragma once

#include "common/opcua/skill/SkillBase.hpp"
#include "common/opcua/skill/SkillParameter.hpp"

namespace fortiss {
    namespace opcua {
        namespace skill {
            namespace robot {

                class MoveSkill : virtual public SkillBase {


                protected:
                    const size_t nsDiIdx;
                    const size_t nsRobIdx;
                    const size_t nsForRobIdx;


                    const std::shared_ptr<UA_NodeId> parameterSetNodeId;

                    SkillParameter <std::string> toolFrameParameter;

                    virtual UA_StatusCode readParameters() {
                        UA_StatusCode retVal = readParameter<std::string, UA_String>(
                                toolFrameParameter,
                                [this](const UA_String& x) {
                                    if (x.length == 0)
                                        this->toolFrameParameter.value = "";
                                    else
                                        this->toolFrameParameter.value = std::string((char*) x.data, x.length);
                                });

                        return retVal;
                    }


                public:

                    explicit MoveSkill(
                            const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                            std::shared_ptr<spdlog::logger>& logger,
                            const UA_NodeId& skillNodeId,
                            const std::string& eventSourceName
                    ) :
                            SkillBase(server, logger, skillNodeId, eventSourceName),
                            nsDiIdx(UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_DI)),
                            nsRobIdx(UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_ROB)),
                            nsForRobIdx(UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_FOR_ROB)),
                            parameterSetNodeId(UA_Server_getObjectComponentId(server, stateMachineNodeId,
                                                                              UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsDiIdx),
                                                                                               const_cast<char*>("ParameterSet")))),
                            toolFrameParameter(&UA_TYPES[UA_TYPES_STRING], "ToolFrame",
                                               UA_Server_getObjectComponentId(server, *parameterSetNodeId,
                                                                              UA_QUALIFIEDNAME(static_cast<UA_UInt16>(nsForRobIdx),
                                                                                               const_cast<char*>("ToolFrame")))) {
                        // use dynamic cast to make sure polymorphic resolution is correct
                        auto selfProgram = dynamic_cast<Program*>(this);

                        LockedServer ls = server->getLocked();
                        if (UA_Server_setNodeContext(ls.get(), skillNodeId, selfProgram) != UA_STATUSCODE_GOOD) {
                            throw std::runtime_error("Adding method context failed");
                        }
                    }

                    virtual void moveFinished() {
                        if (!transition(ProgramStateNumber::READY)) {
                            logger->error("Failed to make transition after move has finished to ready");
                        }
                    }

                    virtual void moveErrored() {
                        if (!transition(ProgramStateNumber::HALTED)) {
                            logger->error("Failed to make transition after move has failed to halted");
                        }
                    }

                    void moveReset() {
                        if (!transition(ProgramStateNumber::READY)) {
                            logger->error("Failed to make transition to ready after robot is ready again");
                        }
                    }

                };
            }
        }
    }
}

#endif //ROBOTICS_COMMON_OPCUA_ROBOT_MOVESKILL_HPP
