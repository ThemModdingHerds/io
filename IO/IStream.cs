namespace ThemModdingHerds.IO;
public interface IStream : IDisposable
{
    public Endianness Endianness {get; set;}
    public long Offset {get; set;}
    public int OffsetInt {get; set;}
    public long Length {get;}
    public int LengthInt {get;}
    public void Close();
}