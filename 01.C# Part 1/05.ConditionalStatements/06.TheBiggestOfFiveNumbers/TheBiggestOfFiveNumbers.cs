using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        double biggestNum = 0;
        Console.WriteLine("Enter number \"a\"");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"b\"");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"c\"");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"e\"");
        double e = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"d\"");
        double d = double.Parse(Console.ReadLine());

        if (a >= b & a >= c & a >= d & a >= e)
        {
            biggestNum = a;
        }
        if (b >= a & b >= c & b >= d & b >= e)
        {
            biggestNum = b;
        }
        if (c >= a & c >= b & c >= d & c >= e)
        {
            biggestNum = c;
        }
        if (d >= a & d >= b & d >= c & d >= e)
        {
            biggestNum = d;
        }
        if (e >= a & e >= b & e >= c & e >= d)
        {
            biggestNum = e;
        }

        Console.WriteLine("biggest: {0}\n", biggestNum);

        Main();
    }
}

