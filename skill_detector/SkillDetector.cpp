/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <common/skill_detector/SkillDetector.h>

#include <utility>
#include <open62541/client.h>
#include <open62541/client_config_default.h>
#include <open62541/client_highlevel.h>
#include <common/logging_opcua.h>
#include <fortiss_device_nodeids.h>
#include <di_nodeids.h>
#include <common/opcua/helper.hpp>
#include <random>

#define NAMESPACE_URI_DI "http://opcfoundation.org/UA/DI/"
#define NAMESPACE_URI_FORTISS_DEVICE "https://fortiss.org/UA/Device/"

SkillDetector::SkillDetector(
        std::shared_ptr<spdlog::logger> _loggerApp,
        std::shared_ptr<spdlog::logger> _loggerOpcua,
        std::string clientCertPath,
        std::string clientKeyPath,
        std::string clientAppUri,
        std::string clientAppName,
        std::chrono::milliseconds monitorOnlineInterval
) :
        registeredComponents(), logger(std::move(_loggerApp)), loggerOpcua(std::move(_loggerOpcua)), clientCertPath(std::move(clientCertPath)), clientKeyPath(std::move
        (clientKeyPath)),
        clientAppUri(std::move(clientAppUri)), clientAppName(std::move(clientAppName)), monitorOnlineInterval(monitorOnlineInterval) {
}

SkillDetector::~SkillDetector() {
    this->registeredComponents.clear();
}


void SkillDetector::onServerAnnounce(
        const UA_ServerOnNetwork* serverOnNetwork,
        UA_Boolean isServerAnnounce
) {
    // create a copy of registered server struct since it may be deleted while the thread is still running.
    UA_ServerOnNetwork* serverOnNetworkTemp = UA_ServerOnNetwork_new();
    UA_ServerOnNetwork_copy(serverOnNetwork, serverOnNetworkTemp);
    std::shared_ptr<UA_ServerOnNetwork> serverOnNetworkSafe = std::shared_ptr<UA_ServerOnNetwork>(serverOnNetworkTemp, [=](UA_ServerOnNetwork* ptr) {
        UA_ServerOnNetwork_delete(ptr);
    });

    // run in separate thread to not block main iteration
    std::thread([this, serverOnNetworkSafe, isServerAnnounce]() {
        std::string serverName = std::string((char*) serverOnNetworkSafe->serverName.data, serverOnNetworkSafe->serverName.length);

        std::set<std::string> discoveryUrls = getDiscoveryUrls(serverOnNetworkSafe);

        if (isServerAnnounce) {

            bool startTimeMatches = false;
            UA_DateTime newStartTime = 0;
            std::shared_ptr<UA_EndpointDescription> endpoint;

            {
                std::lock_guard<std::mutex> lc(this->registeredMapMutex);
                if (isServerRecentlyAnnounced(discoveryUrls, &startTimeMatches, &newStartTime, &endpoint)) {
                    return;
                }
            }

            // random wait between 1 and 2 seconds to not overload remote device
            std::random_device rd;
            std::mt19937 mt(rd());
            std::uniform_int_distribution<int> uniform_dist(0, 1000);
            std::this_thread::sleep_for(std::chrono::milliseconds(1000 + uniform_dist(mt)));

            std::lock_guard<std::mutex> lc(this->registeredMapMutex);
            bool error;
            if (isServerKnown(discoveryUrls, error, &startTimeMatches, &newStartTime, &endpoint)) {
                if (startTimeMatches)
                    return;
                logger->info("Component {} restart detected. Removing previous register and detect new skills.", serverName);
                removeServerKnown(discoveryUrls);
                componentDisconnected(serverOnNetworkSafe);
            }
            if (error)
                return;
            if (!addServerKnown(discoveryUrls, newStartTime, &endpoint))
                return;


            logger->info("Got register from component: {}", serverName);

            componentConnected(serverOnNetworkSafe, endpoint);

        } else {

            std::lock_guard<std::mutex> lc(this->registeredMapMutex);
            bool error;
            if (!isServerKnown(discoveryUrls, error)) {
                return;
            }


            logger->info("Got unregister from component: {}", serverName);

            removeServerKnown(discoveryUrls);
            componentDisconnected(serverOnNetworkSafe);
        }
    }).detach();
}


