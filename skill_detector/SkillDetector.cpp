//
// Created by profanter on 13/08/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//


#include <common/skill_detector/SkillDetector.h>

#include <utility>
#include <open62541/client.h>
#include <open62541/client_config_default.h>
#include <open62541/client_highlevel.h>
#include <common/logging_opcua.h>
#include <fortiss_device_nodeids.h>
#include <di_nodeids.h>
#include <common/opcua/helper.hpp>

#define NAMESPACE_URI_DI "http://opcfoundation.org/UA/DI/"
#define NAMESPACE_URI_FORTISS_DEVICE "https://fortiss.org/UA/Device/"

SkillDetector::SkillDetector(std::shared_ptr<spdlog::logger> _logger,
                             const std::string&  clientCertPath,
                             const std::string&  clientKeyPath,
                             const std::string&  clientAppUri,
                             const std::string&  clientAppName,
                             std::chrono::milliseconds monitorOnlineInterval) :
        logger(std::move(_logger)), clientCertPath(clientCertPath), clientKeyPath(clientKeyPath),
        clientAppUri(clientAppUri), clientAppName(clientAppName), monitorOnlineInterval(monitorOnlineInterval),
        registeredComponents() {

    loggerClient = logger->clone(logger->name()+"-detector");
    if (loggerClient->level() < spdlog::level::err)
        loggerClient->set_level(spdlog::level::err);
}

SkillDetector::~SkillDetector() {

}


void SkillDetector::componentConnected(const std::shared_ptr<const UA_RegisteredServer>& registeredServer,
                                       const std::shared_ptr<const UA_EndpointDescription>& endpoint) {

    std::string serverUri = std::string((char *) registeredServer->serverUri.data, registeredServer->serverUri.length);

    auto it = registeredComponents.find(serverUri);
    if (it != registeredComponents.end())
        // already known component-> Ignore
        return;

    std::string endpointUrl = std::string((char *) endpoint->endpointUrl.data, endpoint->endpointUrl.length);
    if (endpointUrl.length() == 0)
        return;
    if (endpointUrl.at(endpointUrl.size()-1) != '/')
        endpointUrl += '/';
    for (const auto& component : registeredComponents) {
        if (component.second->endpointUrl == endpointUrl) {
            return;
        }
    }

    std::shared_ptr<RegisteredComponent> data = std::make_shared<struct RegisteredComponent>(
            loggerClient, endpoint, endpointUrl, clientCertPath, clientKeyPath, clientAppUri, clientAppName);

    this->registeredComponents.emplace(serverUri, data);

    logger->info("Component ADD: {} -> {}", serverUri, endpointUrl);

    addSkillsFromComponent(serverUri, data);

}

void SkillDetector::componentConnected(const std::shared_ptr<const UA_ServerOnNetwork>& serverOnNetwork,
                                       const std::shared_ptr<const UA_EndpointDescription>& endpoint) {

    std::string serverName = std::string((char *) serverOnNetwork->serverName.data, serverOnNetwork->serverName.length);
    std::string serverUrl = std::string((char *) serverOnNetwork->discoveryUrl.data, serverOnNetwork->discoveryUrl.length);

    std::string serverId = serverName + "-" + serverUrl;

    auto it = registeredComponents.find(serverId);
    if (it != registeredComponents.end())
        // already known component-> Ignore
        return;
    std::string endpointUrl = std::string((char *) endpoint->endpointUrl.data, endpoint->endpointUrl.length);
    if (endpointUrl.length() == 0)
        return;
    if (endpointUrl.at(endpointUrl.size()-1) != '/')
        endpointUrl += '/';
    for (const auto& component : registeredComponents) {
        if (component.second->endpointUrl == endpointUrl) {
            return;
        }
    }

    std::shared_ptr<RegisteredComponent> data = std::make_shared<struct RegisteredComponent>(
            loggerClient, endpoint, endpointUrl, clientCertPath, clientKeyPath, clientAppUri, clientAppName);

    this->registeredComponents.emplace(serverId, data);

    logger->info("Component ADD: {} -> {}", serverName, endpointUrl);

    addSkillsFromComponent(serverId, data);

}

void SkillDetector::componentDisconnected(const std::shared_ptr<const UA_RegisteredServer>& registeredServer) {
    std::string serverUri = std::string((char *) registeredServer->serverUri.data, registeredServer->serverUri.length);
    auto it = registeredComponents.find(serverUri);
    if (it == registeredComponents.end())
        // Component not known. Ignore
        return;

    logger->info("Component REMOVE: {} -> {}", serverUri, it->second->endpointUrl);

    removeSkillsFromComponent(serverUri, it->second);
    registeredComponents.erase(serverUri);
}


