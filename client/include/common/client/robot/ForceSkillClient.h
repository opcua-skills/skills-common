/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_FORCESKILLCLIENT_H
#define ROBOTICS_FORCESKILLCLIENT_H

#include <common/client/SkillClient.h>

class ForceSkillClient : virtual SkillClient {
public:
    explicit ForceSkillClient(
            const std::shared_ptr<spdlog::logger>& loggerApp,
            const std::shared_ptr<spdlog::logger>& loggerOpcua,
            const std::string& serverURL,
            UA_UInt16 nsIdxDi,
            UA_UInt16 nsIdxRobFor,
            const UA_NodeId& skillNodeId,
            const std::string& username = "",
            const std::string& password = "",
            const std::string& clientCertPath = "",
            const std::string& clientKeyPath = "",
            const std::string& clientAppUri = "",
            const std::string& clientAppName = ""
    );

    virtual ~ForceSkillClient();

    std::array<double, 3> readForcesExceeded();

    std::array<double, 3> readForcesMax();

protected:
private:
    SkillClientParameter* maxForceParameter = nullptr;

    UA_NodeId forcesExceeded;
    UA_NodeId forcesMax;

protected:
    const UA_StatusCode setMaxForce(const UA_ThreeDVector force);

};


#endif //ROBOTICS_FORCESKILLCLIENT_H
