using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;

namespace WebEzi.Util
{
    /// <summary>
    /// DES Encrypt
    /// </summary>
    public class EncryptDESHelper
    {
        /// <summary>
        /// account key
        /// </summary>
        public const string Key_Account = "Ezi@K#10";
        /// <summary>
        /// beat key
        /// </summary>
        public const string Key_Beat = "Ezi@K#20";
        /// <summary>
        /// query string key
        /// </summary>
        public const string Key_Querystr = "Ezi@K#30";
        /// <summary>
        /// json key
        /// </summary>
        public const string Key_Json = "Ezi@K#40";
        /// <summary>
        /// common key
        /// </summary>
        public const string Key_Common = "Ezi@K#50";
        /// <summary>
        /// service key
        /// </summary>
        public const string Key_Service = "Ezi@S#00";       
        /// <summary>
        /// keys
        /// </summary>
        private static string _key = "WebEzi6#";


        /// <summary>
        /// Keys
        /// </summary>
        public static string Key
        {
            get
            {
                return _key;
            }
            internal set
            {
                _key = value;
            }
        }


        //To be determined:'Encoding','CultureInfo' etc. 
        //private const string _encoding = "";
        //private const string _cultureInfoName = "";


        /// <summary>
        /// DES Encode
        /// </summary>
        /// <param name="str">Plaintext</param>
        /// <returns>Ciphertext</returns>
        public static string Encode(string str)
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            CultureInfo ci = new CultureInfo("en-AU", true);//
            return Encode(str, _key, _key, encoding, ci);
        }

        /// <summary>
        /// DES Decode
        /// </summary>
        /// <param name="str">Ciphertext</param>
        /// <returns>Plaintext</returns>
        public static string Decode(string str)
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            return Decode(str, _key, _key, encoding);
        }


        /// <summary>
        /// DES加密 use key
        /// </summary>
        /// <param name="str">Plaintext</param>
        /// <param name="key">Keys</param>
        /// <returns>Ciphertext</returns>
        public static string Encode(string str, string key)
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            CultureInfo ci = new CultureInfo("zh-CN", true);
            return Encode(str, key, key, encoding, ci);
        }
        /// <summary>
        /// DES Decode use key
        /// </summary>
        /// <param name="str">Ciphertext</param>
        /// <param name="key">Keys</param>
        /// <returns>Plaintext</returns>
        public static string Decode(string str, string key)
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            return Decode(str, key, key, encoding);
        }

        /// <summary>
        /// DES EncodeIV use key and use default initialization vector
        /// </summary>
        /// <param name="str">Plaintext</param>
        /// <param name="key">Keys</param>
        /// <returns>Ciphertext</returns>
        public static string EncodeIV(string str, string key)
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            CultureInfo ci = new CultureInfo("zh-CN", true);
            return Encode(str, key, _key, encoding, ci);
        }

        /// <summary>
        /// DES DecodeIV  use key and use default initialization vector
        /// </summary>
        /// <param name="str">Ciphertext</param>
        /// <param name="key">Keys</param>
        /// <returns>Plaintext</returns>
        public static string DecodeIV(string str, string key)
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            return Decode(str, key, _key, encoding);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="encoding"></param>
        /// <param name="ci"></param>
        /// <returns></returns>
        private static string Encode(string str, string key, string iv,Encoding encoding,CultureInfo ci)
        {
            try
            {
                //key iv length check 
                #region Encode start
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(iv.Substring(0, 8));
                byte[] bytes = encoding.GetBytes(str);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat(ci, "{0:X2}", num);
                }
                stream.Close();
                #endregion Encode end
                return builder.ToString();
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string Decode(string str, string key, string iv, Encoding encoding)
        {
            try
            {
                //key iv length check 
                #region Decode start
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(Key.Substring(0, 8));
                byte[] buffer = new byte[str.Length / 2];
                for (int i = 0; i < (str.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num2;
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Close();
                byte[] by = stream.ToArray();
                #endregion Decode end
                return encoding.GetString(by, 0, by.Length);
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
