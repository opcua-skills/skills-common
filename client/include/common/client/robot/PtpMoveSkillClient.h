//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_PTPMOVESKILLCLIENT_H
#define ROBOTICS_PTPMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class PtpMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit PtpMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                const UA_NodeId &skillNodeId, unsigned short axisCount,
                                const std::string &username  = "", const std::string &password = "");

    virtual ~PtpMoveSkillClient();

private:
    SkillClientParameter *maxAccelerationParameter = nullptr;
    SkillClientParameter *maxVelocityParameter = nullptr;

    unsigned short axisCount;

protected:
    const UA_StatusCode setMaxAcceleration(const double maxAcceleration[]);

    const UA_StatusCode setMaxVelocity(const double maxVelocity[]);
};


#endif //ROBOTICS_PTPMOVESKILLCLIENT_H
