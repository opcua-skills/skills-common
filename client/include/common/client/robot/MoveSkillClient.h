/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef PROJECT_MOVESKILLCLIENT_H
#define PROJECT_MOVESKILLCLIENT_H

#include <memory>

#include <common/client/SkillClient.h>


class MoveSkillClient : public virtual SkillClient {
public:
    explicit MoveSkillClient(
            const std::shared_ptr<spdlog::logger> &loggerApp,
            const std::shared_ptr<spdlog::logger> &loggerOpcua,
            const std::string &serverURL,
            UA_UInt16 nsIdxDi,
            UA_UInt16 nsIdxRobFor,
            const UA_NodeId &skillNodeId,
            const std::string &username = "",
            const std::string& password = "",
            const std::string& clientCertPath = "",
            const std::string& clientKeyPath = "",
            const std::string& clientAppUri = "",
            const std::string& clientAppName = "");

    virtual ~MoveSkillClient();

private:
    SkillClientParameter *toolFrameParameter = nullptr;

protected:

    const UA_StatusCode setToolFrame(const std::string &toolFrame);

};


#endif //PROJECT_MOVESKILLCLIENT_H
