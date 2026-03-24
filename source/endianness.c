#include <TMH/IO/Endianness.h>
#include <stddef.h>

void tmhIO_swapEndian(const void *input,void* output,size_t size)
{
    if(input == NULL || output == NULL) return;
    const char* cinput = (const char*)input;
    char* coutput = (char*)output;
    for(size_t i = 0;i < size;i++)
        coutput[i] = cinput[size - i - 1];
}