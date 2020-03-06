//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef PROJECT_MOVESKILLCLIENT_H
#define PROJECT_MOVESKILLCLIENT_H

#include <memory>

#include <common/client/SkillClient.h>


class MoveSkillClient : public virtual SkillClient {
public:
    explicit MoveSkillClient(const std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                             UA_UInt16 nsIdxDi, UA_UInt16 nsIdxRobFor, const UA_NodeId &skillNodeId,
                             const std::string &username = "", const std::string& password = "");

    virtual ~MoveSkillClient();

private:
    SkillClientParameter *toolFrameParameter = nullptr;

protected:

    const UA_StatusCode setToolFrame(const std::string &toolFrame);

};


#endif //PROJECT_MOVESKILLCLIENT_H
