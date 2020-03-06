
add_library(${PROJECT_NAME}-skill-detector OBJECT
            include/common/skill_detector/SkillDetector.h
            SkillDetector.cpp
            RegisteredComponent.cpp
            include/common/skill_detector/RegisteredComponent.h
            include/common/skill_detector/RegisteredSkill.h
            RegisteredSkill.cpp
            SkillParameter.cpp
            include/common/skill_detector/SkillParameter.h)

target_include_directories(${PROJECT_NAME}-skill-detector PUBLIC
                           ../include
                           ../deps/spdlog/include
                           include
                           $<TARGET_PROPERTY:${PROJECT_NAME}-client,INTERFACE_INCLUDE_DIRECTORIES>
                           $<TARGET_PROPERTY:open62541::open62541,INTERFACE_INCLUDE_DIRECTORIES>
                           $<TARGET_PROPERTY:rl::math,INTERFACE_INCLUDE_DIRECTORIES>)

add_dependencies(${PROJECT_NAME}-skill-detector
                 ${PROJECT_NAME}-nodeset
                 open62541::open62541
        )

add_dependencies(${PROJECT_NAME}
                 ${PROJECT_NAME}-skill-detector
                 )