//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_CARTESIANMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class CartesianMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit CartesianMoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                      UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor, const UA_NodeId &skillNodeId,
                                      unsigned short axisCount, const std::string &username = "",
                                      const std::string &password = "");

    virtual ~CartesianMoveSkillClient();

protected:
    const unsigned short axisCount;
private:
    SkillClientParameter *targetPositionParameter = nullptr;
    SkillClientParameter *axisBoundsParameter = nullptr;


protected:
    const UA_StatusCode setTargetPosition(const UA_ThreeDFrame &targetPosition);

    const UA_StatusCode setAxisBounds(const UA_Range axisBounds[]);
};


#endif //ROBOTICS_CARTESIANMOVESKILLCLIENT_H
