//
// Created by profanter on 12/20/18.
// Copyright (c) 2018 fortiss GmbH. All rights reserved.
//

#include <common/client/robot/RobotClient.h>


#include <memory>
#include <spdlog/spdlog.h>
#include "common/opcua/helper.hpp"
#include "common/logging_opcua.h"


#define NAMESPACE_URI_DI "http://opcfoundation.org/UA/DI/"
#define NAMESPACE_URI_ROB "http://opcfoundation.org/UA/Robotics/"
#define NAMESPACE_URI_FOR_ROB "https://fortiss.org/UA/Robotics/"


#include "rob_nodeids.h"
#include "for_rob_nodeids.h"
#include <di_nodeids.h>
#include <open62541/client_highlevel.h>
#include <open62541/client_config_default.h>

//#include "MovePositionForceSkillClient.h"

RobotClient::RobotClient(std::shared_ptr<spdlog::logger> loggerParam, const std::string &serverURL,
        const std::string &username, const std::string &password) :
        logger(std::move(loggerParam)), clientMutex(), serverURL(serverURL) {


    client = std::shared_ptr<UA_Client>(UA_Client_new(), [=](UA_Client *client) {
        UA_Client_disconnect(client);
        UA_Client_delete(client);
    });
    UA_ClientConfig *clientConfig = UA_Client_getConfig(client.get());
    UA_ClientConfig_setDefault(clientConfig);
    clientConfig->logger.log = fortiss::log::opcua::UA_Log_Spdlog_log;
    clientConfig->logger.context = logger.get();
    clientConfig->logger.clear = fortiss::log::opcua::UA_Log_Spdlog_clear;


    UA_StatusCode retval;
    if (username.empty()) {
        if (!password.empty()) {
            logger->warn("Password provided but no user. Attempting to connect without login...");
        } else {
            logger->info("Attempting to connect without login...");
        }
        retval = UA_Client_connect(client.get(), serverURL.c_str());
    } else {
        logger->info("Attempting to connect with username: {}", username);
        retval = UA_Client_connect_username(client.get(), serverURL.c_str(), username.c_str(), password.c_str());
    }

    if (retval != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Can not connect to server " + serverURL + ". Error: " + UA_StatusCode_name(retval));
    } else {
        logger->info("Connected");
    }

    if (initializeNodeIds() != UA_STATUSCODE_GOOD) {
        throw std::runtime_error("Can not initialize node ids");
    }

    cartesianLinearMoveSkillClient = new CartesianLinearMoveSkillClient(logger, serverURL, nsIdxDi, nsIdxRobFor, cartesianLinearMoveSkillId,
                                        (unsigned short) axesCount, username, password);
    cartesianLinearMoveSkillClient->disconnect();
    cartesianPtpMoveSkillClient = new CartesianPtpMoveSkillClient(logger, serverURL, nsIdxDi, nsIdxRobFor, cartesianPtpMoveSkillId,
                                                                  (unsigned short) axesCount, username, password);
    cartesianPtpMoveSkillClient->disconnect();
    
    jointLinearMoveSkillClient = new JointLinearMoveSkillClient(logger, serverURL, nsIdxDi, nsIdxRobFor, jointLinearMoveSkillId,
                                        (unsigned short) axesCount, username, password);
    jointLinearMoveSkillClient->disconnect();
    jointPtpMoveSkillClient = new JointPtpMoveSkillClient(logger, serverURL, nsIdxDi, nsIdxRobFor, jointPtpMoveSkillId,
                                        (unsigned short) axesCount, username, password);
    jointPtpMoveSkillClient->disconnect();

    // This skill is optional
    if (!UA_NodeId_isNull(&cartesianLinearForceMoveSkillId)) {
        cartesianLinearForceMoveSkillClient =
                new CartesianLinearForceMoveSkillClient(logger, serverURL, nsIdxDi, nsIdxRobFor,
                                                        cartesianLinearForceMoveSkillId, (unsigned short) axesCount,
                                                        username, password);
    }

    //axisSkill->reset();
    //positionSkill->reset();

}

RobotClient::~RobotClient() {
    stop();
    if (stepperThread.joinable()) {
        stepperThread.join();
    }

    UA_Array_delete(axesIds, axesCount, &UA_TYPES[UA_TYPES_NODEID]);

    delete cartesianLinearMoveSkillClient;

    delete cartesianPtpMoveSkillClient;

    delete jointLinearMoveSkillClient;

    delete jointPtpMoveSkillClient;

    delete cartesianLinearForceMoveSkillClient;
}

