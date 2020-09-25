/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef PROJECT_FORCETORQUESENSOR_HPP
#define PROJECT_FORCETORQUESENSOR_HPP

#include <rl/hal/SixAxisForceTorqueSensor.h>
#include <rl/math/Vector.h>
#include <rl/hal/CyclicDevice.h>
#include "common/opcua/helper.hpp"
#include "ForceTorqueSensorSim.hpp"

#include <open62541/server.h>

namespace fortiss {
    namespace opcua {
        template<typename T>
        class ForceTorqueSensor {
            static_assert(std::is_base_of<rl::hal::CyclicDevice, T>::value &&
                          std::is_base_of<rl::hal::SixAxisForceTorqueSensor, T>::value,
                          "Type passed to OpcUAForceTorqueSensor is not derived from rl::hal::CyclicDevice and rl::hal::SixAxisForceTorqueSensor");

        public:
            explicit ForceTorqueSensor(UA_Server *server, std::shared_ptr<spdlog::logger> &logger, const bool sim,
                                       UA_NodeId sensorId, const std::string &ip, const unsigned short port,
                                       const double forceExpectedVal = 30, const double forceStandardDev = 2,
                                       const double torqueExpectedVal = 30, const double torqueStandardDev = 2,
                                       const std::chrono::nanoseconds updateRate = std::chrono::nanoseconds(0))
                    : server(server), forceArray{}, torqueArray{}, logger(logger) {
                if (sim) {
                    component = std::make_unique<ForceTorqueSensorSim>(forceExpectedVal, forceStandardDev,
                                                                       torqueExpectedVal, torqueStandardDev,
                                                                       updateRate);
                } else {
                    component = std::make_unique<T>(ip, port);
                }
                component->open();
                component->start();

                initNodeIds(sensorId);

                // set up data callback
                UA_DataSource dataSource;
                dataSource.write = nullptr;

                // force
                dataSource.read = readForceArray;
                UA_StatusCode retval = UA_Server_setVariableNode_dataSource(server, forceArray, dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    std::string error = "Failed to set up data source for force array, statuscode " +
                                        std::string(UA_StatusCode_name(retval));
                    logger->critical(error);
                    throw std::runtime_error(error);
                }

                // torque
                dataSource.read = readTorqueArray;
                retval = UA_Server_setVariableNode_dataSource(server, torqueArray, dataSource);
                if (retval != UA_STATUSCODE_GOOD) {
                    std::string error = "Failed to set up data source for torque array, statuscode " +
                                        std::string(UA_StatusCode_name(retval));
                    logger->critical(error);
                    throw std::runtime_error(error);
                }
            }

            ~ForceTorqueSensor() {
                component->stop();
                component->close();
            }

            auto inline getForceTorques() const {
                return component->getForcesTorques();
            }

            void step() {
                dynamic_cast<rl::hal::CyclicDevice &>(*component).step();
            }

        protected:

