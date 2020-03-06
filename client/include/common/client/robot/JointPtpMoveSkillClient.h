//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_JOINTPTPMOVESKILLCLIENT_H
#define ROBOTICS_JOINTPTPMOVESKILLCLIENT_H

#include "JointMoveSkillClient.h"
#include "PtpMoveSkillClient.h"

class JointPtpMoveSkillClient : public virtual JointMoveSkillClient, public virtual PtpMoveSkillClient {
public:
    explicit JointPtpMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                     UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                     const UA_NodeId &skillNodeId, unsigned short axisCount,
                                     const std::string &username = "", const std::string &password = "");

    virtual ~JointPtpMoveSkillClient() = default;


    virtual std::future<void> move(const double targetJointPosition[],
                                   const std::string &toolFrame,
                                   const double maxVelocity[] = nullptr,
                                   const double maxAcceleration[] = nullptr);

private:


protected:
};


#endif //ROBOTICS_JOINTPTPMOVESKILLCLIENT_H