void SkillDetector::onServerRegister(
        const UA_RegisteredServer* registeredServer
) {

    // create a copy of registered server struct since it may be deleted while the thread is still running.
    UA_RegisteredServer* registeredServerTmp = UA_RegisteredServer_new();
    UA_RegisteredServer_copy(registeredServer, registeredServerTmp);
    std::shared_ptr<UA_RegisteredServer> registeredServerSafe = std::shared_ptr<UA_RegisteredServer>(registeredServerTmp, [=](UA_RegisteredServer* ptr) {
        UA_RegisteredServer_delete(ptr);
    });


    // run in separate thread to not block main iteration
    std::thread([this, registeredServerSafe]() {
        std::lock_guard<std::mutex> lc(this->registeredMapMutex);
        std::string serverUri = std::string((char*) registeredServerSafe->serverUri.data, registeredServerSafe->serverUri.length);

        std::set<std::string> discoveryUrls = getDiscoveryUrls(registeredServerSafe);

        if (registeredServerSafe->isOnline) {

            bool startTimeMatches = false;
            UA_DateTime newStartTime = 0;
            std::shared_ptr<UA_EndpointDescription> endpoint;
            bool error;
            if (isServerKnown(discoveryUrls, error, &startTimeMatches, &newStartTime, &endpoint)) {
                if (startTimeMatches)
                    return;
                logger->info("Component {} restart detected. Removing previous register and detect new skills.", serverUri);
                removeServerKnown(discoveryUrls);
                componentDisconnected(registeredServerSafe);
            }
            if (error)
                return;
            if (!addServerKnown(discoveryUrls, newStartTime, &endpoint))
                return;

            logger->info("Got register from component: {}", serverUri);
            componentConnected(registeredServerSafe, endpoint);

        } else {
            bool error;
            if (!isServerKnown(discoveryUrls, error)) {
                return;
            }

            logger->info("Got unregister from component: {}", serverUri);

            removeServerKnown(discoveryUrls);
            componentDisconnected(registeredServerSafe);
        }
    }).detach();
}

void SkillDetector::componentConnected(
        const std::shared_ptr<const UA_RegisteredServer>& registeredServer,
        const std::shared_ptr<const UA_EndpointDescription>& endpoint
) {

    std::string serverUri = std::string((char*) registeredServer->serverUri.data, registeredServer->serverUri.length);

    auto it = registeredComponents.find(serverUri);
    if (it != registeredComponents.end())
        // already known component-> Ignore
        return;

    std::string endpointUrl = std::string((char*) endpoint->endpointUrl.data, endpoint->endpointUrl.length);
    if (endpointUrl.length() == 0)
        return;
    if (endpointUrl.at(endpointUrl.size() - 1) != '/')
        endpointUrl += '/';
    for (const auto& component : registeredComponents) {
        if (component.second->endpointUrl == endpointUrl) {
            return;
        }
    }

    std::shared_ptr<RegisteredComponent> data = std::make_shared<RegisteredComponent>(
            logger, loggerOpcua, endpoint, endpointUrl, clientCertPath, clientKeyPath, clientAppUri, clientAppName);

    this->registeredComponents.emplace(serverUri, data);

    logger->info("Component ADD: {} -> {}", serverUri, endpointUrl);

    addSkillsFromComponent(serverUri, data);

}