void SkillDetector::componentDisconnected(const std::shared_ptr<const UA_ServerOnNetwork>& serverOnNetwork) {
    std::string serverName = std::string((char *) serverOnNetwork->serverName.data, serverOnNetwork->serverName.length);
    std::string serverUrl = std::string((char *) serverOnNetwork->discoveryUrl.data, serverOnNetwork->discoveryUrl.length);

    std::string serverId = serverName + "-" + serverUrl;

    auto it = registeredComponents.find(serverId);
    if (it == registeredComponents.end())
        // Component not known. Ignore
        return;

    logger->info("Component REMOVE: {} -> {}", serverName, it->second->endpointUrl);

    removeSkillsFromComponent(serverId, it->second);
    registeredComponents.erase(serverId);
}

bool SkillDetector::addSkillsFromComponent(const std::string& serverUri, std::shared_ptr<RegisteredComponent>& component) {

    if (!component->connectClient())
        return false;
    {
        UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_DI);
        LockedClient lc = component->getLockedClient();
        UA_StatusCode retval = UA_Client_NamespaceGetIndex(lc.get(), &nsUri, &component->nsDiIdx);
        UA_String_clear(&nsUri);
        if (retval != UA_STATUSCODE_GOOD) {
            logger->error("Can not get namespace index of {} from {}: {}", NAMESPACE_URI_DI, component->endpointUrl, UA_StatusCode_name(retval));
            component->disconnectClient();
            return false;
        }
    }
    {
        UA_String nsUri = UA_String_fromChars(NAMESPACE_URI_FORTISS_DEVICE);
        LockedClient lc = component->getLockedClient();
        UA_StatusCode retval = UA_Client_NamespaceGetIndex(lc.get(), &nsUri, &component->nsFortissDiIdx);
        UA_String_clear(&nsUri);
        if (retval != UA_STATUSCODE_GOOD) {
            logger->error("Can not get namespace index of {} from {}: {}", NAMESPACE_URI_FORTISS_DEVICE, component->endpointUrl, UA_StatusCode_name(retval));
            component->disconnectClient();
            return false;
        }
    }

    std::vector<std::shared_ptr<UA_NodeId>> controllerIds;
    if (!findAllSkillControllerNodes(component, controllerIds)) {
        return false;
    }

    for (const auto& controllerId : controllerIds) {
        if (!addSkillsFromController(component, controllerId))
            return false;
    }

    std::stringstream ss;

    ss << std::endl << "--- Component Registered ---" << std::endl;
    ss << "\tEndpoint: " << component->endpointUrl << std::endl;
    ss << "\tSkills:" << std::endl;
    for (const auto& skill : component->skills) {
        ss << "\t\t- Name:" << skill->getSkillNameStr() << std::endl;
        ss << "\t\t  Type:" << skill->getSkillTypeNameStr() << std::endl;
    }
    ss << "----------------------------" << std::endl;

    if (monitorOnlineInterval.count() > 0) {
        component->offlineCallback = [this, serverUri, component]() {

            logger->info("Component OFFLINE: {} -> {}", serverUri, component->endpointUrl);

            component->monitorOnlineStop();

            removeSkillsFromComponent(serverUri, component);
            component->disconnectClient();
            registeredComponents.erase(serverUri);
        };
        component->monitorOnline(monitorOnlineInterval);
    }

    logger->info(ss.str());
    return true;
}

bool SkillDetector::removeSkillsFromComponent(const std::string& serverUri, const std::shared_ptr<RegisteredComponent>& component) {

    auto it = registeredSkills.cbegin();
    while (it != registeredSkills.cend())
    {
        if (it->second->getParentComponent() == component)
        {
            logger->info("Remove unregistered skill: {}", it->second->getSkillNameStr());
            it = registeredSkills.erase(it);
        }
        else {
            ++it;
        }
    }

    return true;
}



bool SkillDetector::findAllSkillControllerNodes(
        std::shared_ptr<RegisteredComponent>& component,
        std::vector<std::shared_ptr<UA_NodeId>> &controllerIds) {

    UA_NodeId deviceSetId = UA_NODEID_NUMERIC(component->nsDiIdx, UA_DIID_DEVICESET);
    UA_NodeId skillControllerType = UA_NODEID_NUMERIC(component->nsFortissDiIdx, UA_FORTISS_DEVICEID_ISKILLCONTROLLERTYPE);

    std::vector<std::shared_ptr<UA_NodeId>> foundIds;

    {
        LockedClient lc = component->getLockedClient();
        if (!fortiss::opcua::UA_Client_findChildrenImplementingInterfaceRecursively(lc.get(), logger, &deviceSetId, 1, skillControllerType, foundIds))
            return false;
    }

    controllerIds.insert(controllerIds.end(), foundIds.begin(), foundIds.end());

    return true;
}

