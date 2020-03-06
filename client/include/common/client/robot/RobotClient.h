//
// Created by profanter on 12/20/18.
// Copyright (c) 2018 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_CS_CLIENT_ROBOTCLIENT_H
#define ROBOTICS_CS_CLIENT_ROBOTCLIENT_H


#include <open62541/types.h>
#include <open62541/types_generated.h>
#include <types_rob_generated.h>
#include <memory>
#include <spdlog/spdlog.h>

#include "CartesianLinearMoveSkillClient.h"
#include "CartesianPtpMoveSkillClient.h"
#include "JointLinearMoveSkillClient.h"
#include "JointPtpMoveSkillClient.h"
#include "CartesianLinearForceMoveSkillClient.h"

class MoveAxisSkillClient;
class MovePositionSkillClient;
class MovePositionForceSkillClient;

struct UA_Client;
typedef UA_Client UA_Client;

class RobotClient {
public:
    explicit RobotClient(std::shared_ptr<spdlog::logger> logger, const std::string &serverURL,
                         const std::string &username = "", const std::string &password = "");
    virtual ~RobotClient();

    CartesianLinearMoveSkillClient *cartesianLinearMoveSkillClient = nullptr;
    CartesianPtpMoveSkillClient *cartesianPtpMoveSkillClient = nullptr;
    JointLinearMoveSkillClient *jointLinearMoveSkillClient = nullptr;
    JointPtpMoveSkillClient *jointPtpMoveSkillClient = nullptr;
    CartesianLinearForceMoveSkillClient *cartesianLinearForceMoveSkillClient = nullptr;

    void start();
    void stop();

    size_t getAxesCount() { return axesCount; };

    UA_StatusCode setTool(const std::string &name, const UA_ThreeDFrame &frame, const double mass, const UA_ThreeDFrame &centerOfMass, const UA_ThreeDVector &inertia);
    UA_StatusCode setLed(bool on);
    UA_StatusCode clearTool();

    std::string getMotionSystemDisplayName();
protected:

    std::shared_ptr<spdlog::logger> logger;

    std::shared_ptr<UA_Client> client;
    std::mutex clientMutex;

private:

    std::thread stepperThread;
    bool running = false;

    std::string serverURL;

    UA_UInt16 nsIdxDi = 0;
    UA_UInt16 nsIdxRob = 0;
    UA_UInt16 nsIdxRobFor = 0;
    UA_UInt16 nsIdxDeviceFor = 0;

    UA_NodeId motionSystemId = UA_NODEID_NULL;
    UA_NodeId controllersId = UA_NODEID_NULL;
    UA_NodeId controllerId = UA_NODEID_NULL;
    UA_NodeId skillsId = UA_NODEID_NULL;

    UA_NodeId cartesianLinearMoveSkillId = UA_NODEID_NULL;
    UA_NodeId cartesianPtpMoveSkillId = UA_NODEID_NULL;
    UA_NodeId jointLinearMoveSkillId = UA_NODEID_NULL;
    UA_NodeId jointPtpMoveSkillId = UA_NODEID_NULL;
    UA_NodeId cartesianLinearForceMoveSkillId = UA_NODEID_NULL;

    UA_NodeId motionDevicesId = UA_NODEID_NULL;
    UA_NodeId motionDeviceId = UA_NODEID_NULL;
    UA_NodeId axesId = UA_NODEID_NULL;
    UA_NodeId ledId = UA_NODEID_NULL;
    UA_NodeId flangeToolClearMethodId = UA_NODEID_NULL;
    UA_NodeId flangeToolSetMethodId = UA_NODEID_NULL;

    UA_NodeId *axesIds = nullptr;
    size_t axesCount = 0;

    UA_StatusCode initializeNodeIds();


    void threadRun();
};


#endif //ROBOTICS_CS_CLIENT_ROBOTCLIENT_H
