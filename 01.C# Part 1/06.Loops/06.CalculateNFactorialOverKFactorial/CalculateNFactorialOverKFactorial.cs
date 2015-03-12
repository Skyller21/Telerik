using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateNFactorialOverKFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter the number \'n\'");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number \'k\'");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("N!/K! = {0}",CalculateFactorial(n)/CalculateFactorial(k));
    }

    static int CalculateFactorial(int n)            //Method for calculating factorial.
    {
        int factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
        }
        return factorial;
    }
}

