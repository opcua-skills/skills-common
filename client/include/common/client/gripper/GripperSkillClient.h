//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef PROJECT_CLIENT_MOVEGRIPPERSKILL_H
#define PROJECT_CLIENT_MOVEGRIPPERSKILL_H

#include <memory>

#include <common/client/SkillClient.h>


class GripperSkillClient : public SkillClient {
public:
    explicit GripperSkillClient(const std::shared_ptr<spdlog::logger> &logger, const std::string &serverURL,
                                 UA_UInt16 nsIdxDi, const UA_NodeId &skillNodeId);

    //std::future<void> move(const double positions[], const double speed[], const bool isLin = false);
    // TODO are we having some parameters??
    // TODO rename move??
	std::future<void> move();

private:
//we should not have any parameters...
};


#endif //PROJECT_CLIENT_MOVEGRIPPERSKILL_H
