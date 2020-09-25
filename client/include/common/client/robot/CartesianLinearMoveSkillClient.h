/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H

#include "CartesianMoveSkillClient.h"
#include "LinearMoveSkillClient.h"

class CartesianLinearMoveSkillClient : public virtual CartesianMoveSkillClient, public virtual LinearMoveSkillClient {
public:
    explicit CartesianLinearMoveSkillClient(
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

    virtual ~CartesianLinearMoveSkillClient() = default;


    virtual std::future<void> move(
            const UA_ThreeDFrame& targetPosition,
            const std::string& toolFrame,
            const double maxVelocity[6] = nullptr,
            const double maxAcceleration[6] = nullptr,
            const UA_Range axisBounds[] = nullptr
    );

private:


protected:
};


#endif //ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H
