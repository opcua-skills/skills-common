//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H

#include "CartesianMoveSkillClient.h"
#include "LinearMoveSkillClient.h"

class CartesianLinearMoveSkillClient : public virtual CartesianMoveSkillClient, public virtual LinearMoveSkillClient {
public:
    explicit CartesianLinearMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam,
                                            const std::string &serverURL,
                                            UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor,
                                            const UA_NodeId &skillNodeId, unsigned short axisCount,
                                            const std::string &username = "", const std::string &password = "");

    virtual ~CartesianLinearMoveSkillClient() = default;


    virtual std::future<void> move(const UA_ThreeDFrame &targetPosition,
                                   const std::string &toolFrame,
                                   const double maxVelocity[6] = nullptr,
                                   const double maxAcceleration[6] = nullptr,
                                   const UA_Range axisBounds[] = nullptr);

private:


protected:
};


#endif //ROBOTICS_CARTESIANLINEARMOVESKILLCLIENT_H
