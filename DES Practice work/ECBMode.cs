using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DES_Practice_work
{
    public class ECBMode
    {
        private static FileManager rwText = new FileManager();
        
        public void ECBMain(string Choise, string OriginalText, string Key)
        {
            byte[] key = Encoding.UTF8.GetBytes(Key);

            using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
            {
                desAlg.Key = key;
                desAlg.Mode = CipherMode.ECB;

                switch (Choise)
                {
                    case "1":
                        OriginalText = ECBencrypting(OriginalText, desAlg);
                        rwText.WriteInFile(OriginalText);
                        Console.WriteLine(OriginalText);

                        OriginalText = ECBdecryptString(Encoding.UTF8.GetBytes(OriginalText), desAlg);
                        rwText.WriteInFile(OriginalText);
                        Console.WriteLine(OriginalText);
                        break;

                    case "2":
                        OriginalText = ECBencrypting(OriginalText, desAlg);
                        rwText.WriteInFile(OriginalText);
                        Console.WriteLine(OriginalText);
                        break;

                    case "3":
                        OriginalText = ECBdecryptString(Encoding.UTF8.GetBytes(OriginalText), desAlg);
                        rwText.WriteInFile(OriginalText);
                        Console.WriteLine(OriginalText);
                        break;
                }
            }
        }

        private string ECBencrypting(string OriginalText, DESCryptoServiceProvider desAlg)
        {
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, desAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(OriginalText);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }

        private string ECBdecryptString(byte[] OriginalText, DESCryptoServiceProvider desAlg)
        {
            using (MemoryStream msDecrypt = new MemoryStream(OriginalText))
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
    }
}
