using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the n-th Fibonacci number");
        int n = int.Parse(Console.ReadLine());
        int first = 1;
        int second = 2;
        Console.WriteLine("The first {0} Fibonacci numbers are",n);
        Console.WriteLine(new string('-',40));
        Console.WriteLine("{0}\n{1}\n{2}\n{3}",0,1,first,second);
        for (int i = 0; i < n-4; i++)
        {
            int fibNum = first + second;
            first = second;
            second = fibNum;
            Console.WriteLine(fibNum);
        }
    }
}

