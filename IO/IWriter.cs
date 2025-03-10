using System.Drawing;
using System.Numerics;

namespace ThemModdingHerds.IO;
public interface IWriter : IStream
{
    public void Write(Span<byte> values,bool withEndian = false);
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
    public void Write<T>(IEnumerable<T> items,Action<IWriter,T> cb);
    public void WriteASCII(string value);
    public void WriteASCII(char value);
    public void WritePascal8String(string value);
    public void WritePascal8Strings(IEnumerable<string> strings);
    public void WritePascal16String(string value);
    public void WritePascal16Strings(IEnumerable<string> strings);
    public void WritePascal32String(string value);
    public void WritePascal32Strings(IEnumerable<string> strings);
    public void WritePascal64String(string value);
    public void WritePascal64Strings(IEnumerable<string> strings);
    public void WriteMatrix4x4(Matrix4x4 matrix);
    public void WriteMatrices4x4(IEnumerable<Matrix4x4> matrices);
    public void WriteVector2(Vector2 vector);
    public void WriteVector2(float x,float y);
    public void WriteVectors2(IEnumerable<Vector2> vectors);
    public void WriteVector3(Vector3 vector);
    public void WriteVector3(float x,float y,float z);
    public void WriteVectors3(IEnumerable<Vector3> vectors);
    public void WriteVector4(Vector4 vector);
    public void WriteVector4(float x,float y,float z,float w);
    public void WriteVectors4(IEnumerable<Vector4> vectors);
    public void WriteRGBA(Color color);
    public void WriteARGB(Color color);
    public void WriteBGRA(Color color);
}