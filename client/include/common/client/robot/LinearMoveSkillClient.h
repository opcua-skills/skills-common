/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_LINEARMOVESKILLCLIENT_H
#define ROBOTICS_LINEARMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class LinearMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit LinearMoveSkillClient(
            const std::shared_ptr<spdlog::logger>& loggerApp,
            const std::shared_ptr<spdlog::logger>& loggerOpcua,
            const std::string& serverURL,
            UA_UInt16 nsIdxDi,
            UA_UInt16 nsIdxRobFor,
            const UA_NodeId& skillNodeId,
            const std::string& username = "",
            const std::string& password = "",
            const std::string& clientCertPath = "",
            const std::string& clientKeyPath = "",
            const std::string& clientAppUri = "",
            const std::string& clientAppName = ""
    );

    virtual ~LinearMoveSkillClient();

private:
    SkillClientParameter* maxAccelerationParameter = nullptr;
    SkillClientParameter* maxVelocityParameter = nullptr;

protected:
    const UA_StatusCode setMaxAcceleration(const double maxAcceleration[6]);

    const UA_StatusCode setMaxVelocity(const double maxVelocity[6]);
};


#endif //ROBOTICS_LINEARMOVESKILLCLIENT_H
