cmake_minimum_required(VERSION 4.0.0)

project(ThemModdingHerds)

option(TMH_IO_ENABLE_TEST "Enable tests for ${PROJECT_NAME}.IO" TRUE)

add_library(${PROJECT_NAME}.IO)
target_sources(${PROJECT_NAME}.IO
    PRIVATE
        source/endianness.c
    PUBLIC
        FILE_SET headers
        TYPE HEADERS
        BASE_DIRS
            include
        FILES
            include/TMH/IO.h
            include/TMH/IO.hpp
            include/TMH/IO/Endianness.h
)

if(TRUE)
    message(STATUS "Enabled tests for ${PROJECT_NAME}.IO")
    add_subdirectory(tests)
endif()