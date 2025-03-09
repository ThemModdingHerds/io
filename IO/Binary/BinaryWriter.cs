using System.Drawing;
using System.Numerics;

namespace ThemModdingHerds.IO.Binary;
public class Writer(BinaryWriter writer) : IWriter
{
    private long lastOffset = 0;
    private BinaryWriter BaseWriter => writer;
    public Writer(Stream stream) : this(new BinaryWriter(stream))
    {

    }
    public Writer(string path) : this(File.OpenWrite(path))
    {

    }
    public Writer(byte[] bytes): this(new MemoryStream(bytes))
    {

    }
    public Writer(Span<byte> bytes): this(bytes.ToArray())
    {

    }
    public Endianness Endianness {get;set;} = Utilities.SystemEndianness;
    public long Offset {get => BaseWriter.BaseStream.Position;set => BaseWriter.BaseStream.Position = value;}
    public int OffsetInt {get => (int)Offset;set => Offset = value;}
    public long Length => BaseWriter.BaseStream.Length;
    public int LengthInt => (int)Length;
    public void Write(byte[] value, bool withEndian = false)
    {
        BaseWriter.Write(withEndian ? Utilities.ConvertToEndianness(value,Endianness) : value);
    }
    public void Write(Span<byte> bytes,bool withEndian = false)
    {
        Write(bytes.ToArray(),withEndian);
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
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ushort value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(int value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(uint value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(long value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(ulong value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(float value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write(double value)
    {
        BaseWriter.Write(Utilities.ConvertToEndianness(BitConverter.GetBytes(value),Endianness));
    }
    public void Write<T>(IEnumerable<T> items,Action<IWriter,T> cb)
    {
        foreach(T item in items)
            cb(this,item);
    }
    public void WritePascal8String(string value)
    {
        Write((byte)value.Length);
        WriteASCII(value);
    }
    public void WritePascal8Strings(IEnumerable<string> strings) => Write(strings,(w,s) => w.WritePascal8String(s));
    public void WritePascal16String(string value)
    {
        Write((ushort)value.Length);
        WriteASCII(value);
    }
    public void WritePascal16Strings(IEnumerable<string> strings) => Write(strings,(w,s) => w.WritePascal16String(s));
    public void WritePascal32String(string value)
    {
        Write((uint)value.Length);
        WriteASCII(value);
    }
    public void WritePascal32Strings(IEnumerable<string> strings) => Write(strings,(w,s) => w.WritePascal32String(s));
    public void WritePascal64String(string value)
    {
        Write((ulong)value.Length);
        WriteASCII(value);
    }
    public void WritePascal64Strings(IEnumerable<string> strings) => Write(strings,(w,s) => w.WritePascal64String(s));
    public void WriteMatrix4x4(Matrix4x4 matrix)
    {
        Write(matrix.M11);
        Write(matrix.M12);
        Write(matrix.M13);
        Write(matrix.M14);
        Write(matrix.M21);
        Write(matrix.M22);
        Write(matrix.M23);
        Write(matrix.M24);
        Write(matrix.M31);
        Write(matrix.M32);
        Write(matrix.M33);
        Write(matrix.M34);
        Write(matrix.M41);
        Write(matrix.M42);
        Write(matrix.M43);
        Write(matrix.M44);
    }
    public void WriteMatrices4x4(IEnumerable<Matrix4x4> matrices) => Write(matrices,(w,m) => w.WriteMatrix4x4(m));
    public void WriteVector2(Vector2 vector) => WriteVector2(vector.X,vector.Y);
    public void WriteVector2(float x,float y)
    {
        Write(x);
        Write(y);
    }
    public void WriteVectors2(IEnumerable<Vector2> vectors) => Write(vectors,(w,v) => w.WriteVector2(v));
    public void WriteVector3(Vector3 vector) => WriteVector3(vector.X,vector.Y,vector.Z);
    public void WriteVector3(float x,float y,float z)
    {
        Write(x);
        Write(y);
        Write(z);
    }
    public void WriteVectors3(IEnumerable<Vector3> vectors) => Write(vectors,(w,v) => w.WriteVector3(v));
    public void WriteVector4(Vector4 vector) => WriteVector4(vector.X,vector.Y,vector.Z,vector.W);
    public void WriteVector4(float x,float y,float z,float w)
    {
        Write(x);
        Write(y);
        Write(z);
        Write(w);
    }
    public void WriteVectors4(IEnumerable<Vector4> vectors) => Write(vectors,(w,v) => w.WriteVector4(v));
    public void WriteASCII(string value)
    {
        foreach (char letter in value)
            WriteASCII(letter);
    }
    public void WriteASCII(char value)
    {
        Write((byte)value);
    }
    public void WriteRGBA(Color color)
    {
        Write(color.R);
        Write(color.G);
        Write(color.B);
        Write(color.A);
    }
    public void WriteARGB(Color color)
    {
        Write(color.A);
        Write(color.R);
        Write(color.G);
        Write(color.B);
    }
    public void WriteBGRA(Color color)
    {
        Write(color.B);
        Write(color.G);
        Write(color.R);
        Write(color.A);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Close();
    }
    public void Close()
    {
        BaseWriter.BaseStream.Close();
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