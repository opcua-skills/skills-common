//
// Created by breitkreuz on 10/07/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_FORCESKILLCLIENT_H
#define ROBOTICS_FORCESKILLCLIENT_H

#include <common/client/SkillClient.h>

class ForceSkillClient : virtual SkillClient {
public:
    explicit ForceSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                              UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor, const UA_NodeId &skillNodeId,
                              const std::string &username = "", const std::string &password = "");

    virtual ~ForceSkillClient();

    std::array<double, 3> readForcesExceeded();
    std::array<double, 3> readForcesMax();

protected:
private:
    SkillClientParameter *maxForceParameter = nullptr;

    UA_NodeId forcesExceeded;
    UA_NodeId forcesMax;

protected:
    const UA_StatusCode setMaxForce(const UA_ThreeDVector force);

};


#endif //ROBOTICS_FORCESKILLCLIENT_H
