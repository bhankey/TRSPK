using System;

namespace Task_5._0
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    var key = Console.ReadKey().KeyChar;

                    var category = char.GetUnicodeCategory(key);

                    Console.WriteLine(" " + category.ToString());
                    
                    // if we want to check type of symbol use this
                    //
                    // if (char.IsDigit(key) || char.IsNumber(key))
                    // {
                    //     Console.WriteLine("Digit symbol");
                    // }
                    // else if (char.IsLetter(key))
                    // {
                    //     Console.WriteLine("Letter symbol");
                    // } else if (char.IsPunctuation(key)) 
                    // {
                    //     Console.WriteLine("Punctuation symbol");
                    // } else if (...)
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}