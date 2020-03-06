//
// Created by breitkreuz on 21/12/18.
//

#ifndef ROBOTICS_OPCUAROBOTCONTROL_H
#define ROBOTICS_OPCUAROBOTCONTROL_H

#include <open62541/server.h>

#include <common/opcua/helper.hpp>

#include <spdlog/logger.h>
#include <unordered_map>
#include <sstream>

#include <types_rob_generated.h>
#include <rob_nodeids.h>

#define NAMESPACE_URI_DI "http://opcfoundation.org/UA/DI/"
#define NAMESPACE_URI_ROB "http://opcfoundation.org/UA/Robotics/"

namespace fortiss {
    namespace opcua {
        namespace robot {

            template<int AXIS_COUNT>
            class OpcUAMotionDevice {
            public:
                OpcUAMotionDevice(UA_Server *server, const UA_NodeId& motionDeviceNodeId, std::shared_ptr<spdlog::logger> _logger) :
                        logger(std::move(_logger)), server(server) {
                    initializeNodeIds(motionDeviceNodeId);
                    initializeNodeIdAxisMap(motionDeviceNodeId);
                }

            protected:

                std::shared_ptr<spdlog::logger> logger;

                virtual ::rl::math::Vector getJointPosition() = 0;

                // TODO write node stuff for load
                // UA_NodeId flangeLoadId;

                std::shared_ptr<UA_NodeId> flangeToolId;
                std::shared_ptr<UA_NodeId> flangeToolFrameId;
                std::shared_ptr<UA_NodeId> flangeToolNameId;


                UA_ThreeDFrame toolFrame;
                std::string toolName;

                std::function<bool(const std::string &name, const UA_ThreeDFrame &frame, const double mass, const UA_ThreeDFrame &centerOfMass, const UA_ThreeDVector &inertia)> setToolCallback;
                std::function<bool()> clearToolCallback;
            private:

                // Data callbacks for axes dataSources
                static UA_StatusCode
                readActualPosition(UA_Server *server, const UA_NodeId *sessionId, void *sessionContext,
                                   const UA_NodeId *nodeId,
                                   void *nodeContext, UA_Boolean sourceTimeStamp, const UA_NumericRange *range,
                                   UA_DataValue *dataValue) {
                    auto self = static_cast<OpcUAMotionDevice *>(nodeContext);

                    rl::math::Vector jointPosition = self->getJointPosition();
                    if (jointPosition.rows() != AXIS_COUNT) {
                        return UA_STATUSCODE_BADINTERNALERROR;
                    }

                    auto val = (double) jointPosition[self->nodeIdToAxisPos.at(nodeId->identifier.numeric)];
                    UA_Variant_setScalarCopy(&dataValue->value, &val, &UA_TYPES[UA_TYPES_DOUBLE]);
                    dataValue->hasValue = true;
                    return UA_STATUSCODE_GOOD;
                }

                UA_StatusCode initializeNodeIds(UA_NodeId motionDeviceId) {

                    auto robNsId = ::fortiss::opcua::UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_ROB);
                    auto forRobNsId = ::fortiss::opcua::UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_FOR_ROB);


                    flangeToolId = UA_Server_getObjectComponentId(server, motionDeviceId, UA_QUALIFIEDNAME(forRobNsId, const_cast<char *>("FlangeTool")));
                    flangeToolFrameId = UA_Server_getObjectComponentId(server, *flangeToolId.get(), UA_QUALIFIEDNAME(0, const_cast<char *>("3DFrame")));
                    flangeToolNameId = UA_Server_getObjectPropertyId(server, *flangeToolId.get(), UA_QUALIFIEDNAME(robNsId, const_cast<char *>("Name")));

                    // TODO set flange load stuff

                    std::shared_ptr<UA_NodeId> flangeToolClearMethodId = UA_Server_getObjectComponentId(server, motionDeviceId, UA_QUALIFIEDNAME(forRobNsId, const_cast<char *>("FlangeToolClear")));
                    std::shared_ptr<UA_NodeId> flangeToolSetMethodId = UA_Server_getObjectComponentId(server, motionDeviceId, UA_QUALIFIEDNAME(forRobNsId, const_cast<char *>("FlangeToolSet")));


                    UA_StatusCode retval = UA_Server_setNodeContext(server, *flangeToolClearMethodId.get(), this);
                    if (retval != UA_STATUSCODE_GOOD) {
                        return retval;
                    }

                    retval = UA_Server_setNodeContext(server, *flangeToolSetMethodId.get(), this);
                    if (retval != UA_STATUSCODE_GOOD) {
                        return retval;
                    }

