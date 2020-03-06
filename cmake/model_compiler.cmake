
find_program(Docker_EXECUTABLE docker)
if(NOT Docker_EXECUTABLE)
    message(FATAL_ERROR "Cannot find the docker executable!")
endif()

set(model_compiler_generate_macro_dir ${CMAKE_CURRENT_LIST_DIR})

# --------------- Generate NodeSet2.xml from Model.xml ---------------------
#
# Generates NodeSet2.xml from a Model.xml file
#
# The following arguments are accepted:
#   Options:
#
#   Arguments taking one value:
#
#   FILE_MODEL      Path to the Model.xml file without the extension
#   MODEL_NAME      Name of the model. This is also the name of the subfolder.
#   OUTPUT_DIR      Target directory for the generated files
#
function(model_compiler_generate)
    set(options )
    set(oneValueArgs FILE_MODEL MODEL_NAME OUTPUT_DIR)
    set(multiValueArgs )
    cmake_parse_arguments(MODEL_COMPILE "${options}" "${oneValueArgs}" "${multiValueArgs}" ${ARGN} )

    if(NOT MODEL_COMPILE_FILE_MODEL OR "${MODEL_COMPILE_FILE_MODEL}" STREQUAL "")
        message(FATAL_ERROR "model_compiler_generate function requires a value for the FILE_MODEL argument")
    endif()
    if(NOT MODEL_COMPILE_MODEL_NAME OR "${MODEL_COMPILE_MODEL_NAME}" STREQUAL "")
        message(FATAL_ERROR "model_compiler_generate function requires a value for the MODEL_NAME argument")
    endif()
    if(NOT MODEL_COMPILE_OUTPUT_DIR OR "${MODEL_COMPILE_OUTPUT_DIR}" STREQUAL "")
        message(FATAL_ERROR "model_compiler_generate function requires a value for the OUTPUT_DIR argument")
    endif()

    get_filename_component(FILE_MODEL_NAME "${MODEL_COMPILE_FILE_MODEL}" NAME)
    get_filename_component(FILE_MODEL_DIR "${MODEL_COMPILE_FILE_MODEL}" DIRECTORY)

    file(MAKE_DIRECTORY "${MODEL_COMPILE_OUTPUT_DIR}")

    add_custom_command(OUTPUT
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.NodeSet.xml
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.NodeSet2.xml
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.Types.bsd
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.Types.xsd
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${FILE_MODEL_NAME}.xml
            ${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${FILE_MODEL_NAME}.csv
            PRE_BUILD
            COMMAND ${Docker_EXECUTABLE} run
                        --mount type=bind,source=${FILE_MODEL_DIR},target=/model/src
                        --mount type=bind,source=${MODEL_COMPILE_OUTPUT_DIR},target=/model/src/Published
                        --entrypoint "/app/PublishModel.sh"
                        sailavid/ua-modelcompiler
                        /model/src/${FILE_MODEL_NAME} ${MODEL_COMPILE_MODEL_NAME} /model/src/Published
            DEPENDS
                ${MODEL_COMPILE_FILE_MODEL}.xml
                ${MODEL_COMPILE_FILE_MODEL}.csv
            COMMENT "Generating NodeSet2.xml for ${MODEL_COMPILE_MODEL_NAME}"
            )


endfunction()

# --------------- Generate NodeSet2.xml from Model.xml ---------------------
#
# Generates NodeSet2.xml from a Model.xml file and defines an object which
# can be re-used by other targets. Calls model_compiler_generate first.
#
# The following arguments are accepted:
#   Options:
#
#   Arguments taking one value:
#
#   FILE_MODEL      Path to the Model.xml file without the extension
#   MODEL_NAME      Name of the model. This is also the name of the subfolder.
#   OUTPUT_DIR      Target directory for the generated files
#   NAMESPACE_IDX Optional namespace index of the nodeset, when it is loaded into the server
#
#   Arguments taking multiple values:
#   [DEPENDS]       Optional list of nodeset names on which this nodeset depends. These names must match any name from a previous
#                   call to this funtion. E.g. 'di' if you are generating the 'plcopen' nodeset
#
function(model_compiler_generate_with_object)
    set(options )
    set(oneValueArgs FILE_MODEL MODEL_NAME OUTPUT_DIR NAMESPACE_IDX)
    set(multiValueArgs DEPENDS)
    cmake_parse_arguments(MODEL_COMPILE "${options}" "${oneValueArgs}" "${multiValueArgs}" ${ARGN} )

    if(NOT MODEL_COMPILE_NAMESPACE_IDX OR "${MODEL_COMPILE_NAMESPACE_IDX}" STREQUAL "")
        message(FATAL_ERROR "model_compiler_generate function requires a value for the NAMESPACE_IDX argument")
    endif()

    model_compiler_generate(
            FILE_MODEL "${MODEL_COMPILE_FILE_MODEL}"
            MODEL_NAME "${MODEL_COMPILE_MODEL_NAME}"
            OUTPUT_DIR "${MODEL_COMPILE_OUTPUT_DIR}"
    )

    set(GENERATE_OUTPUT_DIR "${CMAKE_BINARY_DIR}/src_generated/${PROJECT_NAME}-nodeset-${MODEL_COMPILE_MODEL_NAME}")

    file(MAKE_DIRECTORY "${GENERATE_OUTPUT_DIR}")
    include_directories("${GENERATE_OUTPUT_DIR}")

    ua_generate_nodeset_and_datatypes(
            NAME "${MODEL_COMPILE_MODEL_NAME}"
            TARGET_PREFIX "${PROJECT_NAME}-nodeset-${MODEL_COMPILE_MODEL_NAME}"
            FILE_CSV "${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${FILE_MODEL_NAME}.csv"
            FILE_BSD "${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.Types.bsd"
            OUTPUT_DIR "${GENERATE_OUTPUT_DIR}"
            NAMESPACE_IDX ${MODEL_COMPILE_NAMESPACE_IDX}
            FILE_NS "${MODEL_COMPILE_OUTPUT_DIR}/${MODEL_COMPILE_MODEL_NAME}/${MODEL_COMPILE_MODEL_NAME}.NodeSet2.xml"
            DEPENDS ${MODEL_COMPILE_NAMESPACE_DEPENDS}
            INTERNAL
    )

    string(TOUPPER "${MODEL_COMPILE_MODEL_NAME}" TARGET_NAME_UPPER)

    add_library("${PROJECT_NAME}-nodeset-${MODEL_COMPILE_MODEL_NAME}" OBJECT
                ${UA_NODESET_${TARGET_NAME_UPPER}_SOURCES}
                ${UA_TYPES_${TARGET_NAME_UPPER}_SOURCES}
                )

    target_include_directories("${PROJECT_NAME}-nodeset-${MODEL_COMPILE_MODEL_NAME}" PUBLIC "${GENERATE_OUTPUT_DIR}")
endfunction()