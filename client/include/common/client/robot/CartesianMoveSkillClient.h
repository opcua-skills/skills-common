/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_CARTESIANMOVESKILLCLIENT_H
#define ROBOTICS_CARTESIANMOVESKILLCLIENT_H

#include "MoveSkillClient.h"

class CartesianMoveSkillClient : public virtual MoveSkillClient {
public:
    explicit CartesianMoveSkillClient(
            const std::shared_ptr<spdlog::logger>& loggerApp,
            const std::shared_ptr<spdlog::logger>& loggerOpcua,
            const std::string& serverURL,
            UA_UInt16 nsIdxDi,
            UA_UInt16 nsIdxRobFor,
            const UA_NodeId& skillNodeId,
            unsigned short axisCount,
            const std::string& username = "",
            const std::string& password = "",
            const std::string& clientCertPath = "",
            const std::string& clientKeyPath = "",
            const std::string& clientAppUri = "",
            const std::string& clientAppName = ""
    );

    virtual ~CartesianMoveSkillClient();

protected:
    const unsigned short axisCount;
private:
    SkillClientParameter* targetPositionParameter = nullptr;
    SkillClientParameter* axisBoundsParameter = nullptr;


protected:
    const UA_StatusCode setTargetPosition(const UA_ThreeDFrame& targetPosition);

    const UA_StatusCode setAxisBounds(const UA_Range axisBounds[]);
};


#endif //ROBOTICS_CARTESIANMOVESKILLCLIENT_H
