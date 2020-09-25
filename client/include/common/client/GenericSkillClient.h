/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef FORTISS_COMMON_GENERICSKILLCLIENT_H
#define FORTISS_COMMON_GENERICSKILLCLIENT_H

#include "SkillClient.h"

class GenericSkillClient : public SkillClient {
private:
    std::map<const std::string, SkillClientParameter*> parameterMap;

    void populateParametersMap(bool disconnectAfterInit);
public:
    explicit GenericSkillClient(
            std::shared_ptr<spdlog::logger>& loggerApp,
            std::shared_ptr<spdlog::logger>& loggerOpcua,
            const std::string& serverURL,
            const UA_NodeId& _skillNodeId,
            UA_Client *clientParam,
            const std::string &username = "",
            const std::string &password = "",
            bool disconnectAfterInit = true);

    UA_StatusCode setParameterValue(const std::string &name, const UA_Variant& value);

    UA_StatusCode writeParameterSet();
};


#endif //FORTISS_COMMON_GENERICSKILLCLIENT_H
