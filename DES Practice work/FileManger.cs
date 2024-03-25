using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DES_Practice_work;

namespace DES_Practice_work
{
    public class FileManager
    {
        private static string Path = "C:\\Users\\Administrator\\source\\repos\\DES Practice work\\DES Practice work\\DESFile.txt";

        public async void WriteInFile(string Text)
        {
            File.WriteAllText(Path, Text);
        }

        public string ReadFromFile()
        {
            return File.ReadAllText(Path);
        }
    }
}
