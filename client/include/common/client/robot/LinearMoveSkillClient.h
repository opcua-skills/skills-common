//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_LINEARMOVESKILLCLIENT_H
#define ROBOTICS_LINEARMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class LinearMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit LinearMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                   UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor, const UA_NodeId &skillNodeId,
                                   const std::string &username = "", const std::string &password = "");

    virtual ~LinearMoveSkillClient();

private:
    SkillClientParameter *maxAccelerationParameter = nullptr;
    SkillClientParameter *maxVelocityParameter = nullptr;

protected:
    const UA_StatusCode setMaxAcceleration(const double maxAcceleration[6]);

    const UA_StatusCode setMaxVelocity(const double maxVelocity[6]);
};


#endif //ROBOTICS_LINEARMOVESKILLCLIENT_H
