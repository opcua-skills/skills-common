/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_PTPMOVESKILLCLIENT_H
#define ROBOTICS_PTPMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class PtpMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit PtpMoveSkillClient(
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

    virtual ~PtpMoveSkillClient();

private:
    SkillClientParameter* maxAccelerationParameter = nullptr;
    SkillClientParameter* maxVelocityParameter = nullptr;

    unsigned short axisCount;

protected:
    const UA_StatusCode setMaxAcceleration(const double maxAcceleration[]);

    const UA_StatusCode setMaxVelocity(const double maxVelocity[]);
};


#endif //ROBOTICS_PTPMOVESKILLCLIENT_H
