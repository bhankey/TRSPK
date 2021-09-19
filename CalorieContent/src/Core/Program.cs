using System;
using CalorieContent.lib.KeyValueStorage;

namespace CalorieContent
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage("C:\\Users\\Sergey\\RiderProjects\\TRSPK\\CalorieContent\\DB\\NewDataBase");

            storage.TryGetString("database", out string result);
            Console.WriteLine(result);
            
            storage.SetString("database", "lol");
            storage.SetString("dat1base", "lol");
            storage.SetString("datab1se", "lol");
            
            storage.TryGetString("database", out result);
            Console.WriteLine(result);
        }
    }
}