namespace ThemModdingHerds.IO;
public static class Utils
{
    public static Endianness SystemEndianness {get => BitConverter.IsLittleEndian ? Endianness.Little : Endianness.Big;}
    public static byte[] ConvertToEndianness(byte[] input,Endianness target)
    {
        return target != SystemEndianness ? input.Reverse().ToArray() : input;
    }
}