                    retval = UA_Server_setMethodNode_callback(server, *flangeToolClearMethodId.get(), &OpcUAMotionDevice::flangeToolClearMethodCallback);
                    if (retval != UA_STATUSCODE_GOOD) {
                        throw std::runtime_error("Adding flangeToolClear method failed");
                    }
                    retval = UA_Server_setMethodNode_callback(server, *flangeToolSetMethodId.get(), &OpcUAMotionDevice::flangeToolSetMethodCallback);
                    if (retval != UA_STATUSCODE_GOOD) {
                        throw std::runtime_error("Adding flangeToolSet method failed");
                    }

                    return UA_STATUSCODE_GOOD;
                }

                void initializeNodeIdAxisMap(UA_NodeId motionDeviceId) {
                    // find the "Axes" node
                    // TODO do this in one step instead of two

                    auto diNsId = ::fortiss::opcua::UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_DI);
                    auto robNsId = ::fortiss::opcua::UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_ROB);

                    std::shared_ptr<UA_NodeId> axesId = UA_Server_getObjectComponentId(server, motionDeviceId, UA_QUALIFIEDNAME(robNsId, const_cast<char *>("Axes")));

                    for (unsigned i = 1; i <= AXIS_COUNT; i++) {
                        std::string axisNameStr("Axis_" + std::to_string(i));
                        const char *axisName = axisNameStr.c_str();

                        UA_BrowsePath tmpBp;
                        UA_BrowsePath_init(&tmpBp);
                        tmpBp.startingNode = *axesId.get();

                        tmpBp.relativePath.elementsSize = 3;
                        tmpBp.relativePath.elements = static_cast<UA_RelativePathElement *>(UA_Array_new(3,
                                                                                                         &UA_TYPES[UA_TYPES_RELATIVEPATHELEMENT]));
                        tmpBp.relativePath.elements[0].targetName = UA_QUALIFIEDNAME(robNsId,
                                                                                     const_cast<char *>(axisName));
                        tmpBp.relativePath.elements[0].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                        tmpBp.relativePath.elements[0].includeSubtypes = false;
                        tmpBp.relativePath.elements[0].isInverse = false;

                        tmpBp.relativePath.elements[1].targetName = UA_QUALIFIEDNAME(diNsId,
                                                                                     const_cast<char *>("ParameterSet"));
                        tmpBp.relativePath.elements[1].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                        tmpBp.relativePath.elements[1].includeSubtypes = false;
                        tmpBp.relativePath.elements[1].isInverse = false;

                        tmpBp.relativePath.elements[2].targetName = UA_QUALIFIEDNAME(robNsId,
                                                                                     const_cast<char *>("ActualPosition"));
                        tmpBp.relativePath.elements[2].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                        tmpBp.relativePath.elements[2].isInverse = false;
                        tmpBp.relativePath.elements[2].includeSubtypes = false;

                        auto positionBpr = UA_Server_translateBrowsePathToNodeIds(server, &tmpBp);
                        // we have to null the qualified names since we used const cast. Otherwise clear is trying to remove the memory and fails
                        tmpBp.relativePath.elements[0].targetName.name.data = NULL;
                        tmpBp.relativePath.elements[1].targetName.name.data = NULL;
                        tmpBp.relativePath.elements[2].targetName.name.data = NULL;
                        UA_BrowsePath_clear(&tmpBp);
                        if (positionBpr.statusCode != UA_STATUSCODE_GOOD) {
                            UA_BrowsePathResult_deleteMembers(&positionBpr);
                            throw std::runtime_error("Failed to find ActualPosition node for " + axisNameStr);
                        }

                        if (positionBpr.targetsSize != 1) {
                            UA_BrowsePathResult_deleteMembers(&positionBpr);
                            throw std::runtime_error(
                                    "Found incorrect number of ActualPosition nodes for " + axisNameStr +
                                    ". Should be 1 but is " + std::to_string(positionBpr.targetsSize));
                        }

                        nodeIdToAxisPos[positionBpr.targets[0].targetId.nodeId.identifier.numeric] = i-1;
                        // set nodeContext
                        UA_StatusCode retval = UA_Server_setNodeContext(server, positionBpr.targets[0].targetId.nodeId,
                                                                        this);
                        if (retval != UA_STATUSCODE_GOOD) {
                            UA_BrowsePathResult_deleteMembers(&positionBpr);
                            throw std::runtime_error("Unable to set node context");
                        }

                        // set DataSource for axis position
                        UA_DataSource dataSource;
                        dataSource.write = nullptr;
                        dataSource.read = readActualPosition;
                        retval = UA_Server_setVariableNode_dataSource(server,
                                positionBpr.targets[0].targetId.nodeId,                                                                                        dataSource);
                        if (retval != UA_STATUSCODE_GOOD) {
                            throw std::runtime_error("Failed to initialize data callbacks");
                        }

                        UA_BrowsePathResult_deleteMembers(&positionBpr);
                    }
                }

                static UA_StatusCode flangeToolSetMethodCallback(UA_Server *server,
                                                          const UA_NodeId *sessionId, void *sessionHandle,
                                                          const UA_NodeId *methodId, void *methodContext,
                                                          const UA_NodeId *objectId, void *objectContext,
                                                          size_t inputSize, const UA_Variant *input,
                                                          size_t outputSize, UA_Variant *output) {
                    if (!methodContext)
                        return UA_STATUSCODE_BADINTERNALERROR;
                    auto *self = static_cast<OpcUAMotionDevice *>(methodContext);

                    if (inputSize != 5) {
                        self->logger->error("FlangeToolSet invalid number of input arguments");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }

                    const UA_Variant *nameInput = &input[0];
                    const UA_Variant *frameInput = &input[1];
                    const UA_Variant *massInput = &input[2];
                    const UA_Variant *centerOfMassInput = &input[3];
                    const UA_Variant *inertiaInput = &input[4];

                    if (nameInput->type != &UA_TYPES[UA_TYPES_STRING]) {
                        self->logger->warn("Name input parameter is not of type String");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }
                    const auto *name = (const UA_String *) nameInput->data;
                    std::string nameStr((char*)name->data, name->length);



                    if (frameInput->type != &UA_TYPES[UA_TYPES_THREEDFRAME]) {
                        self->logger->warn("Start failed. Frame not correctly set in ParameterSet");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }

                    const auto *frame = (const UA_ThreeDFrame *) (frameInput->data);

                    if (massInput->type != &UA_TYPES[UA_TYPES_DOUBLE]) {
                        self->logger->warn("Mass input parameter is not of type String");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }
                    const auto *mass = (double *) massInput->data;


                    if (centerOfMassInput->type != &UA_TYPES[UA_TYPES_THREEDFRAME]) {
                        self->logger->warn("CenterOfMass input parameter is not of type Frame");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }
                    const auto *centerOfMass = (const UA_ThreeDFrame *) (centerOfMassInput->data);



                    if (inertiaInput->type != &UA_TYPES[UA_TYPES_THREEDVECTOR]) {
                        self->logger->warn("Intertia input parameter is not of type Vector");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }
                    const auto *inertia = (const UA_ThreeDVector *) (inertiaInput->data);

                    if (self->setToolCallback) {
                        bool success = self->setToolCallback(nameStr, *frame, *mass, *centerOfMass, *inertia);
                        if (!success) {
                            self->logger->error("flangeToolSet returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }

                    UA_copy(frame, &self->toolFrame, &UA_TYPES[UA_TYPES_THREEDFRAME]);
                    self->toolName = nameStr;

                    // TODO set flange load stuff

                    return UA_STATUSCODE_GOOD;
                }


                static UA_StatusCode flangeToolClearMethodCallback(UA_Server *server,
                                                                   const UA_NodeId *sessionId, void *sessionHandle,
                                                                   const UA_NodeId *methodId, void *methodContext,
                                                                   const UA_NodeId *objectId, void *objectContext,
                                                                   size_t inputSize, const UA_Variant *input,
                                                                   size_t outputSize, UA_Variant *output) {
                    if (!methodContext)
                        return UA_STATUSCODE_BADINTERNALERROR;
                    auto *self = static_cast<OpcUAMotionDevice *>(methodContext);

                    if (inputSize != 1) {
                        self->logger->error("FlangeToolClear invalid number of arguments");
                        return UA_STATUSCODE_BADINVALIDARGUMENT;
                    }

                    if (self->clearToolCallback) {
                        bool success = self->clearToolCallback();
                        if (!success) {
                            self->logger->error("FlangeToolClear returned false.");
                            return UA_STATUSCODE_BADINTERNALERROR;
                        }
                    } else {
                        return UA_STATUSCODE_BADNOTIMPLEMENTED;
                    }

                    UA_delete(&self->toolFrame, &UA_TYPES[UA_TYPES_THREEDFRAME]);
                    self->toolName = std::string();

                    return UA_STATUSCODE_GOOD;
                }

                UA_Server *server;

                // Map the NodeIds to indexes in an array of axes
                std::unordered_map<unsigned, unsigned> nodeIdToAxisPos;
            };

        }
    }
}

#endif //ROBOTICS_OPCUAROBOTCONTROL_H
