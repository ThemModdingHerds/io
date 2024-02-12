using System.Buffers.Binary;

namespace ThemModdingHerds.IO.Binary;
public class Reader(BinaryReader reader) : IReader
{
    public BinaryReader BaseReader {get;} = reader;
    public Reader(Stream stream) : this(new BinaryReader(stream))
    {

    }
    public Reader(string path) : this(File.OpenRead(path))
    {

    }
    public Endianness Endianness { get; set; } = Utils.SystemEndianness;
    public long Offset { get => BaseReader.BaseStream.Position; set => BaseReader.BaseStream.Position = value; }
    public byte[] ReadBytes(int size,bool withEndian = false)
    {
        byte[] data = BaseReader.ReadBytes(size);
        return withEndian ? Utils.ConvertToEndianness(data,Endianness) : data;
    }
    public byte ReadByte()
    {
        return BaseReader.ReadByte();
    }
    public double ReadDouble()
    {
        byte[] array = ReadBytes(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadDoubleBigEndian(array) : BinaryPrimitives.ReadDoubleLittleEndian(array);
    }
    public float ReadFloat()
    {
        byte[] array = ReadBytes(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadSingleBigEndian(array) : BinaryPrimitives.ReadSingleLittleEndian(array);
    }
    public int ReadInt()
    {
        byte[] array = ReadBytes(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt32BigEndian(array) : BinaryPrimitives.ReadInt32LittleEndian(array);
    }
    public long ReadLong()
    {
        byte[] array = ReadBytes(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt64BigEndian(array) : BinaryPrimitives.ReadInt64LittleEndian(array);
    }
    public sbyte ReadSByte()
    {
        return BaseReader.ReadSByte();
    }
    public short ReadShort()
    {
        byte[] array = ReadBytes(2);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt16BigEndian(array) : BinaryPrimitives.ReadInt16LittleEndian(array);
    }
    public uint ReadUInt()
    {
        byte[] array = ReadBytes(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt32BigEndian(array) : BinaryPrimitives.ReadUInt32LittleEndian(array);
    }
    public ulong ReadULong()
    {
        byte[] array = ReadBytes(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt64BigEndian(array) : BinaryPrimitives.ReadUInt64LittleEndian(array);
    }
    public ushort ReadUShort()
    {
        byte[] array = ReadBytes(2);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt16BigEndian(array) : BinaryPrimitives.ReadUInt16LittleEndian(array);
    }
    public string ReadPascal64String()
    {
        ulong length = ReadULong();
        return ReadASCII(length);
    }
    public string ReadASCII(ulong length)
    {
        List<char> chars = [];
        for(ulong i = 0;i < length;i++)
            chars.Add(ReadASCIIChar());
        return new string(chars.ToArray());
    }
    public char ReadASCIIChar()
    {
        return (char)ReadByte();
    }
}