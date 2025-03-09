using ThemModdingHerds.IO.Binary;

string path = "test.txt";

using Writer writer = new(path);

writer.Write(1234.5678);