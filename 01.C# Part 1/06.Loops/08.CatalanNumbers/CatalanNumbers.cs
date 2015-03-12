using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter the number \'n\'");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("N-th catalan number is (2N)!/((N+1)!*N!) = {0}", CalculateFactorial(2*n) / (CalculateFactorial(n+1) * CalculateFactorial(n)));
    }

    static BigInteger CalculateFactorial(int n)   //Method for calculating factorial
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
        }
        return factorial;
    }
}

