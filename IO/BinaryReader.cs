using System.Buffers.Binary;
using System.Drawing;
using System.Numerics;

namespace ThemModdingHerds.IO.Binary;
public class Reader(BinaryReader reader) : IReader
{
    private long lastOffset = 0;
    public BinaryReader BaseReader {get;} = reader;
    public Reader(Stream stream) : this(new BinaryReader(stream))
    {

    }
    public Reader(string path) : this(File.OpenRead(path))
    {

    }
    public Reader(Span<byte> bytes): this(bytes.ToArray())
    {

    }
    public Reader(byte[] bytes): this(new MemoryStream(bytes))
    {

    }
    public Endianness Endianness { get; set; } = Utils.SystemEndianness;
    public long Offset { get => BaseReader.BaseStream.Position; set => BaseReader.BaseStream.Position = value; }
    public int OffsetInt {get => (int)Offset; set => Offset = value;}
    public long Length {get => BaseReader.BaseStream.Length;}
    public int LengthInt {get => (int)Length;}
    public byte[] ReadBytes(int size,bool withEndian = false)
    {
        byte[] data = BaseReader.ReadBytes(size);
        return withEndian ? Utils.ConvertToEndianness(data,Endianness) : data;
    }
    public void ReadBytes(Span<byte> bytes,bool withEndian = false)
    {
        byte[] data = BaseReader.ReadBytes(bytes.Length);
        for(int i = 0;i < bytes.Length;i++)
            bytes[i] = data[i];
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
    public string ReadPascal8String()
    {
        byte length = ReadByte();
        return ReadASCII(length);
    }
    public List<string> ReadPascal8Strings(ulong count) => ReadList((r) => r.ReadPascal8String(),count);
    public string ReadPascal16String()
    {
        ushort length = ReadUShort();
        return ReadASCII(length);
    }
    public List<string> ReadPascal16Strings(ulong count) => ReadList((r) => r.ReadPascal16String(),count);
    public string ReadPascal32String()
    {
        uint length = ReadUInt();
        return ReadASCII(length);
    }
    public List<string> ReadPascal32Strings(ulong count) => ReadList((r) => r.ReadPascal32String(),count);
    public string ReadPascal64String()
    {
        ulong length = ReadULong();
        return ReadASCII(length);
    }
    public List<string> ReadPascal64Strings(ulong count) => ReadList((r) => r.ReadPascal64String(),count);
    public List<T> ReadList<T>(Func<IReader,T> cb,ulong count)
    {
        List<T> items = [];
        for(ulong i = 0;i < count;i++)
            items.Add(cb(this));
        return items;
    }
    public T[] ReadArray<T>(Func<IReader,T> cb,ulong count)
    {
        T[] items = new T[count];
        for(ulong i = 0;i < count;i++)
            items[i] = cb(this);
        return items;
    }
    public Matrix4x4 ReadMatrix4x4()
    {
        const ulong MATRIX4X4_SIZE = 16;
        float[] floats = new float[MATRIX4X4_SIZE];
        for(ulong i = 0;i < MATRIX4X4_SIZE;i++)
            floats[i] = ReadFloat();
        return Utils.ConvertMatrix4x4(floats);
    }
    public List<Matrix4x4> ReadMatrices4x4(ulong count) => ReadList((r) => r.ReadMatrix4x4(),count);
    public Vector2 ReadVector2()
    {
        return new(ReadFloat(),ReadFloat());
    }
    public List<Vector2> ReadVectors2(ulong count) => ReadList((r) => r.ReadVector2(),count);
    public Vector3 ReadVector3()
    {
        return new(ReadFloat(),ReadFloat(),ReadFloat());
    }
    public List<Vector3> ReadVectors3(ulong count) => ReadList((r) => r.ReadVector3(),count);
    public string ReadASCII(ulong length)
    {
        string str = string.Empty;
        for(ulong i = 0;i < length;i++)
            str += ReadASCIIChar();
        return str;
    }
    public char ReadASCIIChar()
    {
        return (char)ReadByte();
    }
    public Color ReadRGBA()
    {
        byte[] bytes = ReadBytes(4,true);
        return Color.FromArgb(bytes[3],bytes[0],bytes[1],bytes[2]);
    }
    public Color ReadARGB()
    {
        byte[] bytes = ReadBytes(4,true);
        return Color.FromArgb(bytes[0],bytes[1],bytes[2],bytes[3]);
    }
    public Color ReadBGRA()
    {
        byte[] bytes = ReadBytes(4,true);
        return Color.FromArgb(bytes[3],bytes[2],bytes[1],bytes[0]);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Close();
    }
    public void Close()
    {
        BaseReader.BaseStream.Close();
    }
    public void Begin()
    {
        lastOffset = Offset;
    }
    public long End()
    {
        return Offset - lastOffset;
    }
}