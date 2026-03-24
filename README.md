# ThemModdingHerds.IO

Basic IO library

## Used by

- [ThemModdingHerds.GFS][tmh-gfs-url]
- [ThemModdingHerds.Levels][tmh-levels-url]
- [ThemModdingHerds.Foits][tmh-foits-url]

## Setup

### Building

```sh
mkdir build
cd build
# use CMake to configure & build
cmake ..
cmake --build .
```

### Integrate into a CMake project

```cmake
# this is it, no target_include_directories required
target_link_libraries(<target> PRIVATE ThemModdingHerds.IO)
```

## Usage

### C

```c
#include <TMH/IO.h>

int main(int argc,char** argv)
{
    int a = 200;
    int b;
    // swaps byte order of a (so if a was little, b is big)
    tmhIO_swapEndian(&a,&b,sizeof(int));

    return 0;
}
```

### C++

The C++ is a header-only, though linking the library is still required

```c++
#include <TMH/IO.hpp>

int main(int argc,char** argv)
{
    // swaps byte order of any type
    int a = ::TMH::IO::swapEndian<int>(200);
    // wrappers around ::std::istream and ::std::ostream
    ::TMH::IO::IStreamReader reader(any_istream_reference);
    int b = reader.read<int>();

    ::TMH::IO::OStreamWriter writer(any_ostream_reference);
    writer.write<int>(b);
    // you can extend ::TMH::IO::Reader or ::TMH::IO::Writer to
    // implement a custom reader/writer
}
```

[nuget-url]: https://www.nuget.org/packages/ThemModdingHerds.IO/
[tmh-gfs-url]: https://www.nuget.org/packages/ThemModdingHerds.GFS
[tmh-levels-url]: https://www.nuget.org/packages/ThemModdingHerds.Levels
[tmh-foits-url]: https://www.nuget.org/packages/ThemModdingHerds.Foits
