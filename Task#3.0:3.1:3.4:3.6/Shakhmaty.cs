using System;

namespace ConsoleApp3
{
    class Chess
    {
        public bool[,] board = new bool[8, 8];
        public Chess()
        {
            for(int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    board[i, j] = false;
                }
            }
        }
        public Chess(bool[,] board1)
        {
            board = board1;
        }
        public int Perim(bool[,]board)
        {

            int perim = 0;
            int i = 0;
            int j = 0;
            while (i < 8)
            {
                while (j < 8)
                {
                    if (board[i, j])
                    {
                        if (j == 0)
                        {
                            perim++;
                        }
                        else if (!board[i, j - 1])
                        {
                            perim++;
                        }
                        if (i == 0)
                        {
                            perim++;
                        }
                        else if (!board[i - 1, j])
                        {
                            perim++;
                        }
                        if (j == 7)
                        {
                            perim++;
                        }
                        else if (!board[i, j + 1])
                        {
                            perim++;
                        }
                        if (i == 7)
                        {
                            perim++;
                        }
                        else if (!board[i + 1, j])
                        {
                            perim++;
                        }
                    }
                    if (j < 7)
                    {
                        j++;
                    }
                    else if (i < 7)
                    {
                        j = 0;
                        i++;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }
            return perim;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Chess A = new Chess();
            int CountCell = Int32.Parse(Console.ReadLine());
            for (int i=0; i<CountCell; i++)
            {
                string s = Console.ReadLine();
                int k = Convert.ToInt32(s[0].ToString());
                int j = Convert.ToInt32(s[2].ToString());
                A.board[k, j] = true;
            }

            int perim = A.Perim(A.board);
            Console.WriteLine(perim);
        }
    }
}