UA_StatusCode RobotClient::initializeNodeIds() {

    std::lock_guard<std::mutex> lk(clientMutex);
    // Get NsIDX for DI
    UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_DI);
    UA_StatusCode retval = UA_Client_NamespaceGetIndex(client.get(), &nsUri, &nsIdxDi);
    UA_String_clear(&nsUri);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not get namespace index for {}. Error {}", NAMESPACE_URI_DI, UA_StatusCode_name(retval));
        return retval;
    }

    // Get NsIDX for ROB
    nsUri = UA_String_fromChars(NAMESPACE_URI_ROB);
    retval = UA_Client_NamespaceGetIndex(client.get(), &nsUri, &nsIdxRob);
    UA_String_clear(&nsUri);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not get namespace index for {}. Error {}", NAMESPACE_URI_ROB, UA_StatusCode_name(retval));
        return retval;
    }

    // Get NsIDX for fortiss Robotics
    nsUri = UA_String_fromChars(NAMESPACE_URI_FOR_DI);
    retval = UA_Client_NamespaceGetIndex(client.get(), &nsUri, &nsIdxDeviceFor);
    UA_String_clear(&nsUri);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not get namespace index for {}. Error {}", NAMESPACE_URI_FOR_DI,
                      UA_StatusCode_name(retval));
        return retval;
    }

    // Get NsIDX for fortiss Robotics
    nsUri = UA_String_fromChars(NAMESPACE_URI_FOR_ROB);
    retval = UA_Client_NamespaceGetIndex(client.get(), &nsUri, &nsIdxRobFor);
    UA_String_clear(&nsUri);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not get namespace index for {}. Error {}", NAMESPACE_URI_FOR_ROB,
                      UA_StatusCode_name(retval));
        return retval;
    }


    bool found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger,
                                                           UA_NODEID_NUMERIC(nsIdxDi, UA_DIID_DEVICESET),
                                                           UA_NODEID_NUMERIC(nsIdxRob, UA_ROBID_MOTIONDEVICESYSTEMTYPE),
                                                           &motionSystemId);

    if (!found) {
        if (!UA_NodeId_isNull(&motionSystemId)) {
            logger->error(
                    "There are multiple MotionDeviceSystemType Objects on the server. This is currently not supported.");
        } else {
            logger->error("No MotionDeviceSystemType found on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, motionSystemId,
                                                              UA_QUALIFIEDNAME(nsIdxRob,
                                                                               const_cast<char *>("MotionDevices")),
                                                              &motionDevicesId);
    if (!found) {
        if (!UA_NodeId_isNull(&motionDevicesId)) {
            logger->error("There are multiple 'MotionDevices' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'MotionDevices' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, motionDevicesId,
                                                      UA_NODEID_NUMERIC(nsIdxRobFor,
                                                                        UA_FOR_ROBID_FORTISSMOTIONDEVICETYPE),
                                                      &motionDeviceId);
    if (!found) {
        if (!UA_NodeId_isNull(&motionDeviceId)) {
            logger->error(
                    "There are multiple MotionDeviceType Objects on the server. This is currently not supported.");
        } else {
            logger->error("No MotionDeviceType found on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, motionDeviceId,
                                                              UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                               const_cast<char *>("FlangeToolClear")),
                                                              &flangeToolClearMethodId);
    if (!found) {
        if (!UA_NodeId_isNull(&flangeToolClearMethodId)) {
            logger->error("There are multiple 'FlangeToolClear' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'FlangeToolClear' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, motionDeviceId,
                                                              UA_QUALIFIEDNAME(nsIdxRobFor,
                                                                               const_cast<char *>("FlangeToolSet")),
                                                              &flangeToolSetMethodId);
    if (!found) {
        if (!UA_NodeId_isNull(&flangeToolSetMethodId)) {
            logger->error("There are multiple 'FlangeToolSet' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'FlangeToolSet' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, motionDeviceId,
                                                              UA_QUALIFIEDNAME(nsIdxRob, const_cast<char *>("Axes")),
                                                              &axesId);
    if (!found) {
        if (!UA_NodeId_isNull(&axesId)) {
            logger->error("There are multiple 'Axes' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'Axes' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithName(client.get(), logger, motionDeviceId,
                                                        UA_STRING(const_cast<char *>("Led")),
                                                        &ledId);
    if (!found) {
        if (!UA_NodeId_isNull(&ledId)) {
            logger->error("There are multiple 'Led' nodes on the server. This is currently not supported.");
            return UA_STATUSCODE_BADNOTFOUND;
        }
    }


    fortiss::opcua::UA_Client_findChildrenOfType(client.get(), logger, axesId,
                                                 UA_NODEID_NUMERIC(nsIdxRob,
                                                                   UA_ROBID_AXISTYPE),
                                                 &axesIds, &axesCount);
    if (axesCount == 0) {
        logger->error("Robot does not contain any axes inside the 'Axes' node.");
        return UA_STATUSCODE_BADNOTFOUND;
    }


    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, motionSystemId,
                                                              UA_QUALIFIEDNAME(nsIdxRob,
                                                                               const_cast<char *>("Controllers")),
                                                              &controllersId);
    if (!found) {
        if (!UA_NodeId_isNull(&controllersId)) {
            logger->error("There are multiple 'Controllers' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'Controllers' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, controllersId,
                                                      UA_NODEID_NUMERIC(nsIdxRob,
                                                                        UA_ROBID_CONTROLLERTYPE),
                                                      &controllerId);

    if (!found) {
        if (!UA_NodeId_isNull(&controllerId)) {
            logger->error(
                    "There are multiple MoveSkillControllerType Objects on the server. This is currently not supported.");
        } else {
            logger->error("No MoveSkillController found on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    found = fortiss::opcua::UA_Client_findChildWithBrowseName(client.get(), logger, controllerId,
                                                              UA_QUALIFIEDNAME(nsIdxDeviceFor,
                                                                               const_cast<char *>("Skills")),
                                                              &skillsId);
    if (!found) {
        if (!UA_NodeId_isNull(&skillsId)) {
            logger->error("There are multiple 'Skills' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'Skills' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    
    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, skillsId,
                                                              UA_NODEID_NUMERIC(nsIdxRobFor, UA_FOR_ROBID_CARTESIANLINEARMOVESKILLTYPE),
                                                              &cartesianLinearMoveSkillId);
    if (!found) {
        if (!UA_NodeId_isNull(&cartesianLinearMoveSkillId)) {
            logger->error("There are multiple 'CartesianLinearMoveSkill' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'CartesianLinearMoveSkill' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }
    
    
    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, skillsId,
                                                              UA_NODEID_NUMERIC(nsIdxRobFor, UA_FOR_ROBID_CARTESIANPTPMOVESKILLTYPE),
                                                              &cartesianPtpMoveSkillId);
    if (!found) {
        if (!UA_NodeId_isNull(&cartesianPtpMoveSkillId)) {
            logger->error("There are multiple 'CartesianPtpMoveSkill' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'CartesianPtpMoveSkill' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }
    
    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, skillsId,
                                                              UA_NODEID_NUMERIC(nsIdxRobFor, UA_FOR_ROBID_JOINTLINEARMOVESKILLTYPE),
                                                              &jointLinearMoveSkillId);
    if (!found) {
        if (!UA_NodeId_isNull(&jointLinearMoveSkillId)) {
            logger->error("There are multiple 'JointLinearMoveSkill' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'JointLinearMoveSkill' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }
    
    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, skillsId,
                                                              UA_NODEID_NUMERIC(nsIdxRobFor, UA_FOR_ROBID_JOINTPTPMOVESKILLTYPE),
                                                              &jointPtpMoveSkillId);
    if (!found) {
        if (!UA_NodeId_isNull(&jointPtpMoveSkillId)) {
            logger->error("There are multiple 'JointPtpMoveSkill' nodes on the server. This is currently not supported.");
        } else {
            logger->error("No 'JointPtpMoveSkill' node found below MotionSystem on the server.");
        }
        return UA_STATUSCODE_BADNOTFOUND;
    }

    // CartesianLinearForceMoveSkill
    found = fortiss::opcua::UA_Client_findChildOfType(client.get(), logger, skillsId,
                                                      UA_NODEID_NUMERIC(nsIdxRobFor,
                                                                        UA_FOR_ROBID_CARTESIANLINEARFORCEMOVESKILLTYPE),
                                                      &cartesianLinearForceMoveSkillId);

    if (!found) {
        if (!UA_NodeId_isNull(&cartesianLinearForceMoveSkillId)) {
            logger->error(
                    "There are multiple 'CartesianLinearForceMoveSkill' nodes on the server. This is currently not supported");
            cartesianLinearForceMoveSkillId = UA_NODEID_NULL;
            return UA_STATUSCODE_BADNOTFOUND;
        } else {
            logger->info("No 'CartesianLinearForceMoveSkill' node found below MotionSystem on the server.");
        }
    }

    return UA_STATUSCODE_GOOD;
}

void RobotClient::threadRun() {
    bool success = true;
    while (running && success) {
        if (cartesianLinearMoveSkillClient)
            success &= cartesianLinearMoveSkillClient->step(0);
        if (cartesianPtpMoveSkillClient)
            success &= cartesianPtpMoveSkillClient->step(0);
        if (jointLinearMoveSkillClient)
            success &= jointLinearMoveSkillClient->step(0);
        if (jointPtpMoveSkillClient)
            success &= jointPtpMoveSkillClient->step(0);
        if (cartesianLinearForceMoveSkillClient)
            success &= cartesianLinearForceMoveSkillClient->step(0);
        std::this_thread::sleep_for(std::chrono::milliseconds(1));
    }
    running = false;
}

void RobotClient::start() {
    if (running)
        return;
    running = true;
    stepperThread = std::thread([&] { threadRun(); });

}

void RobotClient::stop() {
    running = false;
}

UA_StatusCode
RobotClient::setTool(const std::string &name, const UA_ThreeDFrame &frame, const double mass,
                     const UA_ThreeDFrame &centerOfMass,
                     const UA_ThreeDVector &inertia) {
    UA_Variant input[5];

    UA_Variant_init(&input[0]);
    UA_String nameStr;
    nameStr.length = name.length();
    nameStr.data = (UA_Byte *) const_cast<char *>(name.c_str());
    UA_Variant_setScalar(&input[0], &nameStr, &UA_TYPES[UA_TYPES_STRING]);


    UA_Variant_init(&input[1]);

    /*UA_ExtensionObject extObjFrame;
    UA_ExtensionObject_init(&extObjFrame);
    extObjFrame.encoding = UA_EXTENSIONOBJECT_DECODED_NODELETE;
    extObjFrame.content.decoded.type = &UA_TYPES_ROB[UA_TYPES_ROB_FRAME];
    extObjFrame.content.decoded.data = const_cast<UA_Frame*>(&frame);

    UA_Variant_setScalar(&input[1], &extObjFrame, &UA_TYPES[UA_TYPES_EXTENSIONOBJECT]);*/
    UA_Variant_setScalar(&input[1], const_cast<UA_ThreeDFrame *>(&frame), &UA_TYPES[UA_TYPES_THREEDFRAME]);

    UA_Variant_init(&input[2]);
    UA_Variant_setScalar(&input[2], const_cast<double *>(&mass), &UA_TYPES[UA_TYPES_DOUBLE]);

    UA_Variant_init(&input[3]);
    UA_Variant_setScalar(&input[3], const_cast<UA_ThreeDFrame *>(&centerOfMass), &UA_TYPES[UA_TYPES_THREEDFRAME]);

    UA_Variant_init(&input[4]);
    UA_Variant_setScalar(&input[4], const_cast<UA_ThreeDVector *>(&inertia), &UA_TYPES[UA_TYPES_THREEDVECTOR]);


    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client.get(), motionDeviceId, flangeToolSetMethodId, 5, input, nullptr, nullptr);
}

UA_StatusCode
RobotClient::setLed(bool on) {

    if (UA_NodeId_equal(&ledId, &UA_NODEID_NULL))
        return UA_STATUSCODE_BADNOTSUPPORTED;

    UA_Variant var;

    UA_Variant_init(&var);

    UA_Boolean val = on;
    UA_Variant_setScalar(&var, &val, &UA_TYPES[UA_TYPES_BOOLEAN]);

    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_writeValueAttribute(client.get(), ledId, &var);
}

UA_StatusCode
RobotClient::clearTool() {
    std::lock_guard<std::mutex> lk(clientMutex);
    return UA_Client_call(client.get(), motionDeviceId, flangeToolClearMethodId, 0, nullptr, nullptr, nullptr);
}

std::string RobotClient::getMotionSystemDisplayName() {

    UA_LocalizedText var;

    UA_LocalizedText_init(&var);


    std::lock_guard<std::mutex> lk(clientMutex);
    UA_StatusCode retval = UA_Client_readDisplayNameAttribute(client.get(), motionSystemId, &var);
    if (retval != UA_STATUSCODE_GOOD)
        return nullptr;

    std::string retstr((char *) var.text.data, var.text.length);

    UA_LocalizedText_clear(&var);

    return retstr;
}
