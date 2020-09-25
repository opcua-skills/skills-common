/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_JOINTMOVESKILLCLIENT_H
#define ROBOTICS_JOINTMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class JointMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit JointMoveSkillClient(
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

    virtual ~JointMoveSkillClient();

protected:
    const unsigned short axisCount;
private:
    SkillClientParameter* targetJointPositionParameter = nullptr;


protected:
    const UA_StatusCode setTargetJointPosition(const double targetJointPosition[]);
};


#endif //ROBOTICS_JOINTMOVESKILLCLIENT_H
