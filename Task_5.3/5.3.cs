using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Smth
{
    class Read
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст. Для завершения ввода введите строку '!q'.");
            string txt = "";
            string line;
            do
            {
                line = Console.ReadLine();
                if (line != "!q")
                txt += "\n" + line;
            } while (line != "!q");
            using (var writer = new StreamWriter(@"C:\test1.txt", true, Encoding.GetEncoding(20127))) //ASCII
            {
                writer.Write(txt);
                writer.Close();
            }
            using (var writer = new StreamWriter(@"C:\test2.txt", true, Encoding.GetEncoding(65000))) //UTF-7
            {
                writer.Write(txt);
                writer.Close();
            }
            using (var writer = new StreamWriter(@"C:\test3.txt", true, Encoding.GetEncoding(65001))) //UTF-8
            {
                writer.Write(txt);
                writer.Close();
            }
            FileStream stream = new FileStream(@"C:\test1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            stream.Close();
            Console.WriteLine(str);
            stream = new FileStream(@"C:\test2.txt", FileMode.Open);
            reader = new StreamReader(stream);
            str = reader.ReadToEnd();
            stream.Close();
            Console.WriteLine(str);
            stream = new FileStream(@"C:\test3.txt", FileMode.Open);
            reader = new StreamReader(stream);
            str = reader.ReadToEnd();
            stream.Close();
            Console.WriteLine(str);
        }
    }
}