        private:
            void initNodeIds(UA_NodeId sensorId) {
                auto nsForDi = UA_Server_getNamespaceIdByName(server, NAMESPACE_URI_FOR_DI);

                // Force array
                UA_BrowsePath bp;
                UA_BrowsePath_init(&bp);
                bp.startingNode = sensorId;

                bp.relativePath.elementsSize = 2;
                bp.relativePath.elements = static_cast<UA_RelativePathElement *>(UA_Array_new(2,
                                                                                              &UA_TYPES[UA_TYPES_RELATIVEPATHELEMENT]));
                bp.relativePath.elements[0].targetName = UA_QUALIFIEDNAME(nsForDi, const_cast<char *>("ForceSensor"));
                bp.relativePath.elements[0].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                bp.relativePath.elements[0].includeSubtypes = false;
                bp.relativePath.elements[0].isInverse = false;

                bp.relativePath.elements[1].targetName = UA_QUALIFIEDNAME(nsForDi, const_cast<char *>("Force"));
                bp.relativePath.elements[1].referenceTypeId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                bp.relativePath.elements[1].includeSubtypes = false;
                bp.relativePath.elements[1].isInverse = false;

                auto bpr = UA_Server_translateBrowsePathToNodeIds(server, &bp);

                if (bpr.statusCode != UA_STATUSCODE_GOOD) {
                    UA_StatusCode tmp = bpr.statusCode;
                    UA_BrowsePathResult_clear(&bpr);
                    throw std::runtime_error("Unable to find \"Force\" array, statuscode " +
                                             std::string(UA_StatusCode_name(tmp)));
                }

                if (bpr.targetsSize != 1) {
                    UA_BrowsePathResult_clear(&bpr);
                    throw std::runtime_error("Found incorrect number of \"Force\" array, should be 1 but is " +
                                             std::to_string(bpr.targetsSize));
                }

                forceArray = bpr.targets[0].targetId.nodeId;
                UA_Server_setNodeContext(server, forceArray, this);
                UA_BrowsePathResult_clear(&bpr);

                // Torque array
                bp.relativePath.elements[0].targetName = UA_QUALIFIEDNAME(nsForDi, const_cast<char *>("TorqueSensor"));
                bp.relativePath.elements[1].targetName = UA_QUALIFIEDNAME(nsForDi, const_cast<char *>("Torque"));

                bpr = UA_Server_translateBrowsePathToNodeIds(server, &bp);

                if (bpr.statusCode != UA_STATUSCODE_GOOD) {
                    UA_StatusCode tmp = bpr.statusCode;
                    UA_BrowsePathResult_clear(&bpr);
                    throw std::runtime_error(
                            "Unable to find \"Torque\" array, statuscode " + std::string(UA_StatusCode_name(tmp)));
                }

                if (bpr.targetsSize != 1) {
                    UA_BrowsePathResult_clear(&bpr);
                    throw std::runtime_error("Found incorrect number of \"Torque\" array, should be 1 but is " +
                                             std::to_string(bpr.targetsSize));
                }

                torqueArray = bpr.targets[0].targetId.nodeId;
                UA_Server_setNodeContext(server, torqueArray, this);

                UA_BrowsePathResult_clear(&bpr);

                bp.relativePath.elements[0].targetName.name.data = nullptr;
                bp.relativePath.elements[1].targetName.name.data = nullptr;
                UA_BrowsePath_clear(&bp);
            }

            static UA_StatusCode
            readTorqueArray(UA_Server *server, const UA_NodeId *sessionId, void *sessionContext,
                            const UA_NodeId *nodeId, void *nodeContext, UA_Boolean sourceTimeStamp,
                            const UA_NumericRange *range, UA_DataValue *dataValue) {
                auto self = static_cast<ForceTorqueSensor *>(nodeContext);
                auto measures = self->component->getForcesTorques();

                UA_StatusCode retval = UA_Variant_setArrayCopy(&dataValue->value, &measures[3], 3,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD) {
                    self->logger->warn("Copying torque value returned statuscode {}", retval);
                    return retval;
                }
                dataValue->hasValue = true;

                return UA_STATUSCODE_GOOD;
            }

            static UA_StatusCode
            readForceArray(UA_Server *server, const UA_NodeId *sessionId, void *sessionContext,
                           const UA_NodeId *nodeId, void *nodeContext, UA_Boolean sourceTimeStamp,
                           const UA_NumericRange *range, UA_DataValue *dataValue) {
                auto self = static_cast<ForceTorqueSensor *>(nodeContext);
                auto measures = self->component->getForcesTorques();

                UA_StatusCode retval = UA_Variant_setArrayCopy(&dataValue->value, &measures[0], 3, &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD) {
                    self->logger->warn("Copying force value returned statuscode {}", retval);
                    return retval;
                }
                dataValue->hasValue = true;

                return UA_STATUSCODE_GOOD;
            }

            std::unique_ptr<rl::hal::SixAxisForceTorqueSensor> component;

            UA_Server *server;

            // {forceX, forceY, forceZ}
            UA_NodeId forceArray{};
            // {torqueX, torqueY, torqueZ}
            UA_NodeId torqueArray{};

            std::shared_ptr<spdlog::logger> logger;
        };
    }
}

#endif //PROJECT_FORCETORQUESENSOR_HPP
