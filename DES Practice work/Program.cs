using DES_Practice_work;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    private static FileManager rwFile = new FileManager();
    private static KeyGeneratorManager Key = new KeyGeneratorManager();
    private static TextCoding wText = new TextCoding();

    private static string Choise, OriginalText;
    private static string CurrentlyKey = "12345678";
    private static bool Cicle = true;

    private static void Main(string[] args)
    {
        Console.WriteLine(" Hi.It's program i'm write for my practice work.Here i try to realese the DES encrypting and Decoding algoritm's. \nHere i create a two mode. 1st mode it a tast mode witch must to show how all work second must to read from file and\nafter this is to encode or decode the text and write it to a new file.\n");
        
        while (Cicle)
        {
            Action(Action_Chosen());
        }
    }

    private static string Action_Chosen()
    {
        Console.Write("\nChoose one of the options:\n\t1. Test the code and algorithm\n\t2. Encode the choising file\n\t3. Decode the choising file\n\t4. Update the text file\n\t5. Check the contents of a text file\n\t6. Return original text to text file\n\t7.View current key\n\t8.Enter a new key\n\t9.Generate random key\n\t10.close the program\nEnter ypur choice: ");
        Choise = Console.ReadLine();

        return Choise;
    }

    private static void Action(string Choise)
    {
        switch (Choise)
        {
            case "1":
                Mode_Chosen();
                break;

            case "2":
                Mode_Chosen();
                break;

            case "3":
                Mode_Chosen();
                break;

            case "4":
                Console.Write("\nPlease, entere the text: ");
                OriginalText = Console.ReadLine();
                rwFile.WriteInFile(OriginalText);
                break;

            case "5":
                string TemporaryText = rwFile.ReadFromFile();
                Console.WriteLine(TemporaryText);
                break;

            case "6":
                rwFile.WriteInFile("Hello. This is a pre-prepared text to demonstrate the operation of the algorithm. It can be changed and rewritten if you so desire.");
                break;

            case "7":
                Console.WriteLine("\nCurrent key: " + CurrentlyKey);
                break;

            case "8":
                Console.Write("\nEnter a new key: ");
                CurrentlyKey = Console.ReadLine();
                break;

            case "9":
                CurrentlyKey = Key.GenerationKey();
                break;

            case "10":
                Cicle = false;
                break;

            default:
                Console.WriteLine("\nData incorect. Try again");
                break;
        }
    }
    
    private static void Mode_Chosen()
    {
        Console.WriteLine("\nSelect the mode in which the algorithm will work.");
        Console.Write("\t1. ECB\n\t2. CBC\n\t3. CFB\n Enter ypur choice: ");

        switch(Console.ReadLine())
        {
            case "1":
                wText.ECBMain(Choise, rwFile.ReadFromFile(), CurrentlyKey, "ECB");
                break;
            case "2":
                wText.ECBMain(Choise, rwFile.ReadFromFile(), CurrentlyKey, "CBC");
                break;
            case "3":
                wText.ECBMain(Choise, rwFile.ReadFromFile(), CurrentlyKey, "CFB");
                break;
            default:
                break;
        }
    }
}