namespace FastPower
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var a = Power(3, 5);
            Console.WriteLine(a);
        }

        private static long Power(long a, long n)
        {

            if (n == 0)
            {
                return 1;
            }

            if (n % 2 == 1)
            {
                a = Power(a, n - 1) * a;
                return a;
            }
            a = Power(a, n / 2);
            return a * a;
        }
    }
}
