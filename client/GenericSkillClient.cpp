//
// Created by profanter on 24/09/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#include <open62541/client.h>
#include <common/opcua/helper.hpp>
#include <common/client/GenericSkillClient.h>

GenericSkillClient::GenericSkillClient(std::shared_ptr<spdlog::logger> &loggerParam, const std::string &serverURL,
                                       const UA_NodeId &_skillNodeId, UA_Client *clientParam,
                                       const std::string &username, const std::string &password) :
        SkillClient(loggerParam, serverURL, 0, _skillNodeId, username, password, false, clientParam),
        parameterMap() {
    populateParametersMap();
}

void GenericSkillClient::populateParametersMap() {

    if (UA_NodeId_equal(&this->parameterSetNodeId,&UA_NODEID_NULL))
        return;

    UA_BrowseRequest bReq;
    UA_BrowseRequest_init(&bReq);
    bReq.requestedMaxReferencesPerNode = 0;
    bReq.nodesToBrowse = UA_BrowseDescription_new();
    bReq.nodesToBrowseSize = 1;
    UA_NodeId_copy(&parameterSetNodeId, &(bReq.nodesToBrowse[0].nodeId));
    bReq.nodesToBrowse[0].resultMask = UA_BROWSERESULTMASK_ALL; /* return everything */

    UA_StatusCode retval = connect(false);
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Can not connect to server. Error {}",
                      UA_StatusCode_name(retval));
        throw fortiss::opcua::StatusCodeException(retval);
    }
    UA_BrowseResponse bResp = UA_Client_Service_browse(client, bReq);

    UA_NodeId hasComponentReferenceId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);

    bool found = false;
    if (bResp.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        logger->error("Can not browse server for children. Error {}",
                      UA_StatusCode_name(bResp.responseHeader.serviceResult));
        throw fortiss::opcua::StatusCodeException(bResp.responseHeader.serviceResult);
    } else {
        for (size_t i = 0; i < bResp.resultsSize; ++i) {
            for (size_t j = 0; j < bResp.results[i].referencesSize; ++j) {
                UA_ReferenceDescription *ref = &(bResp.results[i].references[j]);

                if (!UA_NodeId_equal(&ref->referenceTypeId, &hasComponentReferenceId))
                    continue;

                std::string parameterName = std::string((char*)ref->browseName.name.data, ref->browseName.name.length);
                UA_NodeId *parameterId = UA_NodeId_new();
                UA_NodeId_copy(&ref->nodeId.nodeId, parameterId);
                SkillClientParameter *p = new SkillClientParameter(parameterName, std::shared_ptr<UA_NodeId>(parameterId, UA_NodeId_delete));
                this->parameter.emplace_back(p);
                this->parameterMap.emplace(parameterName, p);
            }
        }
    }

    UA_BrowseRequest_clear(&bReq);
    UA_BrowseResponse_clear(&bResp);

    disconnect();
}

UA_StatusCode GenericSkillClient::setParameterValue(const std::string& name, const UA_Variant& value) {

    if (parameterMap.count(name) == 0)
        return UA_STATUSCODE_BADNOTFOUND;
    return UA_Variant_copy(&value, &parameterMap.at(name)->value);
}

UA_StatusCode GenericSkillClient::writeParameterSet() {
    return SkillClient::writeParameter();
}
