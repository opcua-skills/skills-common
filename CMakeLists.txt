cmake_minimum_required(VERSION 3.8)

get_directory_property(hasParent PARENT_DIRECTORY)
if(hasParent)
    project(${PROJECT_NAME}-common)
else()
    # common is built standalone
    project(component-common)
endif()

# We need to have at least GCC8 or Clang 7.
# Somehow older versions, especially GCC has some C++14 issues which cause ConnectionClosed errors while trying to execute skills
if("${CMAKE_CXX_COMPILER_ID}" STREQUAL "GNU")
    # require at least gcc 4.8
    if (CMAKE_CXX_COMPILER_VERSION VERSION_LESS 8)
        message(WARNING "GCC version should be at least 8!")
    endif()
elseif ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "Clang")
    # require at least clang 3.2
    if (CMAKE_CXX_COMPILER_VERSION VERSION_LESS 7)
        message(WARNING "Clang version should be at least 7!")
    endif()
else()
    message(WARNING "You are using an unsupported compiler! Compilation has only been tested with Clang and GCC.")
endif()

find_package(open62541 1.0 REQUIRED COMPONENTS FullNamespace Events Encryption)

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(COMMON_DIR "${CMAKE_CURRENT_LIST_DIR}")
get_directory_property(hasParent PARENT_DIRECTORY)
if(hasParent)
    set(COMMON_DIR "${CMAKE_CURRENT_LIST_DIR}" PARENT_SCOPE)
endif()

# Debug
string(TOLOWER "${CMAKE_BUILD_TYPE}" BUILD_TYPE_LOWER_CASE)
if(BUILD_TYPE_LOWER_CASE STREQUAL "debug")
    if("x${CMAKE_C_COMPILER_ID}" STREQUAL "xClang")
        # Add default sanitizer settings when using clang and Debug build.
        # This allows e.g. CLion to find memory locations for SegFaults
        message(STATUS "Clang Sanitizer enabled")
        set(SANITIZER_FLAGS "-g -fno-omit-frame-pointer -gline-tables-only -fsanitize=address -fsanitize-address-use-after-scope -fsanitize-coverage=trace-pc-guard,trace-cmp -fsanitize=leak -fsanitize=undefined")
        if (hasParent)
            set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} ${SANITIZER_FLAGS}" PARENT_SCOPE)
            set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${SANITIZER_FLAGS}" PARENT_SCOPE)
        else()
            set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} ${SANITIZER_FLAGS}")
            set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${SANITIZER_FLAGS}")
        endif()
    endif()
endif()

find_package(rl 0.7.0 REQUIRED COMPONENTS math hal mdl)

set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} ${CMAKE_CURRENT_LIST_DIR}/cmake)

add_library(${PROJECT_NAME} OBJECT
            server/OpcUaServer.cpp
            include/common/opcua/server/OpcUaServer.h
            server/DeviceVariable.cpp
            include/common/opcua/server/DeviceVariable.h
)
add_subdirectory(nodeset)
add_subdirectory(client)
add_subdirectory(skill_detector)

target_include_directories(${PROJECT_NAME} PUBLIC
                           include
                           deps/spdlog/include
                           $<TARGET_PROPERTY:open62541::open62541,INTERFACE_INCLUDE_DIRECTORIES>
                           $<TARGET_PROPERTY:${PROJECT_NAME}-nodeset,INTERFACE_INCLUDE_DIRECTORIES>
                           )
add_dependencies(${PROJECT_NAME}
                 ${PROJECT_NAME}-nodeset
                 open62541::open62541
                 )

function(generate_certificate)
    set(options  )
    set(oneValueArgs TARGET_NAME HOSTNAME APP_URI OUTPUT_DIR)
    set(multiValueArgs )
    cmake_parse_arguments(GEN_CERT "${options}" "${oneValueArgs}" "${multiValueArgs}" ${ARGN} )

    if(NOT GEN_CERT_APP_URI OR "${GEN_CERT_APP_URI}" STREQUAL "")
        message(FATAL_ERROR "generate_certificate function requires a value for the APP_URI argument")
    endif()
    if(NOT GEN_CERT_OUTPUT_DIR OR "${GEN_CERT_OUTPUT_DIR}" STREQUAL "")
        message(FATAL_ERROR "generate_certificate function requires a value for the OUTPUT_DIR argument")
    endif()
    if(NOT GEN_CERT_TARGET_NAME OR "${GEN_CERT_TARGET_NAME}" STREQUAL "")
        message(FATAL_ERROR "generate_certificate function requires a value for the TARGET_NAME argument")
    endif()

    if (GEN_CERT_HOSTNAME)
        set(HOSTNAME "${GEN_CERT_HOSTNAME}")
    else()
        if (CUSTOM_HOSTNAME)
            set(HOSTNAME "${CUSTOM_HOSTNAME}")
        else()
            cmake_host_system_information(RESULT HOSTNAME QUERY HOSTNAME)
        endif()
    endif()

    add_custom_command(OUTPUT ${GEN_CERT_OUTPUT_DIR}/${HOSTNAME}_cert.der
                       ${GEN_CERT_OUTPUT_DIR}/${HOSTNAME}_key.der
                       PRE_BUILD
                       COMMAND ${PYTHON_EXECUTABLE} ${COMMON_DIR}/tools/create_self-signed.py
                       --application-uri=${GEN_CERT_APP_URI}
                       --key=4096
                       --hostname=${HOSTNAME}
                       ${GEN_CERT_OUTPUT_DIR}
                       DEPENDS
                       ${COMMON_DIR}/tools/ssl_host.cnf
                       ${COMMON_DIR}/tools/create_self-signed.py
                       )

    add_custom_target(${GEN_CERT_TARGET_NAME}
                      DEPENDS
                      ${GEN_CERT_OUTPUT_DIR}/${HOSTNAME}_cert.der
                      ${GEN_CERT_OUTPUT_DIR}/${HOSTNAME}_key.der)
endfunction()


enable_testing()

option(COMMON_TEST_BUILD "Enable target to build all headers" OFF)
mark_as_advanced(COMMON_TEST_BUILD)

if(COMMON_TEST_BUILD)
    add_subdirectory(test)
endif()
