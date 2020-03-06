//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_JOINTLINEARMOVESKILLCLIENT_H
#define ROBOTICS_JOINTLINEARMOVESKILLCLIENT_H

#include "JointMoveSkillClient.h"
#include "LinearMoveSkillClient.h"

class JointLinearMoveSkillClient : public virtual JointMoveSkillClient, public virtual LinearMoveSkillClient {
public:
    explicit JointLinearMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                        const std::string &serverURL,
                                        UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                        const UA_NodeId &skillNodeId, unsigned short axisCount,
                                        const std::string &username = "", const std::string &password = "");

    virtual ~JointLinearMoveSkillClient() = default;


    virtual std::future<void> move(const double targetJointPosition[],
                                   const std::string &toolFrame,
                                   const double maxVelocity[6] = nullptr,
                                   const double maxAcceleration[6] = nullptr);

private:


protected:
};


#endif //ROBOTICS_JOINTLINEARMOVESKILLCLIENT_H
