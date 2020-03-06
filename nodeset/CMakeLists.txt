set(GENERATE_OUTPUT_DIR "${CMAKE_BINARY_DIR}/src_generated/${PROJECT_NAME}-client")

file(MAKE_DIRECTORY "${GENERATE_OUTPUT_DIR}")

set(PREFIX ${PROJECT_NAME})

ua_generate_nodeset_and_datatypes(
        NAME "di"
        TARGET_PREFIX "${PREFIX}"
        FILE_CSV "${open62541_NODESET_DIR}/DI/OpcUaDiModel.csv"
        FILE_BSD "${open62541_NODESET_DIR}/DI/Opc.Ua.Di.Types.bsd"
        OUTPUT_DIR "${GENERATE_OUTPUT_DIR}"
        NAMESPACE_IDX 2
        FILE_NS "${open62541_NODESET_DIR}/DI/Opc.Ua.Di.NodeSet2.xml"
        INTERNAL
)

ua_generate_nodeset_and_datatypes(
        NAME "rob"
        TARGET_PREFIX "${PREFIX}"
        FILE_CSV "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/vdma_robotics/Published/Robotics/OpcUaRoboticsModel.csv"
        FILE_BSD "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/vdma_robotics/Published/Robotics/Opc.Ua.Robotics.Types.bsd"
        OUTPUT_DIR "${GENERATE_OUTPUT_DIR}"
        NAMESPACE_IDX 3
        FILE_NS "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/vdma_robotics/Published/Robotics/Opc.Ua.Robotics.NodeSet2.xml"
        DEPENDS "di"
        INTERNAL
)


ua_generate_nodeset_and_datatypes(
        NAME "fortiss_device"
        TARGET_PREFIX "${PREFIX}"
        FILE_CSV "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/device/Published/fortiss_Device/fortissDeviceModel.csv"
        FILE_BSD "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/device/Published/fortiss_Device/fortiss_Device.Types.bsd"
        OUTPUT_DIR "${GENERATE_OUTPUT_DIR}"
        NAMESPACE_IDX 4
        FILE_NS "${PROJECT_SOURCE_DIR}/deps/robotics_cs/deps/device/Published/fortiss_Device/fortiss_Device.NodeSet2.xml"
        DEPENDS "di"
        INTERNAL
)

ua_generate_nodeset_and_datatypes(
        NAME "for_rob"
        TARGET_PREFIX "${PREFIX}"
        FILE_CSV "${PROJECT_SOURCE_DIR}/deps/robotics_cs/Published/fortiss_Robotics/fortissRoboticsModel.csv"
        FILE_BSD "${PROJECT_SOURCE_DIR}/deps/robotics_cs/Published/fortiss_Robotics/fortiss_Robotics.Types.bsd"
        OUTPUT_DIR "${GENERATE_OUTPUT_DIR}"
        NAMESPACE_IDX 5
        FILE_NS "${PROJECT_SOURCE_DIR}/deps/robotics_cs/Published/fortiss_Robotics/fortiss_Robotics.NodeSet2.xml"
        DEPENDS "rob" "fortiss_device"
        INTERNAL
)

add_library(${PROJECT_NAME}-nodeset OBJECT
            ${UA_NODESET_DI_SOURCES}
            ${UA_NODESET_FOR_ROB_SOURCES}
            ${UA_NODESET_ROB_SOURCES}
            ${UA_NODESET_FORTISS_DEVICE_SOURCES}
            ${UA_TYPES_DI_SOURCES}
            ${UA_TYPES_FOR_ROB_SOURCES}
            ${UA_TYPES_ROB_SOURCES}
            ${UA_TYPES_FORTISS_DEVICE_SOURCES})

target_include_directories(${PROJECT_NAME}-nodeset PUBLIC
                           ${GENERATE_OUTPUT_DIR}
                           $<TARGET_PROPERTY:open62541::open62541,INTERFACE_INCLUDE_DIRECTORIES>)

add_dependencies(${PROJECT_NAME}-nodeset
                 ${PREFIX}-ns-for_rob
                 )

add_dependencies(${PROJECT_NAME}
                 ${PROJECT_NAME}-nodeset
                 )

target_include_directories(${PROJECT_NAME} INTERFACE
                           $<TARGET_PROPERTY:${PROJECT_NAME}-nodeset,INTERFACE_INCLUDE_DIRECTORIES>)