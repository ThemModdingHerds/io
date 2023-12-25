# IO

Basic IO library

## Used by

- [ThemModdingHerds.GFS][tmh-gfs-url]

## Usage

```c#
using ThemModdingHerds.IO.Binary;
using ThemModdingHerds.IO;

Reader reader = new Reader(SomeStream);

reader.Endianness = Endianness.Big; // set endianness to big

int reader.ReadInt(); // Read int as big endian

```

[tmh-gfs-url]: https://www.nuget.org/packages/ThemModdingHerds.GFS
