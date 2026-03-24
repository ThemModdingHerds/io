#include <TMH/IO.hpp>

#include <cstdint>
#include <cassert>

#define TEST(type,le,be) \
    assert(::TMH::IO::swapEndian<type>(le) == be);

int main(int argc,char** argv)
{
    TEST(::std::int16_t,-500,3326)
    TEST(::std::uint16_t,60000,24810)
    TEST(::std::int32_t,-50000,-1338179585)
    TEST(::std::uint32_t,4000000000,2649070)
    TEST(::std::int64_t,-9000000000000000000,136466941548931)
    TEST(::std::uint64_t,10000000000000000000U,255675177617290)

    return EXIT_SUCCESS;
}