

add_library(${PROJECT_NAME}-client OBJECT
            SkillClient.cpp
            include/common/client/SkillClient.h
            GenericSkillClient.cpp
            include/common/client/GenericSkillClient.h
            SkillClientParameter.cpp
            include/common/client/SkillClientParameter.h
            robot/MoveSkillClient.cpp
            include/common/client/robot/MoveSkillClient.h
            robot/CartesianMoveSkillClient.cpp
            include/common/client/robot/CartesianMoveSkillClient.h
            robot/JointMoveSkillClient.cpp
            include/common/client/robot/JointMoveSkillClient.h
            robot/LinearMoveSkillClient.cpp
            include/common/client/robot/LinearMoveSkillClient.h
            robot/PtpMoveSkillClient.cpp
            include/common/client/robot/PtpMoveSkillClient.h
            robot/CartesianLinearMoveSkillClient.cpp
            include/common/client/robot/CartesianLinearMoveSkillClient.h
            robot/CartesianPtpMoveSkillClient.cpp
            include/common/client/robot/CartesianPtpMoveSkillClient.h
            robot/JointLinearMoveSkillClient.cpp
            include/common/client/robot/JointLinearMoveSkillClient.h
            robot/JointPtpMoveSkillClient.cpp
            include/common/client/robot/JointPtpMoveSkillClient.h
            robot/ForceSkillClient.cpp
            include/common/client/robot/ForceSkillClient.h
            robot/CartesianLinearForceMoveSkillClient.cpp
            include/common/client/robot/CartesianLinearForceMoveSkillClient.h
            #robot/MovePositionForceSkillClient.cpp
            #robot/MovePositionForceSkillClient.h
            robot/RobotClient.cpp
            include/common/client/robot/RobotClient.h
            gripper/GripperSkillClient.cpp
            include/common/client/gripper/GripperSkillClient.h
            include/common/client/sensor/ForceTorqueSensorClient.h
            sensor/ForceTorqueSensorClient.cpp)

target_include_directories(${PROJECT_NAME}-client PUBLIC
                           ../include
                           ../deps/spdlog/include
                           include
                           $<TARGET_PROPERTY:${PROJECT_NAME}-nodeset,INTERFACE_INCLUDE_DIRECTORIES>
                           $<TARGET_PROPERTY:rl::math,INTERFACE_INCLUDE_DIRECTORIES>)

add_dependencies(${PROJECT_NAME}-client
                 ${PROJECT_NAME}-nodeset
                 )

add_dependencies(${PROJECT_NAME}
                 ${PROJECT_NAME}-client
                 )
target_include_directories(${PROJECT_NAME} INTERFACE
                           $<TARGET_PROPERTY:${PROJECT_NAME}-client,INTERFACE_INCLUDE_DIRECTORIES>)