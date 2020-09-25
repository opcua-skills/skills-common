


file(GLOB_RECURSE all_headers RELATIVE "${CMAKE_CURRENT_LIST_DIR}/../include" "${CMAKE_CURRENT_LIST_DIR}/../include/*.hpp" "${CMAKE_CURRENT_LIST_DIR}/../include/*.h")

set(all_headers_include "")

foreach(h ${all_headers})
    set(all_headers_include "${all_headers_include}
    #include <${h}>")
endforeach()

configure_file(all_headers.h.in all_headers.h)

add_executable(test_all_headers test_headers.cpp)

target_link_libraries(test_all_headers
                      open62541::open62541)

add_dependencies(test_all_headers
                 ${PROJECT_NAME}
                 ${PROJECT_NAME}-nodeset
                 open62541::open62541
                 )

target_include_directories(test_all_headers PRIVATE
                           include
                           ${CMAKE_CURRENT_BINARY_DIR}
                           $<TARGET_PROPERTY:${PROJECT_NAME},INTERFACE_INCLUDE_DIRECTORIES>
                           $<TARGET_PROPERTY:rl::math,INTERFACE_INCLUDE_DIRECTORIES>)