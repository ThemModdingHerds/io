# IO

Basic IO library

## Usage

```c#
using ThemModdingHerds.IO.Binary;
using ThemModdingHerds.IO;

Reader reader = new Reader(SomeStream);

reader.Endianness = Endianness.Big; // set endianness to big

int reader.ReadInt(); // Read int as big endian

```
