/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef FORTISS_COMMON_SKILLHELPER_HPP
#define FORTISS_COMMON_SKILLHELPER_HPP

#include <common/skill_detector/RegisteredSkill.h>
#include <common/skill_detector/SkillParameter.h>

namespace fortiss {
    namespace skill {

        inline
        UA_StatusCode moveRobotToCartesian(std::shared_ptr <RegisteredSkill> moveSkill,
                                           std::shared_ptr <spdlog::logger>& loggerApp,
                                           std::shared_ptr <spdlog::logger>& loggerOpcua,
                                           const UA_ThreeDFrame& position,
                                           const std::string& toolFrame = "",
                                           const double maxVelocity[6] = nullptr,
                                           const double maxAcceleration[6] = nullptr,
                                           const UA_Range axisBounds[6] = nullptr) {

            loggerApp->info("Executing skill {} on {}", moveSkill->getSkillNameStr(),
                         moveSkill->getParentComponent()->endpointUrl);

            std::vector <std::shared_ptr<SkillParameter>> moveParameters = std::vector < std::shared_ptr < SkillParameter >> ();
            moveParameters.reserve(4);

            if (maxVelocity) {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_StatusCode retval = UA_Variant_setArrayCopy(&val, maxVelocity, 6,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD)
                    return retval;
                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32 *) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = 1;
                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "MaxVelocity",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            if (maxAcceleration) {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_StatusCode retval = UA_Variant_setArrayCopy(&val, maxAcceleration, 6,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD)
                    return retval;
                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32 *) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = 1;
                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "MaxAcceleration",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            {
                UA_Variant val;
                UA_Variant_init(&val);

                if (axisBounds) {
                    UA_StatusCode retval = UA_Variant_setArrayCopy(&val, axisBounds, 6,
                                                                   &UA_TYPES[UA_TYPES_RANGE]);
                    if (retval != UA_STATUSCODE_GOOD)
                        return retval;
                } else {
                    UA_Range axisBoundsTmp[6];
                    // set to 0 to reset previous calls
                    memset(&axisBoundsTmp, 0, sizeof(UA_Range)*6);
                    UA_StatusCode retval = UA_Variant_setArrayCopy(&val, axisBoundsTmp, 6,
                                                                   &UA_TYPES[UA_TYPES_RANGE]);
                    if (retval != UA_STATUSCODE_GOOD)
                        return retval;
                }
                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32*) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = 1;
                std::shared_ptr<SkillParameter> param = std::make_shared<SkillParameter>(
                        "AxisBounds",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }


            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_StatusCode retval = UA_Variant_setScalarCopy(&val, &position,
                                                                &UA_TYPES[UA_TYPES_THREEDFRAME]);

                if (retval != UA_STATUSCODE_GOOD) {
                    loggerApp->error("Failed to copy targetCartesianPosition. {}", UA_StatusCode_name(retval));
                    return retval;
                }

                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "TargetPosition",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            {
                UA_Variant val;
                UA_Variant_init(&val);

                const UA_String str = {
                        toolFrame.length(),
                        (UA_Byte * ) const_cast<char *>(toolFrame.c_str())
                };

                UA_StatusCode retval = UA_Variant_setScalarCopy(&val, &str,
                                                                &UA_TYPES[UA_TYPES_STRING]);

                if (retval != UA_STATUSCODE_GOOD) {
                    loggerApp->error("Failed to copy toolFrame. {}", UA_StatusCode_name(retval));
                    return retval;
                }

                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "ToolFrame",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            UA_StatusCode result = UA_STATUSCODE_GOOD;
            std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
            bool success = false;
            try {
                success = moveSkill->execute(loggerApp, loggerOpcua, moveParameters).get();
                if (!success) {
                    loggerApp->warn("Skill execution returned false. Probably there was an issue while running.");
                }
            } catch (fortiss::opcua::StatusCodeException& ex) {
                loggerApp->error("Skill execution failed with error {}", UA_StatusCode_name(ex.get_code()));
                result = ex.get_code();
            }
            std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

            loggerApp->info("Finished skill execution {} on {}.\n\tDuration: {} [ms]\n\tResult: {}\n\tSuccess: {}",
                         moveSkill->getSkillNameStr(),
                         moveSkill->getParentComponent()->endpointUrl,
                         std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count(),
                         UA_StatusCode_name(result), success);

            if (!success)
                return UA_STATUSCODE_BADINTERNALERROR;

            return result;
        }

        template<int AXIS_COUNT>
        inline UA_StatusCode moveRobotToJoint(std::shared_ptr <RegisteredSkill> moveSkill,
                                              std::shared_ptr <spdlog::logger>& loggerApp,
                                              std::shared_ptr <spdlog::logger>& loggerOpcua,
                                              const std::array<double, AXIS_COUNT>& targetJointPosition,
                                              const std::string& toolFrame = "",
                                              const std::array<double, AXIS_COUNT>& maxVelocity = nullptr,
                                              const std::array<double, AXIS_COUNT>& maxAcceleration = nullptr) {

            loggerApp->info("Executing skill {} on {}", moveSkill->getSkillNameStr(),
                         moveSkill->getParentComponent()->endpointUrl);

            std::vector <std::shared_ptr<SkillParameter>> moveParameters = std::vector < std::shared_ptr < SkillParameter >> ();
            moveParameters.reserve(4);

            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_Double vals[AXIS_COUNT];
                for (size_t i=0; i<AXIS_COUNT; i++)
                    vals[i] = maxVelocity[i];
                UA_StatusCode retval = UA_Variant_setArrayCopy(&val, vals, AXIS_COUNT,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD)
                    return retval;
                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32 *) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = AXIS_COUNT;
                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "MaxVelocity",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_Double vals[AXIS_COUNT];
                for (size_t i=0; i<AXIS_COUNT; i++)
                    vals[i] = maxAcceleration[i];
                UA_StatusCode retval = UA_Variant_setArrayCopy(&val, vals, AXIS_COUNT,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD)
                    return retval;
                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32 *) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = AXIS_COUNT;
                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "MaxAcceleration",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_Double vals[AXIS_COUNT];
                for (size_t i=0; i<AXIS_COUNT; i++)
                    vals[i] = targetJointPosition[i];
                UA_StatusCode retval = UA_Variant_setArrayCopy(&val, vals, AXIS_COUNT,
                                                               &UA_TYPES[UA_TYPES_DOUBLE]);
                if (retval != UA_STATUSCODE_GOOD)
                    return retval;