void SkillDetector::componentConnected(
        const std::shared_ptr<const UA_ServerOnNetwork>& serverOnNetwork,
        const std::shared_ptr<const UA_EndpointDescription>& endpoint
) {

    std::string serverName = std::string((char*) serverOnNetwork->serverName.data, serverOnNetwork->serverName.length);
    std::string serverUrl = std::string((char*) serverOnNetwork->discoveryUrl.data, serverOnNetwork->discoveryUrl.length);

    std::string serverId = serverName + "-" + serverUrl;

    auto it = registeredComponents.find(serverId);
    if (it != registeredComponents.end())
        // already known component-> Ignore
        return;
    std::string endpointUrl = std::string((char*) endpoint->endpointUrl.data, endpoint->endpointUrl.length);
    if (endpointUrl.length() == 0)
        return;
    if (endpointUrl.at(endpointUrl.size() - 1) != '/')
        endpointUrl += '/';
    for (const auto& component : registeredComponents) {
        if (component.second->endpointUrl == endpointUrl) {
            return;
        }
    }

    std::shared_ptr<RegisteredComponent> data = std::make_shared<RegisteredComponent>(
            logger, loggerOpcua, endpoint, endpointUrl, clientCertPath, clientKeyPath, clientAppUri, clientAppName);

    this->registeredComponents.emplace(serverId, data);

    logger->info("Component ADD: {} -> {}", serverName, endpointUrl);

    addSkillsFromComponent(serverId, data);

}

void SkillDetector::componentDisconnected(const std::shared_ptr<const UA_RegisteredServer>& registeredServer) {
    std::string serverUri = std::string((char*) registeredServer->serverUri.data, registeredServer->serverUri.length);
    auto it = registeredComponents.find(serverUri);
    if (it == registeredComponents.end())
        // Component not known. Ignore
        return;

    logger->info("Component REMOVE: {} -> {}", serverUri, it->second->endpointUrl);

    removeSkillsFromComponent(serverUri, it->second);
    registeredComponents.erase(serverUri);
}


void SkillDetector::componentDisconnected(const std::shared_ptr<const UA_ServerOnNetwork>& serverOnNetwork) {
    std::string serverName = std::string((char*) serverOnNetwork->serverName.data, serverOnNetwork->serverName.length);
    std::string serverUrl = std::string((char*) serverOnNetwork->discoveryUrl.data, serverOnNetwork->discoveryUrl.length);

    std::string serverId = serverName + "-" + serverUrl;

    auto it = registeredComponents.find(serverId);
    if (it == registeredComponents.end())
        // Component not known. Ignore
        return;

    logger->info("Component REMOVE: {} -> {}", serverName, it->second->endpointUrl);

    removeSkillsFromComponent(serverId, it->second);
    registeredComponents.erase(serverId);
}

