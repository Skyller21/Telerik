using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SumNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three real numbers each on new line:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double sum = a+b+c;

        Console.WriteLine("{0} + {1} + {2} = {3}",a,b,c,sum);

    }
}

