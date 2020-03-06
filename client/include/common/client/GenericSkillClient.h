//
// Created by profanter on 24/09/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef FORTISS_COMMON_GENERICSKILLCLIENT_H
#define FORTISS_COMMON_GENERICSKILLCLIENT_H

#include "SkillClient.h"

class GenericSkillClient : public SkillClient {
private:
    std::map<const std::string, SkillClientParameter*> parameterMap;

    void populateParametersMap();
public:
    explicit GenericSkillClient(std::shared_ptr<spdlog::logger>& loggerParam,
                                const std::string& serverURL,
                                const UA_NodeId& _skillNodeId,
                                UA_Client *clientParam,
                                const std::string &username = "",
                                const std::string &password = "");

    UA_StatusCode setParameterValue(const std::string &name, const UA_Variant& value);

    UA_StatusCode writeParameterSet();
};


#endif //FORTISS_COMMON_GENERICSKILLCLIENT_H
