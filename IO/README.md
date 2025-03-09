# IO

Basic IO library

## Used by

- [ThemModdingHerds.GFS][tmh-gfs-url]
- [ThemModdingHerds.Levels][tmh-levels-url]
- [ThemModdingHerds.Foits][tmh-foits-url]

## Usage

```c#
using ThemModdingHerds.IO.Binary;
using ThemModdingHerds.IO;

// any stream class
using Reader reader = new Reader(SomeStream);
// you can also use a file path
using Reader reader = new Reader("path/to/file.txt");
// or raw bytes
using Reader reader = new Reader([255,12,54,25]);

reader.Endianness = Endianness.Big; // set endianness to big

int value = reader.ReadInt(); // Read int as big endian

```

[tmh-gfs-url]: https://www.nuget.org/packages/ThemModdingHerds.GFS
[tmh-levels-url]: https://www.nuget.org/packages/ThemModdingHerds.Levels
[tmh-foits-url]: https://www.nuget.org/packages/ThemModdingHerds.Foits
