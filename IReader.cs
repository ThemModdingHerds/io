namespace ThemModdingHerds.IO;
public interface IReader : IStream
{
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
    public string ReadPascal64String();
}