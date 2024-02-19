using System.Numerics;

namespace ThemModdingHerds.IO;
public static class Utils
{
    public const int MATRIX4X4_SIZE = 16;
    public static Endianness SystemEndianness {get => BitConverter.IsLittleEndian ? Endianness.Little : Endianness.Big;}
    public static byte[] ConvertToEndianness(IEnumerable<byte> input,Endianness target)
    {
        return target != SystemEndianness ? input.ToArray().Reverse().ToArray() : input.ToArray();
    }
    public static float[] ConvertMatrix4x4(Matrix4x4 matrix)
    {
        return [
            matrix.M11,matrix.M12,matrix.M13,matrix.M14,
            matrix.M21,matrix.M22,matrix.M23,matrix.M24,
            matrix.M31,matrix.M32,matrix.M33,matrix.M34,
            matrix.M41,matrix.M42,matrix.M43,matrix.M44
        ];
    }
    public static Matrix4x4 ConvertMatrix4x4(float[] floats)
    {
        if(floats.Length != MATRIX4X4_SIZE)
            throw new Exception($"expected float array size of {MATRIX4X4_SIZE}, got {floats.Length}");
        return new(
            floats[0],floats[1],floats[2],floats[3],
            floats[4],floats[5],floats[6],floats[7],
            floats[8],floats[9],floats[10],floats[11],
            floats[12],floats[13],floats[14],floats[15]
        );
    }
}