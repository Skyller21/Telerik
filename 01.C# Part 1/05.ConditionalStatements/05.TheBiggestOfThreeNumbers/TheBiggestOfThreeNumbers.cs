using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TheBiggestOfThreeNumbers
{
    static void Main(string[] args)
    {
        double biggestNum = 0;
        Console.WriteLine("Enter number \"a\"");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"b\"");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"c\"");
        double c = double.Parse(Console.ReadLine());

        if (a >= b & a >= c)
        {
            biggestNum = a;
        }

        else if (b >= a & b >= c)
        {
            biggestNum = b;
        }
        else
        {
            biggestNum = c;
        }

        Console.WriteLine("biggest: {0}", biggestNum);
    }
}

