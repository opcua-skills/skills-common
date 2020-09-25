/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_CARTESIANLINEARFORCEMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANLINEARFORCEMOVESKILLCLIENT_H

#include "CartesianLinearMoveSkillClient.h"
#include "ForceSkillClient.h"


class CartesianLinearForceMoveSkillClient : public virtual CartesianLinearMoveSkillClient,
                                            public virtual ForceSkillClient {
public:
    explicit CartesianLinearForceMoveSkillClient(
            const std::shared_ptr<spdlog::logger>& loggerApp,
            const std::shared_ptr<spdlog::logger>& loggerOpcua,
            const std::string& serverURL,
            UA_UInt16 nsIdxDi,
            UA_UInt16 nsIdxRobFor,
            const UA_NodeId& skillNodeId,
            unsigned short axisCount,
            const std::string& username = "",
            const std::string& password = "",
            const std::string& clientCertPath = "",
            const std::string& clientKeyPath = "",
            const std::string& clientAppUri = "",
            const std::string& clientAppName = ""
    );

    virtual ~CartesianLinearForceMoveSkillClient() = default;


    virtual std::future<std::array<double, 3>> moveForce(
            const UA_ThreeDFrame& targetPosition,
            const std::string& toolFrame,
            const double maxVelocity[6] = nullptr,
            const double maxAcceleration[6] = nullptr,
            UA_ThreeDVector maxForce = {0, 0, 0},
            const UA_Range axisBounds[] = nullptr
    );

private:


protected:
};


#endif //ROBOTICS_CARTESIANLINEARFORCEMOVESKILLCLIENT_H
