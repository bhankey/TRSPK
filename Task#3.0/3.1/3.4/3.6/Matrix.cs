using System;

namespace S
{


    class S
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a range of numbers: from, to");
            int from = int.Parse(Console.ReadLine());
            int to = int.Parse(Console.ReadLine());

            int[,] mas = new int[x, y];

            Random random = new Random();

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {

                    mas[i, j] = random.Next(from, to);

                }
            }
            for (int p = 0; p < mas.GetLength(0); p++)
            {
                for (int q = 0; q < mas.GetLength(1); q++)
                {

                    Console.Write(mas[p, q] + " ");

                }
                Console.WriteLine();
            }
        }
    }
    }
