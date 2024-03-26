using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DES_Practice_work
{
    public class TextCoding
    {
        private static FileManager rwText = new FileManager();
        private static byte[] encryptedMessage;
        private static string decryptedMessage;


        public void ECBMain(string Choise, string OriginalText, string Key, string Mode)
        {
            using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
            {

                byte[] key = Encoding.UTF8.GetBytes(Key);
                byte[] iv = Encoding.UTF8.GetBytes(Key);

                desAlg.Key = key;

                switch(Mode)
                {
                    case "ECB":
                        desAlg.Mode = CipherMode.ECB;
                        break;
                    case "CBC":
                        desAlg.IV = iv;
                        desAlg.Mode = CipherMode.CBC;
                        break;
                    case "CFB":
                        desAlg.Mode = CipherMode.CFB;
                        break;
                }    

                desAlg.Mode = CipherMode.CBC;

                string originalMessage = OriginalText;

                switch (Choise)
                {
                    case "1":
                        encryptedMessage = EncryptStringToBytes(originalMessage, desAlg);
                        decryptedMessage = DecryptStringFromBytes(encryptedMessage, desAlg);
                        Console.WriteLine("\nOriginal Message: " + originalMessage);
                        Console.WriteLine("\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));
                        Console.WriteLine("\nDecrypted Message: " + decryptedMessage);
                        break;

                    case "2":
                        encryptedMessage = EncryptStringToBytes(originalMessage, desAlg);
                        rwText.WriteInFile(Convert.ToBase64String(encryptedMessage));
                        Console.WriteLine("\nOriginal Message: " + originalMessage);
                        Console.WriteLine("\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));
                        break;

                    case "3":
                        decryptedMessage = DecryptStringFromBytes(encryptedMessage, desAlg);
                        rwText.WriteInFile(decryptedMessage);
                        if (encryptedMessage != null)
                        {
                            Console.WriteLine("\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));
                            Console.WriteLine("\nDecrypted Message: " + decryptedMessage);
                        }
                        break;
                }
            }
        }

        static byte[] EncryptStringToBytes(string plainText, DESCryptoServiceProvider desAlg)
        {       
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, desAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return msEncrypt.ToArray();
            }
            
        }

        static string DecryptStringFromBytes(byte[] cipherText, DESCryptoServiceProvider desAlg)
        {
            try
            {
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, desAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("\nThe file text is not encoded.");
                return(null);
            }         
        }
    }
}
