using ThemModdingHerds.IO.Binary;

string path = "test.txt";

Writer writer = new(path);

writer.WritePascal64String("ass");
writer.Write(100UL);