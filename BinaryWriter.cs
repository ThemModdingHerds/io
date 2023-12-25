namespace ThemModdingHerds.IO.Binary;
public class Writer(BinaryWriter writer) : IWriter
{
    private readonly BinaryWriter _writer = writer;
    private Endianness _endianness = Utils.SystemEndianness;
    public Writer(Stream stream) : this(new (stream))
    {
        
    }
    public Writer(string path) : this(File.OpenWrite(path))
    {
        
    }
    public Endianness Endianness { get => _endianness; set => _endianness = value; }
    public long Offset { get => _writer.BaseStream.Position; set => _writer.BaseStream.Position = value; }
    public void Write(byte[] value, bool withEndian = false)
    {
        _writer.Write(withEndian ? Utils.ConvertToEndianness(value,Endianness) : value);
    }
    public void Write(byte value)
    {
        _writer.Write(value);
    }
    public void Write(sbyte value)
    {
        _writer.Write(value);
    }
    public void Write(short value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ushort value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(int value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(uint value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(long value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ulong value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(float value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(double value)
    {
        _writer.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void WritePascal64String(string value)
    {
        Write((ulong)value.Length);
        foreach (char letter in value)
            Write((byte)letter);
    }
}