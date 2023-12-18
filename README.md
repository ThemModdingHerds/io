# IO

Basic IO library

## Usage

```c#
using ThemModdingHerds.IO;

BinaryReader reader = new BinaryReader(SomeStream);

reader.Endianness = Endianness.Big; // set endianness to big

int reader.ReadInt(); // Read int as big endian

```
