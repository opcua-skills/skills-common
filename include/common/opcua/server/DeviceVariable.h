/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef FORTISS_ROBOTICS_DEVICEVARIABLE_H
#define FORTISS_ROBOTICS_DEVICEVARIABLE_H

#include "OpcUaServer.h"

#include <memory>


namespace fortiss {

    namespace opcua {

        class DeviceVariable {

        public:
            UA_DataValue dataValue;
            UA_DataValue *dataValuePtr;

            explicit DeviceVariable(
                    const std::shared_ptr<fortiss::opcua::OpcUaServer>& server,
                    const UA_DataType* type,
                    void* value,
                    const UA_NodeId nodeId,
                    size_t arrayLength = 0,
                    size_t arrayDimensionsSize = 0,
                    UA_UInt32 *arrayDimensions = NULL
            );

            explicit DeviceVariable(
                    UA_Server* server,
                    const UA_DataType* type,
                    void* value,
                    const UA_NodeId nodeId,
                    size_t arrayLength = 0,
                    size_t arrayDimensionsSize = 0,
                    UA_UInt32 *arrayDimensions = NULL
            );

            static UA_StatusCode NotificationRead(UA_Server *server, const UA_NodeId *sessionId,
                                                  void *sessionContext, const UA_NodeId *nodeid,
                                                  void *nodeContext, const UA_NumericRange *range);
        };
    }
}

#endif //FORTISS_ROBOTICS_DEVICEVARIABLE_H
