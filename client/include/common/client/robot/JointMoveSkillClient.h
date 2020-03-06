//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_JOINTMOVESKILLCLIENT_H
#define ROBOTICS_JOINTMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class JointMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit JointMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                  UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                  const UA_NodeId &skillNodeId, unsigned short axisCount,
                                  const std::string &username = "", const std::string &password = "");

    virtual ~JointMoveSkillClient();

protected:
    const unsigned short axisCount;
private:
    SkillClientParameter *targetJointPositionParameter = nullptr;


protected:
    const UA_StatusCode setTargetJointPosition(const double targetJointPosition[]);
};


#endif //ROBOTICS_JOINTMOVESKILLCLIENT_H
