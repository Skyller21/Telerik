namespace Fibonacci
{
    using System;

    class Program
    {
        // This module is used for the recursive method... this is the task.
        private const int Module = 1000000007;
        private static int[] memo;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            memo = new int[n + 1];

            Console.WriteLine(FibonacciIterative((long)n));
            Console.WriteLine(Fibonacci(n));
        }

        // Recursive
        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            int number = (Fibonacci(n - 1) + Fibonacci(n - 2));

            memo[n] = number;

            return number;

        }

        static long FibonacciIterative(long n)
        {

            long firstNum = 0;
            long secondNum = 1;
            long currentNum = 1;


            for (int i = 2; i < n; i++)
            {
                firstNum = secondNum;
                secondNum = currentNum;
                currentNum = firstNum + secondNum;
            }

            return currentNum;
        }

    }
}
