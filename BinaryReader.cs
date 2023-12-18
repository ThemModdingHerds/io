using System.Buffers.Binary;

namespace ThemModdingHerds.IO;
public class BinaryReader(System.IO.BinaryReader reader) : IReader
{
    private readonly System.IO.BinaryReader _reader = reader;
    private Endianness _endianness = Utils.SystemEndianness;
    public BinaryReader(Stream stream) : this(new System.IO.BinaryReader(stream))
    {
        
    }
    public BinaryReader(string path) : this(File.OpenRead(path))
    {

    }
    public Endianness Endianness { get => _endianness; set => _endianness = value; }
    public long Offset { get => _reader.BaseStream.Position; set => _reader.BaseStream.Position = value; }
    private byte[] Read(int size)
    {
        return _reader.ReadBytes(size);
    }
    public byte ReadByte()
    {
        return _reader.ReadByte();
    }
    public double ReadDouble()
    {
        byte[] array = Read(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadDoubleBigEndian(array) : BinaryPrimitives.ReadDoubleLittleEndian(array);
    }
    public float ReadFloat()
    {
        byte[] array = Read(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadSingleBigEndian(array) : BinaryPrimitives.ReadSingleLittleEndian(array);
    }
    public int ReadInt()
    {
        byte[] array = Read(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt32BigEndian(array) : BinaryPrimitives.ReadInt32LittleEndian(array);
    }
    public long ReadLong()
    {
        byte[] array = Read(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt64BigEndian(array) : BinaryPrimitives.ReadInt64LittleEndian(array);
    }
    public sbyte ReadSByte()
    {
        return _reader.ReadSByte();
    }
    public short ReadShort()
    {
        byte[] array = Read(2);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadInt16BigEndian(array) : BinaryPrimitives.ReadInt16LittleEndian(array);
    }
    public uint ReadUInt()
    {
        byte[] array = Read(4);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt32BigEndian(array) : BinaryPrimitives.ReadUInt32LittleEndian(array);
    }
    public ulong ReadULong()
    {
        byte[] array = Read(8);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt64BigEndian(array) : BinaryPrimitives.ReadUInt64LittleEndian(array);
    }
    public ushort ReadUShort()
    {
        byte[] array = Read(2);
        return Endianness == Endianness.Big ? BinaryPrimitives.ReadUInt16BigEndian(array) : BinaryPrimitives.ReadUInt16LittleEndian(array);
    }
}