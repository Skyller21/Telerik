using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number \"a\"");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"b\"");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"c\"");
        double c = double.Parse(Console.ReadLine());

        if (a >= b & a >= c)
        {
            if (b >= c)
            {
                Console.WriteLine(a + "," + b + "," + c);
            }
            else
            {
                Console.WriteLine(a + "," + c + "," + b);
            }
        }

        else if (b >= a & b >= c)
        {
            if (a >= c)
            {
                Console.WriteLine(b + "," + a + "," + c);
            }
            else
            {
                Console.WriteLine(b + "," + c + "," + a);
            }
        }

        else if (c >= a & c>=b)
        {
            if (a >= b)
            {
                Console.WriteLine(c + "," + a + "," + b);
            }
            else
            {
                Console.WriteLine(c + "," + b + "," + a);
            }
        }

        Main();
    }
}

