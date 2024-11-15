using System.Drawing;
using System.Numerics;

namespace ThemModdingHerds.IO;
public interface IReader : IStream
{
    public byte[] ReadBytes(int size,bool withEndian = false);
    public void ReadBytes(Span<byte> bytes,bool withEndian = false);
    public byte ReadByte();
    public sbyte ReadSByte();
    public short ReadShort();
    public ushort ReadUShort();
    public int ReadInt();
    public uint ReadUInt();
    public long ReadLong();
    public ulong ReadULong();
    public float ReadFloat();
    public double ReadDouble();
    public List<T> ReadList<T>(Func<IReader,T> cb,ulong count);
    public T[] ReadArray<T>(Func<IReader,T> cb,ulong count);
    public string ReadASCII(ulong length);
    public string ReadPascal8String();
    public List<string> ReadPascal8Strings(ulong count);
    public string ReadPascal16String();
    public List<string> ReadPascal16Strings(ulong count);
    public string ReadPascal32String();
    public List<string> ReadPascal32Strings(ulong count);
    public string ReadPascal64String();
    public List<string> ReadPascal64Strings(ulong count);
    public char ReadASCIIChar();
    public Matrix4x4 ReadMatrix4x4();
    public List<Matrix4x4> ReadMatrices4x4(ulong count);
    public Vector2 ReadVector2();
    public List<Vector2> ReadVectors2(ulong count);
    public Vector3 ReadVector3();
    public List<Vector3> ReadVectors3(ulong count);
    public Color ReadRGBA();
    public Color ReadARGB();
    public Color ReadBGRA();
}