                val.arrayDimensionsSize = 1;
                val.arrayDimensions = (UA_UInt32*) UA_Array_new(1, &UA_TYPES[UA_TYPES_UINT32]);
                val.arrayDimensions[0] = AXIS_COUNT;
                std::shared_ptr<SkillParameter> param = std::make_shared<SkillParameter>(
                        "TargetJointPosition",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }


            {
                UA_Variant val;
                UA_Variant_init(&val);

                const UA_String str = {
                        toolFrame.length(),
                        (UA_Byte * ) const_cast<char *>(toolFrame.c_str())
                };

                UA_StatusCode retval = UA_Variant_setScalarCopy(&val, &str,
                                                                &UA_TYPES[UA_TYPES_STRING]);

                if (retval != UA_STATUSCODE_GOOD) {
                    loggerApp->error("Failed to copy toolFrame. {}", UA_StatusCode_name(retval));
                    return retval;
                }

                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "ToolFrame",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            UA_StatusCode result = UA_STATUSCODE_GOOD;
            std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
            bool success = false;
            try {
                success = moveSkill->execute(loggerApp, loggerOpcua, moveParameters).get();
                if (!success) {
                    loggerApp->warn("Skill execution returned false. Probably there was an issue while running.");
                }
            } catch (fortiss::opcua::StatusCodeException& ex) {
                loggerApp->error("Skill execution failed with error {}", UA_StatusCode_name(ex.get_code()));
                result = ex.get_code();
            }
            std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

            loggerApp->info("Finished skill execution {} on {}.\n\tDuration: {} [ms]\n\tResult: {}\n\tSuccess: {}",
                         moveSkill->getSkillNameStr(),
                         moveSkill->getParentComponent()->endpointUrl,
                         std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count(),
                         UA_StatusCode_name(result), success);

            if (!success)
                return UA_STATUSCODE_BADINTERNALERROR;

            return result;
        }


        inline
        UA_StatusCode moveRobotToCartesian(std::shared_ptr <RegisteredSkill> moveSkill,
                                           std::shared_ptr <spdlog::logger>& loggerApp,
                                           std::shared_ptr <spdlog::logger>& loggerOpcua,
                                           const rl::math::Transform& position,
                                           const std::string& toolFrame = "",
                                           const double maxVelocity[6] = nullptr,
                                           const double maxAcceleration[6] = nullptr,
                                           const UA_Range axisBounds[6] = nullptr) {
            rl::math::Vector3 vec = position.rotation().eulerAngles(2, 1, 0).reverse();
            UA_ThreeDFrame newPos = {
                    .cartesianCoordinates = {
                            .x = position.translation().x(),
                            .y = position.translation().y(),
                            .z = position.translation().z()
                    },
                    .orientation = {
                            .a = vec.x(),
                            .b = vec.y(),
                            .c = vec.z(),
                    }
            };
            return moveRobotToCartesian(moveSkill, loggerApp, loggerOpcua, newPos, toolFrame, maxVelocity, maxAcceleration, axisBounds);
        }