bool SkillDetector::addSkillsFromComponent(
        const std::string& serverUri,
        std::shared_ptr<RegisteredComponent>& component
) {

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

bool SkillDetector::removeSkillsFromComponent(
        const std::string& serverUri,
        const std::shared_ptr<RegisteredComponent>& component
) {

    auto it = registeredSkills.cbegin();
    while (it != registeredSkills.cend()) {
        if (it->second->getParentComponent() == component) {
            logger->info("Remove unregistered skill: {}", it->second->getSkillNameStr());
            it = registeredSkills.erase(it);
        } else {
            ++it;
        }
    }

    return true;
}


bool SkillDetector::findAllSkillControllerNodes(
        std::shared_ptr<RegisteredComponent>& component,
        std::vector<std::shared_ptr<UA_NodeId>>& controllerIds
) {

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
        const std::shared_ptr<UA_NodeId>& controllerId
) {

    // find "Skills" node
    UA_NodeId skillsId;
    bool found;
    {
        LockedClient lc = component->getLockedClient();
        found = fortiss::opcua::UA_Client_findChildWithBrowseName(lc.get(), logger, *controllerId,
                                                                  UA_QUALIFIEDNAME(component->nsFortissDiIdx,
                                                                                   const_cast<char*>("Skills")),
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
                UA_ReferenceDescription* ref = &(bResp.results[i].references[j]);

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

    if (!endpointFull.empty() && endpointFull.at(endpointFull.size() - 1) != '/')
        endpointFull += '/';

    for (const auto& component : registeredComponents) {

        if (component.second->endpointUrl == endpointFull) {
            return component.second;
        }
    }

    return nullptr;
}


std::vector<std::shared_ptr<RegisteredSkill>> SkillDetector::getSkillForEndpoint(
        const std::string& endpointUrl,
        const std::string& skillType
) {
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

std::shared_ptr<RegisteredSkill> SkillDetector::getSkillForEndpointAndBrowseName(
        const std::string& endpointUrl,
        const std::string& skillBrowseName
) {
    std::shared_ptr<RegisteredComponent> registeredComponent = getComponentForEndpoint(endpointUrl);
    if (!registeredComponent)
        return nullptr;

    for (const auto& skill : registeredComponent->skills) {
        if (skill->getSkillNameStr() == skillBrowseName) {
            return skill;
        }
    }
    return nullptr;
}


std::vector<std::shared_ptr<RegisteredComponent>> SkillDetector::getComponentForAppUri(const std::string& appUri) {
    std::vector<std::shared_ptr<RegisteredComponent>> components;

    UA_String str = {
            .length = appUri.size(),
            .data = (UA_Byte*) const_cast<char*>(appUri.c_str())
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
            .data = (UA_Byte*) const_cast<char*>(appName.c_str())
    };
    for (const auto& component : registeredComponents) {

        if (UA_String_equal(&component.second->endpoint->server.applicationName.text, &str)) {
            components.emplace_back(component.second);
        }
    }

    return components;
}

std::shared_ptr<UA_EndpointDescription> SkillDetector::findAvailableEndpoint(
        const std::set<std::string>& discoveryUrls
) {

    if (discoveryUrls.empty()) {
        return nullptr;
    }


    std::promise<std::shared_ptr<UA_EndpointDescription>> promiseEndpoint;
    fortiss::opcua::getBestEndpointFromServer(discoveryUrls, promiseEndpoint, loggerOpcua);
    std::future<std::shared_ptr<UA_EndpointDescription>> endpointFuture = promiseEndpoint.get_future();

    std::future_status status = endpointFuture.wait_for(std::chrono::seconds(8));

    if (status == std::future_status::ready) {
        return endpointFuture.get();
    }
    return nullptr;
}

bool SkillDetector::addServerKnown(
        const std::set<std::string>& discoveryUrls,
        UA_DateTime startTime,
        std::shared_ptr<UA_EndpointDescription>* endpoint
) {

    for (const auto& url : discoveryUrls) {
        if (registeredMap.count(url) != 0) {
            return false;
        }
    }

    std::shared_ptr<ServerKnownData> data = std::make_shared<ServerKnownData>();

    std::shared_ptr<UA_EndpointDescription> endpointFound;
    if (!*endpoint) {
        endpointFound = findAvailableEndpoint(discoveryUrls);
        if (!endpointFound) {
            std::string urls;
            for (const auto& url : discoveryUrls) {
                if (!urls.empty())
                    urls += ", ";
                urls += url;
            }
            logger->error("Did not find any endpoint for discovery URLs: {}", urls);
            return false;
        }
        *endpoint = endpointFound;
    }
    else
        endpointFound = *endpoint;

    std::string endpointUrl = std::string((char*)endpointFound->endpointUrl.data, endpointFound->endpointUrl.length);
    if (endpointUrl.empty())
        return false;

    endpointUrl = endpointUrl[endpointUrl.length() - 1] == '/' ? endpointUrl : endpointUrl + "/";

    if (startTime == 0) {
        UA_StatusCode retval = fortiss::opcua::UA_Client_getStartTime(
                logger,
                loggerOpcua,
                clientCertPath,
                clientKeyPath,
                clientAppUri,
                clientAppName,
                endpointFound,
                &startTime
        );
        if (retval != UA_STATUSCODE_GOOD) {
            logger->error("Could not get StartTime from {}", endpointUrl, UA_StatusCode_name(retval));
            return false;
        }
    }

    data->lastAnnounce = std::chrono::steady_clock::now();
    data->startTime = startTime;
    data->endpoint = endpointFound;

    registeredMap.emplace(endpointUrl, data);
    return true;
}

bool SkillDetector::isServerRecentlyAnnounced(
        const std::set<std::string>& discoveryUrls,
        bool* startTimeMatches,
        UA_DateTime* currentStartTime,
        std::shared_ptr<UA_EndpointDescription>* endpointReturn
) {
    if (discoveryUrls.empty())
        return false;

    bool known = false;

    std::shared_ptr<ServerKnownData> data;

    for (const auto& url : discoveryUrls) {
        if (registeredMap.count(url) > 0) {
            data = registeredMap.at(url);
            known = true;
            break;
        }
    }

    if (!known)
        return false;

    if ((data->lastAnnounce > std::chrono::time_point<std::chrono::steady_clock>::min()) &&
        (std::chrono::duration_cast<std::chrono::seconds>(std::chrono::steady_clock::now() - data->lastAnnounce).count() < 1000)) {
        // it could be the case that during startup the server announces itself multiple times.
        // To avoid that we make multiple requests during startup, ignore additional announces within 5 seconds and assume it is the same server
        if (startTimeMatches != nullptr)
            *startTimeMatches = true;
        if (currentStartTime != nullptr)
            *currentStartTime = data->startTime;
        if (endpointReturn != nullptr)
            *endpointReturn = data->endpoint;
        return true;
    }

    return false;
}

bool SkillDetector::isServerKnown(
        const std::set<std::string>& discoveryUrls,
        bool &error,
        bool* startTimeMatches,
        UA_DateTime* currentStartTime,
        std::shared_ptr<UA_EndpointDescription>* endpointReturn
) {
    error = false;
    if (isServerRecentlyAnnounced(
            discoveryUrls,
            startTimeMatches,
            currentStartTime,
            endpointReturn)) {
        return true;
    }

    std::shared_ptr<UA_EndpointDescription> endpoint;
    if (endpointReturn == nullptr || *endpointReturn == nullptr)
        endpoint = findAvailableEndpoint(discoveryUrls);
    else
        endpoint = *endpointReturn;
    if (!endpoint) {
        std::string urls;
        for (const auto& url : discoveryUrls) {
            if (!urls.empty())
                urls += ", ";
            urls += url;
        }
        logger->error("Did not find any endpoint for discovery URLs: {}", urls);
        error = true;
        return false;
    }

    UA_DateTime startTime;
    UA_StatusCode retval = fortiss::opcua::UA_Client_getStartTime(
            logger,
            loggerOpcua,
            clientCertPath,
            clientKeyPath,
            clientAppUri,
            clientAppName,
            endpoint,
            &startTime
    );
    if (retval != UA_STATUSCODE_GOOD) {
        logger->error("Could not get StartTime from {}", std::string((char*) endpoint->endpointUrl.data, endpoint->endpointUrl.length), UA_StatusCode_name
                (retval));
        error = true;
        return false;
    }

    if (startTimeMatches != nullptr)
        *startTimeMatches = startTime == *currentStartTime;

    if (currentStartTime != nullptr)
        *currentStartTime = startTime;

    if (endpointReturn != nullptr)
        *endpointReturn = endpoint;
    return true;
}

void SkillDetector::removeServerKnown(
        const std::set<std::string>& discoveryUrls
) {
    for (const auto& url : discoveryUrls) {
        if (registeredMap.count(url) > 0) {
            registeredMap.erase(url);
            break;
        }
    }
}

std::set<std::string> SkillDetector::getDiscoveryUrls(const std::shared_ptr<UA_RegisteredServer>& registeredServer) {
    std::set<std::string> discoveryUrls;
    for (size_t i = 0; i < registeredServer->discoveryUrlsSize; i++) {
        const std::string url = std::string((char*) registeredServer->discoveryUrls[i].data, registeredServer->discoveryUrls[i].length);
        if (url.empty())
            continue;
        const std::string urlWithSlash = url[url.length() - 1] == '/' ? url : url + "/";
        discoveryUrls.emplace(urlWithSlash);
    }
    return discoveryUrls;
}

std::set<std::string> SkillDetector::getDiscoveryUrls(const std::shared_ptr<UA_ServerOnNetwork>& serverOnNetwork) {
    std::set<std::string> discoveryUrls;
    std::string discoveryUrl = std::string((char*) serverOnNetwork->discoveryUrl.data, serverOnNetwork->discoveryUrl.length);
    if (discoveryUrl.empty())
        return discoveryUrls;
    if (discoveryUrl.at(discoveryUrl.size() - 1) != '/')
        discoveryUrl += '/';

    discoveryUrls.emplace(discoveryUrl);
    return discoveryUrls;
}