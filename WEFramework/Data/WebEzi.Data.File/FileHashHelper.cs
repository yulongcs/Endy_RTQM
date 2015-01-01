using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Security.Cryptography;
namespace WebEzi.Data.File
{
    /// <summary>
    /// Partially taken from the Internet of algorithms we should not consider the impact of large files (MemoryStream，Block)
    /// </summary>
    public sealed class  FileHashHelper
    {
        private const int bufferSize = 10240;
        /// <summary>
        /// Converts a byte array as string of hexadecimal 
        /// </summary>
        public static string ByteArrayToHexString(byte[] buf)
        {
            int iLen = 0;
            Type type = typeof(System.Web.Configuration.MachineKeySection);
            MethodInfo byteArrayToHexString = type.GetMethod("ByteArrayToHexString", BindingFlags.Static | BindingFlags.NonPublic);
            return (string)byteArrayToHexString.Invoke(null, new object[] { buf, iLen });
        }

        /// <summary>
        /// Compute File MD5
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static String ComputeMD5(String fileFullName)
        {
            //msdn HashAlgorithm.ComputeHash
            if (System.IO.File.Exists(fileFullName))
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(fileFullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    MD5 calculator = MD5.Create();
                    Byte[] buffer = calculator.ComputeHash(fileStream);
                    calculator.Clear();

                    return ByteArrayToHexString(buffer);
                }
            }
            return String.Empty;
        }
        /// <summary>
        /// Compute File SHA1
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static String ComputeSHA1(String fileFullName)
        {
            return "SHA1";
            /*
            if (System.IO.File.Exists(fileFullName))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(fileFullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    SHA1 calculator = SHA1.Create();
                    Byte[] buffer = calculator.ComputeHash(fs);
                    calculator.Clear();
                    return ByteArrayToHexString(buffer);
                }
            }
            return String.Empty;*/
        }
        /// <summary>
        /// Compute File CRC32
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static String ComputeCRC32(String fileFullName)
        {
            return "CRC32";
            /*
            if (System.IO.File.Exists(fileFullName))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(fileFullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    Crc32 calculator = new Crc32();
                    Byte[] buffer = calculator.ComputeHash(fs);
                    calculator.Clear();
                    return ByteArrayToHexString(buffer);
                }
            }
            return String.Empty;*/
        }
        /// <summary>
        /// CRC32 algorithm
        /// </summary>
        public class Crc32 : HashAlgorithm
        {
            public const UInt32 DefaultPolynomial = 0xedb88320;
            public const UInt32 DefaultSeed = 0xffffffff;
            private UInt32 hash;
            private UInt32 seed;
            private UInt32[] table;
            private static UInt32[] defaultTable;
            public Crc32()
            {
                table = InitializeTable(DefaultPolynomial);
                seed = DefaultSeed;
                Initialize();
            }
            public Crc32(UInt32 polynomial, UInt32 seed)
            {
                table = InitializeTable(polynomial);
                this.seed = seed;
                Initialize();
            }
            public override void Initialize()
            {
                hash = seed;
            }
            protected override void HashCore(byte[] buffer, int start, int length)
            {
                hash = CalculateHash(table, hash, buffer, start, length);
            }
            protected override byte[] HashFinal()
            {
                byte[] hashBuffer = UInt32ToBigEndianBytes(~hash);
                this.HashValue = hashBuffer;
                return hashBuffer;
            }
            public static UInt32 Compute(byte[] buffer)
            {
                return ~CalculateHash(InitializeTable(DefaultPolynomial), DefaultSeed, buffer, 0, buffer.Length);
            }
            public static UInt32 Compute(UInt32 seed, byte[] buffer)
            {
                return ~CalculateHash(InitializeTable(DefaultPolynomial), seed, buffer, 0, buffer.Length);
            }
            public static UInt32 Compute(UInt32 polynomial, UInt32 seed, byte[] buffer)
            {
                return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
            }
            private static UInt32[] InitializeTable(UInt32 polynomial)
            {
                if (polynomial == DefaultPolynomial && defaultTable != null)
                {
                    return defaultTable;
                }
                UInt32[] createTable = new UInt32[256];
                for (int i = 0; i < 256; i++)
                {
                    UInt32 entry = (UInt32)i;
                    for (int j = 0; j < 8; j++)
                    {
                        if ((entry & 1) == 1)
                            entry = (entry >> 1) ^ polynomial;
                        else
                            entry = entry >> 1;
                    }
                    createTable[i] = entry;
                }
                if (polynomial == DefaultPolynomial)
                {
                    defaultTable = createTable;
                }
                return createTable;
            }
            private static UInt32 CalculateHash(UInt32[] table, UInt32 seed, byte[] buffer, int start, int size)
            {
                UInt32 crc = seed;
                for (int i = start; i < size; i++)
                {
                    unchecked
                    {
                        crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
                    }
                }
                return crc;
            }
            private byte[] UInt32ToBigEndianBytes(UInt32 x)
            {
                return new byte[] { (byte)((x >> 24) & 0xff), (byte)((x >> 16) & 0xff), (byte)((x >> 8) & 0xff), (byte)(x & 0xff) };
            }
        }//end class: Crc32

    }
}
