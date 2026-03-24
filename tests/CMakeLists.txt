macro(tmh_test Name MainC)
    set(NAME test_io_${Name})
    add_executable(${NAME} ${MainC})
    target_link_libraries(${NAME} PRIVATE ${PROJECT_NAME}.IO)
    add_test(NAME ${NAME} COMMAND ${NAME})
endmacro(tmh_test)

tmh_test(endianness endianness.c)
tmh_test(endianness_cpp endianness_cpp.cpp)