namespace Fibonacci
{
    using System;

    public class Program
    {
        const int MOD = 1000000007;

        public static void Main(string[] args)
        {
            var numberToFind = long.Parse(Console.ReadLine());
            var startMatrix = new Matrix(1, 1, 1, 0);
            Console.WriteLine(PowMod(startMatrix, numberToFind).Table[0, 1]);
        }

        public static Matrix PowMod(Matrix a, long p)
        {
            if (p == 1)
            {
                return a;
            }

            if (p % 2 == 1)
            {
                return new Matrix(PowMod(a, p - 1), a);
            }
            else
            {
                a = PowMod(a, p / 2);
                return new Matrix(a, a);
            }
        }
    }

    public class Matrix
    {
        const int MOD = 1000000007;

        public Matrix(Matrix A, Matrix B)
        {
            this.Table = new long[2, 2];
            this.Table[0, 0] = A.Table[0, 0] * B.Table[0, 0] +
                A.Table[0, 1] * B.Table[1, 0];
            this.Table[0, 1] = A.Table[0, 0] * B.Table[0, 1] +
                A.Table[0, 1] * B.Table[1, 1];
            this.Table[1, 0] = A.Table[1, 0] * B.Table[0, 0] +
                A.Table[1, 1] * B.Table[1, 0];
            this.Table[1, 1] = A.Table[1, 0] * B.Table[0, 1] +
                A.Table[1, 1] * B.Table[1, 1];

            this.Table[0, 0] %= MOD;
            this.Table[0, 1] %= MOD;
            this.Table[1, 0] %= MOD;
            this.Table[1, 1] %= MOD;
        }

        public Matrix(long a, long b, long c, long d)
        {
            this.Table = new long[2, 2];
            this.Table[0, 0] = a;
            this.Table[0, 1] = b;
            this.Table[1, 0] = c;
            this.Table[1, 1] = d;
        }

        public long[,] Table { get; set; }
    }
}
