using System;

namespace S
{

    class quadrangle
    {
        public int[] x = new int[4];
        public int[] y = new int[4];
        public double[] a = new double[4];
        public double square = 0;
        public static double Atg(int x1, int x2, int y1, int y2)
        {
            if (x1 == x2)
            {
                return 1.57;
            }
            double a = Math.Abs(Math.Atan((y2 - y1) / (x2 - x1)));
            return a;
        }
        public quadrangle()
        {
            foreach (int i in x)
            {
                x[i] = y[i] = 0;
            };

        }
        public quadrangle(quadrangle b)
        {
            this.x = b.x;
            this.y = b.y;
        }
        public quadrangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            x[0] = x1;
            x[1] = x2;
            x[2] = x3;
            x[3] = x4;
            y[0] = y1;
            y[1] = y2;
            y[2] = y3;
            y[3] = y4;
            a[0] = Math.Abs(Atg(x1, x2, y1, y2));
            a[1] = Math.Abs(Atg(x2, x3, y2, y3));
            a[2] = Math.Abs(Atg(x3, x4, y3, y4));
            a[3] = Math.Abs(Atg(x4, x1, y4, y1));

        }
        public string Check()
        {
            if ((a[0] == a[1] && a[0] == Atg(x[0], y[0], x[2], y[2])) || (a[0] == a[3] && a[0] == Atg(x[3], y[3], x[1], y[1])) || (a[1] == a[2] && a[1] == Atg(x[1], y[1], x[3], y[3])) || (a[2] == a[3] && a[2] == Atg(x[2], y[2], x[0], y[0])))
            //
            {

                Console.WriteLine("По данным координатам невозможно построить четыреугольник");
                return "false";

            }
            if ((x[0] == x[1] && y[0] == y[1]) || (x[0] == x[2] && y[0] == y[2]) || (x[0] == x[3] && y[0] == y[3]) || (x[1] == x[2] && y[1] == y[2]) || (x[1] == x[3] && y[1] == y[3]) || (x[2] == x[3] && y[2] == y[3]))
            {
                Console.WriteLine("По данным координатам невозможно построить четыреугольник");
                return "false";
            }
            return "true";
        }
        public string Square()
        {
            if (this.Check() == "false")
            {
                return "false";
            }
            double sq = 0;
            sq = Triangle(x[0], y[0], x[1], y[1], x[2], y[2]) + Triangle(x[0], y[0], x[3], y[3], x[2], y[2]);

            string z = sq.ToString() + ' ' + perim();
            return z;
        }
        public string perim()
        {
            int[] vec1 = new int[2], vec2 = new int[2], vec3 = new int[2], vec4 = new int[2];
            vec1[0] = x[0] - x[1];
            vec1[1] = y[0] - y[1];
            vec2[0] = x[1] - x[2];
            vec2[1] = y[1] - y[2];
            vec3[0] = x[2] - x[3];
            vec3[1] = y[2] - y[3];
            vec4[0] = x[3] - x[0];
            vec4[1] = y[3] - y[0];
            double perim = Math.Sqrt(vec1[0] * vec1[0] + vec1[1] * vec1[1]) + Math.Sqrt(vec2[0] * vec2[0] + vec2[1] * vec2[1]) + Math.Sqrt(vec3[0] * vec3[0] + vec3[1] * vec3[1]) + Math.Sqrt(vec4[0] * vec4[0] + vec4[1] * vec4[1]);

            return perim.ToString();
        }
        public double Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int[] vec1 = new int[2], vec2 = new int[2], vec3 = new int[2];
            vec1[0] = x1 - x2;
            vec1[1] = y1 - y2;
            vec2[0] = x2 - x3;
            vec2[1] = y2 - y3;
            vec3[0] = x3 - x1;
            vec3[1] = y3 - y1;
            double a, b, c;
            a = Math.Sqrt(vec1[0] * vec1[0] + vec1[1] * vec1[1]);
            b = Math.Sqrt(vec2[0] * vec2[0] + vec2[1] * vec2[1]);
            c = Math.Sqrt(vec3[0] * vec3[0] + vec3[1] * vec3[1]);
            double p = (a + b + c) / 2;
            double sq = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return sq;
        }


    }
    class S
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] subs = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] par = new int[subs.Length];
            for (int i = 0; i < subs.Length; i++)
            {
                par[i] = Convert.ToInt32(subs[i]);
            }
            quadrangle A = new quadrangle(par[0], par[1], par[2], par[3], par[4], par[5], par[6], par[7]);

            Console.WriteLine(A.Square());
        }
    }
}
