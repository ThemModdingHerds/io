namespace ThemModdingHerds.IO.Binary;
public class Writer(BinaryWriter writer) : IWriter
{
    private  BinaryWriter BaseWriter {get;} = writer;
    public Writer(Stream stream) : this(new BinaryWriter(stream))
    {
        
    }
    public Writer(string path) : this(File.OpenWrite(path))
    {
        
    }
    public Endianness Endianness { get; set; } = Utils.SystemEndianness;
    public long Offset { get => BaseWriter.BaseStream.Position; set => BaseWriter.BaseStream.Position = value; }
    public void Write(byte[] value, bool withEndian = false)
    {
        BaseWriter.Write(withEndian ? Utils.ConvertToEndianness(value,Endianness) : value);
    }
    public void Write(byte value)
    {
        BaseWriter.Write(value);
    }
    public void Write(sbyte value)
    {
        BaseWriter.Write(value);
    }
    public void Write(short value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ushort value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(int value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(uint value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(long value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ulong value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(float value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(double value)
    {
        BaseWriter.Write(Utils.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void WritePascal64String(string value)
    {
        Write((ulong)value.Length);
        WriteASCII(value);
    }
    public void WriteASCII(string value)
    {
        foreach (char letter in value)
            WriteASCII(letter);
    }
    public void WriteASCII(char value)
    {
        Write((byte)value);
    }
}