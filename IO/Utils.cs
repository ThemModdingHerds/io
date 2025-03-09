using System.Numerics;

namespace ThemModdingHerds.IO;
/// <summary>
/// Contains various methods to help some processes
/// </summary>
public static class Utilities
{
    /// <summary>
    /// The count of float values in a <see cref="Matrix4x4"/> 
    /// </summary>
    public const int MATRIX4X4_SIZE = 16;
    /// <summary>
    /// Get the endianness of the current operating system
    /// </summary>
    public static Endianness SystemEndianness => BitConverter.IsLittleEndian ? Endianness.Little : Endianness.Big;
    /// <summary>
    /// Convert <c>input</c> to the endianness <c>target</c>
    /// </summary>
    /// <param name="input">A enumerable byte</param>
    /// <param name="target">Target endianness</param>
    /// <returns></returns>
    public static byte[] ConvertToEndianness(IEnumerable<byte> input,Endianness target)
    {
        return target != SystemEndianness ? [..input.ToArray().Reverse()] : [..input];
    }
    /// <summary>
    /// Convert a <see cref="Matrix4x4"/> in <c>matrix</c> to a <c>float[16]</c> array
    /// </summary>
    /// <param name="matrix">A <see cref="Matrix4x4"/></param>
    /// <returns>a float array with exactly 16 elements</returns>
    public static float[] ConvertMatrix4x4(Matrix4x4 matrix)
    {
        return [
            matrix.M11,matrix.M12,matrix.M13,matrix.M14,
            matrix.M21,matrix.M22,matrix.M23,matrix.M24,
            matrix.M31,matrix.M32,matrix.M33,matrix.M34,
            matrix.M41,matrix.M42,matrix.M43,matrix.M44
        ];
    }
    /// <summary>
    /// Converts a <c>float[16]</c> to a <see cref="Matrix4x4"/>
    /// </summary>
    /// <param name="floats">A valid float array with 16 elements</param>
    /// <returns>A <see cref="Matrix4x4"/></returns>
    /// <exception cref="ArgumentException">The float array has no 16 elements</exception>
    public static Matrix4x4 ConvertMatrix4x4(float[] floats)
    {
        if(floats.Length != MATRIX4X4_SIZE)
            throw new ArgumentException($"expected float array size of {MATRIX4X4_SIZE}, got {floats.Length} instead");
        return new(
            floats[0],floats[1],floats[2],floats[3],
            floats[4],floats[5],floats[6],floats[7],
            floats[8],floats[9],floats[10],floats[11],
            floats[12],floats[13],floats[14],floats[15]
        );
    }
}