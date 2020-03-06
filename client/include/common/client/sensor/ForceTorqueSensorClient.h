//
// Created by breitkreuz on 5/03/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef PROJECT_FORCETORQUESENSORCLIENT_H
#define PROJECT_FORCETORQUESENSORCLIENT_H

#include "open62541/client.h"
#include "rl/math/Vector.h"
#include <memory>
#include <spdlog/logger.h>

class ForceTorqueSensorClient {
public:

    // Sets up a monitored item
    explicit ForceTorqueSensorClient(std::shared_ptr<spdlog::logger> logger, const std::string &serverURL,
                                     UA_UInt16 nsIdxForRobDevice, const UA_NodeId &sensorNodeId);

    // returns {forceX, forceY, forceZ}
    const rl::math::Vector3 getForce() const;

    // returns {torqueX, torqueY, torqueZ}
    const rl::math::Vector3 getTorque() const;

    // returns {forceX, forceY, forceZ, torqueX, torqueY, torqueZ}
    const rl::math::Vector6 getForceTorque() const;

    void step();

private:
    void initializeNodeIds(const UA_NodeId &sensorNodeId, UA_UInt16 nsIdxForRobDevice);

    void readForce();

    void readTorque();

    std::shared_ptr<spdlog::logger> logger;

    std::shared_ptr<UA_Client> client;

    UA_NodeId forcesId;
    UA_NodeId torquesId;

    // forceTorque is read with a monitored item
    rl::math::Vector6 forceTorque;
};


#endif //PROJECT_FORCETORQUESENSORCLIENT_H
