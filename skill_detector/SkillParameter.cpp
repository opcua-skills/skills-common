/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#include <open62541/types_generated.h>
#include <regex>
#include <utility>
#include <open62541/types_generated_handling.h>
#include <common/skill_detector/SkillParameter.h>

SkillParameter::SkillParameter(
        std::string browseName,
        std::string typeDefinition,
        std::string dataType):
        browseName(std::move(browseName)), typeDefinition(std::move(typeDefinition)), dataType(std::move(dataType)), value() {
    UA_Variant_init(&value);
}

SkillParameter::~SkillParameter() {
    UA_Variant_deleteMembers(&value);
}

UA_StatusCode SkillParameter::setValue(const UA_Variant &var) {
    return UA_Variant_copy(&var, &value);
}
