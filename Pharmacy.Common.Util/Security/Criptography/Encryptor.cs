using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Security.Criptography
{
    public static class Encryptor
    {
        public static string Md5Encrypt(string clearText)
        {
            var inputBytes = Encoding.ASCII.GetBytes(clearText);
            var hash = MD5.HashData(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hash) sb.Append(t.ToString("x2"));
            return sb.ToString();
        }
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        public static string GetEncryptedString(string plainText)
        {
            var Sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] data = Sha1Hasher.ComputeHash(Encoding.Default.GetBytes(plainText));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        public static string Encrypt(string plainText)
        {
            string secretkey = "W@lly@20twenty";
            if (plainText == null)
            {
                return null;
            }

            if (secretkey == null)
            {
                secretkey = string.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var secretkeyBytes = Encoding.UTF8.GetBytes(secretkey);

            // Hash the secretkey with SHA256
            secretkeyBytes = SHA256.Create().ComputeHash(secretkeyBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, secretkeyBytes);

            return WebEncoders.Base64UrlEncode(bytesEncrypted);
            //return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <exception cref="FormatException"></exception>
        public static string Decrypt(string encryptedText)
        {
            string secretkey = "W@lly@20twenty";
            if (encryptedText == null)
            {
                return null;
            }

            if (secretkey == null)
            {
                secretkey = string.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = WebEncoders.Base64UrlDecode(encryptedText);
            var secretkeyBytes = Encoding.UTF8.GetBytes(secretkey);

            secretkeyBytes = SHA256.Create().ComputeHash(secretkeyBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, secretkeyBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] secretkeyBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8
            };

            using (var ms = new MemoryStream())
            using (var AES = new RijndaelManaged())
            {
                var key = new Rfc2898DeriveBytes(secretkeyBytes, saltBytes, 1000);

                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                }

                encryptedBytes = ms.ToArray();
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] secretkeyBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8
            };

            using (var ms = new MemoryStream())
            using (var AES = new RijndaelManaged())
            {
                var key = new Rfc2898DeriveBytes(secretkeyBytes, saltBytes, 1000);

                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                }

                decryptedBytes = ms.ToArray();
            }

            return decryptedBytes;
        }

        public static string EncryptNew(string clearText)
        {
            string _EncryptionKey = "Shayona26202517DocMate";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

    }
}
