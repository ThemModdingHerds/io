#include <TMH/IO/Endianness.h>

#include <stdint.h>
#include <stdlib.h>
#include <assert.h>

#define TEST(type,le,be) \
    { \
        type value = le; \
        type valuebe; \
        tmhIO_swapEndian(&value, &valuebe, sizeof(type)); \
        assert(valuebe == be); \
    }

int main(int argc,char** argv)
{
    TEST(int16_t,-500,3326)
    TEST(uint16_t,60000,24810)
    TEST(int32_t,-50000,-1338179585)
    TEST(uint32_t,4000000000,2649070)
    TEST(int64_t,-9000000000000000000,136466941548931)
    TEST(uint64_t,10000000000000000000U,255675177617290)
    // cannot test floats if wondering
    return EXIT_SUCCESS;
}