using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateSum
{
    static void Main()
    {
        Console.WriteLine("Enter the number \'n\'");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number \'X\'");
        int x = int.Parse(Console.ReadLine());

        Console.WriteLine("{0:f5}",CalculateTheSum(n,x)); 
    }

    static int CalculateFactorial(int n)                        //Method to calculate factorial.
    {
        int factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
        }
        return factorial;
    }

    static double CalculateTheSum(double n, double x)           //Method for calculating the sum
    {
        double sum = 1;

        for (int i = 1; i <= n; i++)
        {
            sum = sum + CalculateFactorial(i) / Math.Pow(x, i);
        }
        return sum;
    }
}

