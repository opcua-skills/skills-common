//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_CARTESIANPTPMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANPTPMOVESKILLCLIENT_H

#include "CartesianMoveSkillClient.h"
#include "PtpMoveSkillClient.h"

class CartesianPtpMoveSkillClient : public virtual CartesianMoveSkillClient, public virtual PtpMoveSkillClient {
public:
    explicit CartesianPtpMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                         const std::string &serverURL,
                                         UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                         const UA_NodeId &skillNodeId, unsigned short axisCount,
                                         const std::string &username = "", const std::string &password = "");

    virtual ~CartesianPtpMoveSkillClient() = default;


    virtual std::future<void> move(const UA_ThreeDFrame &targetPosition,
                                   const std::string &toolFrame,
                                   const double maxVelocity[] = nullptr,
                                   const double maxAcceleration[] = nullptr,
                                   const UA_Range axisBounds[] = nullptr);

private:


protected:
};


#endif //ROBOTICS_CARTESIANPTPMOVESKILLCLIENT_H
