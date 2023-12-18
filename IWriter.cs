namespace ThemModdingHerds.IO;
public interface IWriter : IStream
{
    public void Write(byte[] value,bool withEndian = false);
    public void Write(byte value);
    public void Write(sbyte value);
    public void Write(short value);
    public void Write(ushort value);
    public void Write(int value);
    public void Write(uint value);
    public void Write(long value);
    public void Write(ulong value);
    public void Write(float value);
    public void Write(double value);
    public void WritePascal64String(string value);
}