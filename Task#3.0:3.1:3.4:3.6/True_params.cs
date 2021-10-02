using System;
using System.Collections.Generic;
namespace n_dimensional
{
    class Program
    {
        class Addition
        {
            public static int Add(params int[] mas)
            {
                int sum = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    sum += mas[i];
                }
                return sum;
            }
        }
        static void Main(string[] args)
        {
            int q = -1;
            int[] par;
            int sum = 0;
            string s = Console.ReadLine();
            string[] subs = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < subs.Length; i++)
            {
                par = new int[subs.Length];
                par[i] = Convert.ToInt32(subs[i]);

                sum += Addition.Add(par);
            }
            Console.WriteLine(sum);

        }
    }
}
