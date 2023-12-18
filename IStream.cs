namespace ThemModdingHerds.IO;
public interface IStream
{
    public Endianness Endianness {get; set;}
    public long Offset {get; set;}
}