using System;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferenceMatter diff = new DifferenceMatter();

            // Console.WriteLine(diff.i); // Не можем так обратиться, т.к константа является неявно статическим членом
            Console.WriteLine(DifferenceMatter.i);

            Console.WriteLine(diff.ReturnConstant());

            Console.WriteLine(diff.s.ReturnReadOnly());
        }
    }
}