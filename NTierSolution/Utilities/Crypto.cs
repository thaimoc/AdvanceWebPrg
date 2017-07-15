using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Utilities
{
    public class Crypto
    {
        private const int TokenSizeInBytes = 16;
        private const int Pbkdf2Count = 1000;
        private const int Pbkdf2SubkeyLength = 256 / 8;
        private const int SaltSize = 128 / 8;
        private const string SECUTIRY_KEY = "kim nguyen hash md5";

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] salt;
            byte[] subkey;
            var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, Pbkdf2Count);
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(Pbkdf2SubkeyLength);
            }

            byte[] outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }


        // hashedPassword must be of the format of HashWithPassword (salt + Hash(salt+input)
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException("hashedPassword");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) password hash.

            if (hashedPasswordBytes.Length != (1 + SaltSize + Pbkdf2SubkeyLength) || hashedPasswordBytes[0] != (byte)0x00)
            {
                // Wrong length or version header.
                return false;
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            byte[] storedSubkey = new byte[Pbkdf2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, Pbkdf2SubkeyLength);

            byte[] generatedSubkey;
            var deriveBytes = new Rfc2898DeriveBytes(password, salt, Pbkdf2Count);
            {
                generatedSubkey = deriveBytes.GetBytes(Pbkdf2SubkeyLength);
            }
            return ByteArraysEqual(storedSubkey, generatedSubkey);
        }

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            bool areSame = true;
            for (int i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }

        #region MD5 String
        public static string MD5Encrypt(string valueString)
        {
            string ret = String.Empty;
            //Khoi tao
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            

            //Lay mang bytes
            byte[] data = System.Text.Encoding.ASCII.GetBytes(valueString);
            //Ma hoa
            data = md5Hasher.ComputeHash(data);
            //Chuyen sang hex
            for (int i = 0; i < data.Length; i++)
            {
                ret += data[i].ToString("x2").ToLower();
            }
            //Tra ve chuoi ket qua
            return ret;
        }

        public static string GetMd5HashString(string input)
        {
            string rs = "";
            using (MD5 md5Hash = MD5.Create())
            {
                rs = GetMd5HashString(md5Hash, input);
            }
            return rs;
        }

        public static bool VerifyMd5HashString(string input, string hash)
        {
            bool rs = false;
            using (MD5 md5Hash = MD5.Create())
            {
                rs = VerifyMd5HashString(md5Hash, input, hash);
            }
            return rs;
        }

        public static string GetMd5HashString(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool VerifyMd5HashString(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5HashString(md5Hash, input);
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        public static string GetMD5Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream oFileStream = GetFileStream(pathName);
            byte[] arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);
            oFileStream.Close();

            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return (strResult);
        } 

        public static string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            oFileStream = GetFileStream(pathName);
            arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
            oFileStream.Close();

            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return (strResult);
        }

        public static string SHA1(string input)
        {
            return Hash(input, "sha1");
        }

        public static string Hash(string input, string algorithm)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }
            return Hash(Encoding.UTF8.GetBytes(input), algorithm);
        }

        public static string Hash(byte[] input, string algorithm)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            using (HashAlgorithm alg = HashAlgorithm.Create(algorithm))
            {
                if (alg != null)
                {
                    byte[] hashData = alg.ComputeHash(input);
                    return BinaryToHex(hashData);
                }
                else
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "not supported hash alg", algorithm));
                }
            }
        }

        internal static string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[iter * 2 + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }
                
        private static System.IO.FileStream GetFileStream(string pathName)
        {
            return (new System.IO.FileStream(pathName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
        }

    }
}
