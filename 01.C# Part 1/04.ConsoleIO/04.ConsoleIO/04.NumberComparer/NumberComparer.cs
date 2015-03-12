using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberComparer
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("The bigger number is: {0}", Math.Max(a, b));

    }
}