        inline
        UA_StatusCode callSkillNoParameters(std::shared_ptr <RegisteredSkill> skill,
                                           std::shared_ptr <spdlog::logger>& loggerApp,
                                           std::shared_ptr <spdlog::logger>& loggerOpcua) {
            loggerApp->info("Executing skill {} on {}", skill->getSkillNameStr(),
                         skill->getParentComponent()->endpointUrl);

            std::vector <std::shared_ptr<SkillParameter>> parameters = std::vector < std::shared_ptr < SkillParameter >> ();
            parameters.reserve(0);

            UA_StatusCode result = UA_STATUSCODE_GOOD;
            std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
            bool success = false;
            try {
                success = skill->execute(loggerApp, loggerOpcua, parameters).get();
                if (!success) {
                    loggerApp->warn("Skill execution returned false. Probably there was an issue while running.");
                }
            } catch (fortiss::opcua::StatusCodeException& ex) {
                loggerApp->error("Skill execution failed with error {}", UA_StatusCode_name(ex.get_code()));
                result = ex.get_code();
            }
            std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

            loggerApp->info("Finished skill execution {} on {}.\n\tDuration: {} [ms]\n\tResult: {}\n\tSuccess: {}",
                         skill->getSkillNameStr(),
                         skill->getParentComponent()->endpointUrl,
                         std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count(),
                         UA_StatusCode_name(result), success);

            if (!success)
                return UA_STATUSCODE_BADINTERNALERROR;

            return result;
        }

        inline
        UA_StatusCode moveGripperSkill(std::shared_ptr <RegisteredSkill> moveSkill,
                                           std::shared_ptr <spdlog::logger>& loggerApp,
                                           std::shared_ptr <spdlog::logger>& loggerOpcua,
                                           const double width,
                                           const double force = 0) {

            loggerApp->info("Executing skill {} on {}", moveSkill->getSkillNameStr(),
                            moveSkill->getParentComponent()->endpointUrl);

            std::vector <std::shared_ptr<SkillParameter>> moveParameters = std::vector < std::shared_ptr < SkillParameter >> ();
            moveParameters.reserve(2);

            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_StatusCode retval = UA_Variant_setScalarCopy(&val, &width,
                                                                &UA_TYPES[UA_TYPES_DOUBLE]);

                if (retval != UA_STATUSCODE_GOOD) {
                    loggerApp->error("Failed to copy width. {}", UA_StatusCode_name(retval));
                    return retval;
                }

                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "Width",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }
            {
                UA_Variant val;
                UA_Variant_init(&val);
                UA_StatusCode retval = UA_Variant_setScalarCopy(&val, &force,
                                                                &UA_TYPES[UA_TYPES_DOUBLE]);

                if (retval != UA_STATUSCODE_GOOD) {
                    loggerApp->error("Failed to copy force. {}", UA_StatusCode_name(retval));
                    return retval;
                }

                std::shared_ptr <SkillParameter> param = std::make_shared<SkillParameter>(
                        "Force",
                        "",
                        "");
                param->setValue(val);
                UA_Variant_clear(&val);
                moveParameters.emplace_back(param);
            }

            UA_StatusCode result = UA_STATUSCODE_GOOD;
            std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
            bool success = false;
            try {
                success = moveSkill->execute(loggerApp, loggerOpcua, moveParameters).get();
                if (!success) {
                    loggerApp->warn("Skill execution returned false. Probably there was an issue while running.");
                }
            } catch (fortiss::opcua::StatusCodeException& ex) {
                loggerApp->error("Skill execution failed with error {}", UA_StatusCode_name(ex.get_code()));
                result = ex.get_code();
            }
            std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

            loggerApp->info("Finished skill execution {} on {}.\n\tDuration: {} [ms]\n\tResult: {}\n\tSuccess: {}",
                            moveSkill->getSkillNameStr(),
                            moveSkill->getParentComponent()->endpointUrl,
                            std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count(),
                            UA_StatusCode_name(result), success);

            if (!success)
                return UA_STATUSCODE_BADINTERNALERROR;

            return result;
        }
    }
}

#endif //FORTISS_COMMON_SKILLHELPER_HPP