bool SkillDetector::addSkillsFromController(
        std::shared_ptr<RegisteredComponent>& component,
        const std::shared_ptr<UA_NodeId>& controllerId) {

    // find "Skills" node
    UA_NodeId skillsId;
    bool found;
    {
        LockedClient lc = component->getLockedClient();
        found = fortiss::opcua::UA_Client_findChildWithBrowseName(lc.get(), logger, *controllerId.get(),
                                                                  UA_QUALIFIEDNAME(component->nsFortissDiIdx,
                                                                                   const_cast<char *>("Skills")),
                                                                  &skillsId);
    }

    if (!found) {
        if (!UA_NodeId_isNull(&skillsId)) {
            logger->error("There are multiple 'Skills' nodes on the server. This is currently not supported.");
            return false;
        } else {
            logger->error("No 'Skills' node found in skill controller.");
            return false;
        }
    }
    UA_BrowseRequest bReq;
    UA_BrowseRequest_init(&bReq);
    bReq.requestedMaxReferencesPerNode = 0;
    bReq.nodesToBrowse = UA_BrowseDescription_new();
    bReq.nodesToBrowseSize = 1;
    UA_NodeId_copy(&skillsId, &(bReq.nodesToBrowse[0].nodeId));
    bReq.nodesToBrowse[0].resultMask = UA_BROWSERESULTMASK_ALL; /* return everything */

    UA_BrowseResponse bResp;
    {
        LockedClient lc = component->getLockedClient();
        bResp = UA_Client_Service_browse(lc.get(), bReq);
    }

    if (bResp.responseHeader.serviceResult != UA_STATUSCODE_GOOD) {
        logger->error("Can not browse server for children. Error {}",
                      UA_StatusCode_name(bResp.responseHeader.serviceResult));
    } else {
        for (size_t i = 0; i < bResp.resultsSize; ++i) {
            for (size_t j = 0; j < bResp.results[i].referencesSize; ++j) {
                UA_ReferenceDescription *ref = &(bResp.results[i].references[j]);

                UA_NodeId hasComponentId = UA_NODEID_NUMERIC(0, UA_NS0ID_HASCOMPONENT);
                if (!UA_NodeId_equal(&ref->referenceTypeId, &hasComponentId)) {
                    continue;
                }

                std::shared_ptr<RegisteredSkill> skill = std::make_shared<RegisteredSkill>(
                        component, logger, ref->nodeId.nodeId, clientCertPath, clientKeyPath, clientAppUri, clientAppName);

                this->registeredSkills.emplace(skill->getSkillTypeNameStr(), skill);
                component->skills.emplace_back(skill);
            }
        }
    }

    UA_BrowseRequest_clear(&bReq);
    UA_BrowseResponse_clear(&bResp);

    return true;
}

std::shared_ptr<RegisteredComponent> SkillDetector::getComponentForEndpoint(const std::string& endpointUrl) {
    std::string endpointFull = endpointUrl;

    if (endpointFull.size() > 0 && endpointFull.at(endpointFull.size()-1) != '/')
        endpointFull += '/';

    for (const auto& component : registeredComponents) {

        if (component.second->endpointUrl == endpointFull) {
            return component.second;
        }
    }

    return nullptr;
}


std::vector<std::shared_ptr<RegisteredSkill>> SkillDetector::getSkillForEndpoint(const std::string& endpointUrl, const std::string& skillType) {
    std::vector<std::shared_ptr<RegisteredSkill>> skills;

    std::shared_ptr<RegisteredComponent> registeredComponent = getComponentForEndpoint(endpointUrl);
    if (!registeredComponent)
        return skills;

    for (const auto& skill : registeredSkills) {

        if (skill.second->getParentComponent() != registeredComponent) {
            continue;
        }

        if (skill.first == skillType)
            skills.emplace_back(skill.second);
    }
    return skills;

}


std::vector<std::shared_ptr<RegisteredComponent>> SkillDetector::getComponentForAppUri(const std::string& appUri) {
    std::vector<std::shared_ptr<RegisteredComponent>> components;

    UA_String str = {
            .length = appUri.size(),
            .data = (UA_Byte*)const_cast<char*>(appUri.c_str())
    };
    for (const auto& component : registeredComponents) {

        if (UA_String_equal(&component.second->endpoint->server.applicationUri, &str)) {
            components.emplace_back(component.second);
        }
    }

    return components;
}

std::vector<std::shared_ptr<RegisteredComponent>> SkillDetector::getComponentForAppName(const std::string& appName) {
    std::vector<std::shared_ptr<RegisteredComponent>> components;

    UA_String str = {
            .length = appName.size(),
            .data = (UA_Byte*)const_cast<char*>(appName.c_str())
    };
    for (const auto& component : registeredComponents) {

        if (UA_String_equal(&component.second->endpoint->server.applicationName.text, &str)) {
            components.emplace_back(component.second);
        }
    }

    return components;
}