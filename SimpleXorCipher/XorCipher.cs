using System.IO;

namespace SimpleXorCipher
{
    static class XorCipher
    {
        public static void Encrypt(Stream inStream, Stream outStream, string key)
        {
            outStream.SetLength(0);
            while (inStream.Position < inStream.Length) outStream.WriteByte((byte)(inStream.ReadByte() ^ key[(int)inStream.Position % key.Length]));
        }

        public static void Encrypt(Stream inStream, Stream outStream, long key)
        {
            outStream.SetLength(0);
            while (inStream.Position < inStream.Length) outStream.WriteByte((byte)(inStream.ReadByte() ^ key));
        }
    }
}
