#ifndef _TMH_IO_ENDIANNESS_H
#define _TMH_IO_ENDIANNESS_H

#include <stddef.h>

#ifdef __cplusplus
extern "C"
{
#endif
/// swaps the bytes of input to big endian in output. Input and output should be the same type
void tmhIO_swapEndian(const void* input,void* output,size_t size);
#ifdef __cplusplus
}
#endif

#endif