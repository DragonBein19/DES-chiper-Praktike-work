using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DES_Practice_work;

namespace DES_Practice_work
{
    public class KeyGeneratorManager
    {
        private static readonly char[] AvailableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public string GenerationKey()
        {
            int KeyLength = 8;
            return (GenerateRandomKey(KeyLength));
        }

        private string GenerateRandomKey(int KeyLength)
        {
            Random random = new Random();
            char[] KeyBuffer = new char[KeyLength];

            for (int i = 0; i < KeyLength; i++)
            {
                KeyBuffer[i] = AvailableCharacters[random.Next(AvailableCharacters.Length)];
            }

            return new string(KeyBuffer);
        }
    }
}
