using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Utilities
{
    public static class SymmetricEncryptionUtility
    {
        private static bool _ProteckKey;
        
        private static string _AlgorithmName;
        
        private const string MyKey = "m$%&kljasldk$%/65asjdl";

        public static string AlgorithmName
        {
            get { return SymmetricEncryptionUtility._AlgorithmName; }
            set { SymmetricEncryptionUtility._AlgorithmName = value; }
        }

        public static bool ProteckKey
        {
            get { return SymmetricEncryptionUtility._ProteckKey; }
            set { SymmetricEncryptionUtility._ProteckKey = value; }
        }

        public static void GenerateKey(string targetFile)
        {
            //Create the algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.GenerateKey();

            //No get the key
            byte[] Key = Algorithm.Key;

            if (ProteckKey)
            {
                //Use DPAPI to encrypt key
                Key = ProtectedData.Protect(Key, null, DataProtectionScope.LocalMachine);
            }

            //Store the key in a file called key.conig
            using (FileStream fs = new FileStream(targetFile, FileMode.Create))
            {
                fs.Write(Key, 0, Key.Length);
            }
        }

        public static void ReadKey(SymmetricAlgorithm algorithm, string keyFile)
        {
            byte[] Key;
            using (FileStream fs = new FileStream(keyFile, FileMode.Open))
            {
                Key = new byte[fs.Length];
                fs.Read(Key, 0, (int)fs.Length);
            }

            if (ProteckKey)
            {
                algorithm.Key = ProtectedData.Unprotect(Key, null, DataProtectionScope.LocalMachine);
            }
            else
            {
                algorithm.Key = Key;
            }
        }

        public static byte[] EncryptData(string data, string keyFile)
        {
            // Convert string data to byte array
            byte[] ClearData = Encoding.UTF8.GetBytes(data);

            //Now Create the aogorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            ReadKey(Algorithm, keyFile);

            //Encrypt information
            MemoryStream Target = new MemoryStream();

            //Append IV
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            //Encrypt actual data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData, 0, ClearData.Length);
            cs.FlushFinalBlock();

            //Output the bytes of the encrypted array to the textbox
            return Target.ToArray();
        }

        public static string DecryptData(byte[] data, string keyFile)
        {
            // Now create the algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            ReadKey(Algorithm, keyFile);

            // Decrypt information
            MemoryStream Target = new MemoryStream();

            // Read IV
            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(data, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(data, ReadPos, data.Length - ReadPos);
            cs.FlushFinalBlock();

            // Get the bytes from the memory stream and convert them to text
            return Encoding.UTF8.GetString(Target.ToArray());
        }
    }
}
