# IO

Basic IO library

## Used by

- [ThemModdingHerds.GFS][tmh-gfs-url]
- [ThemModdingHerds.SGA][tmh-sga-url]
- [ThemModdingHerds.SGI][tmh-sgi-url]
- [ThemModdingHerds.SGM][tmh-sgm-url]
- [ThemModdingHerds.SGS][tmh-sgs-url]

## Usage

```c#
using ThemModdingHerds.IO.Binary;
using ThemModdingHerds.IO;

// any stream class
Reader reader = new Reader(SomeStream);
// you can also use a file path
Reader reader = new Reader("path/to/file.txt");
// or raw bytes
Reader reader = new Reader([255,12,54,25]);

reader.Endianness = Endianness.Big; // set endianness to big

int value = reader.ReadInt(); // Read int as big endian

```

[tmh-gfs-url]: https://www.nuget.org/packages/ThemModdingHerds.GFS
[tmh-sga-url]: https://www.nuget.org/packages/ThemModdingHerds.SGA
[tmh-sgi-url]: https://www.nuget.org/packages/ThemModdingHerds.SGI
[tmh-sgm-url]: https://www.nuget.org/packages/ThemModdingHerds.SGM
[tmh-sgs-url]: https://www.nuget.org/packages/ThemModdingHerds.SGS
