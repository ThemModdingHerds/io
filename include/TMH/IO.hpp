#ifndef __TMH_IO_HPP
#define __TMH_IO_HPP

#include "IO.h"

#include <cstddef>
#include <string>
#include <vector>
#include <istream>
#include <ostream>

namespace TMH
{
    namespace IO
    {
        template<typename T>
        static inline T swapEndian(const T &value)
        {
            T result;
            ::tmhIO_swapEndian(&value,&result,sizeof(T));
            return result;
        }
        enum struct Endianness
        {
            Little,
            Big
        };
        class Stream
        {
        private:
            Endianness mEndianness;
        public:
            Endianness endianness() const
            {
                return mEndianness;
            }
            void setEndianness(const Endianness &endianness)
            {
                mEndianness = endianness;
            }
            virtual ::std::size_t offset() = 0;
            virtual void setOffset(::std::size_t offset) = 0;
            virtual ::std::size_t length() = 0;
        };
        class Reader : public Stream
        {
        public:
            virtual void read(void* output,::std::size_t size) = 0;
            template<typename T>
            inline T read()
            {
                T output;
                read(output,sizeof(T));
                return output;
            }
            template<typename T>
            ::std::vector<T> readVector(::std::size_t length)
            {
                ::std::vector<T> vector;
                for(::std::size_t i = 0;i < length;i++)
                {
                    T item = read<T>();
                    vector.push_back(item);
                }
                return vector;
            }
            template<typename CharT>
            ::std::basic_string<CharT> readString(::std::size_t length)
            {
                ::std::basic_string<CharT> string;
                for(::std::size_t i = 0;i < length;i++)
                {
                    CharT item = read<CharT>();
                    string += item;
                }
                return string;
            }
            template<typename LengthT,typename CharT>
            ::std::basic_string<CharT> readPascalString()
            {
                LengthT length = read<LengthT>();
                return readString<CharT>(static_cast<::std::size_t>(length));
            }
        };
        class Writer : public Stream
        {
        public:
            virtual void write(const void* input,::std::size_t size) = 0;
            template<typename T>
            void write(const T* input)
            {
                write(input,sizeof(T));
            }
            template<typename T>
            void write(const ::std::vector<T> &vector)
            {
                for(const T &item : vector)
                    write(&item);
            }
            template<typename CharT>
            void write(const ::std::basic_string<CharT> &string)
            {
                for(const CharT &item : string)
                    write(&item);
            }
            template<typename LengthT,typename CharT>
            void write(const ::std::basic_string<CharT> &string)
            {
                write<LengthT>(static_cast<LengthT>(string.length()));
                write<CharT>(string);
            }
        };
        class IStreamReader : public Reader
        {
        private:
            ::std::istream &mStream;
        public:
            IStreamReader(::std::istream &stream): mStream(stream) {}

            ::std::size_t offset() override
            {
                return mStream.tellg();
            }
            void setOffset(::std::size_t offset) override
            {
                mStream.seekg(offset);
            }
            ::std::size_t length() override
            {
                ::std::size_t pos = offset();
                mStream.seekg(0,::std::ios::end);
                ::std::size_t len = offset();
                mStream.seekg(pos);
                return len;
            }
            void read(void* input,::std::size_t size) override
            {
                mStream.read(reinterpret_cast<::std::istream::char_type*>(input),size);
            }
        };
        class OStreamWriter : public Writer
        {
        private:
            ::std::ostream &mStream;
        public:
            OStreamWriter(::std::ostream &stream): mStream(stream) {}

            ::std::size_t offset() override
            {
                return mStream.tellp();
            }
            void setOffset(::std::size_t offset) override
            {
                mStream.seekp(offset);
            }
            ::std::size_t length() override
            {
                ::std::size_t pos = offset();
                mStream.seekp(0,::std::ios::end);
                ::std::size_t len = offset();
                mStream.seekp(pos);
                return len;
            }
            void write(const void* input,::std::size_t size) override
            {
                mStream.write(reinterpret_cast<const ::std::ostream::char_type*>(input),size);
            }
        };
    }
}

#endif