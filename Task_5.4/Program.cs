using System;
using System.Text;

namespace Task_5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            string justString = "hmmm";

            for (int i = 0; i < 100000; ++i)
            {
                justString += "something";
            }
            
            DateTime end = DateTime.Now;
            Console.WriteLine("Concatenation with simple string taken: {0}", end - start);
            
            start = DateTime.Now;

            StringBuilder stringBuilder = new StringBuilder("hmmm");
            
            for (int i = 0; i < 100000; ++i)
            {
                stringBuilder.Append("something");
            }
            
            end = DateTime.Now;
            Console.WriteLine("Concatenation with StringBuilder taken: {0}", end - start);

            
            // if you concatenate strings not in cycle, use just string + string - it's compile into string.Concat(string, string)
            // more over if it's const strings, it's compiles into "stringstring"
        }
    }
}