using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MultiplicationSign
{
    static void Main(string[] args)
    {
        string result = "0";

        Console.WriteLine("Enter number \"a\"");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"b\"");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"c\"");
        double c = double.Parse(Console.ReadLine());

        if (a == 0 | b == 0 | c == 0)
        {
            result = "0";
        }
        else if (a > 0 & b > 0 & c > 0)
        {
            result = "+";
        }
        else if (a < 0 & b < 0 & c < 0)
        {
            result = "-";
        }
        else if ((a < 0 ^ b < 0) ^ c < 0)
        {
            result = "-";
        }
        else if ((a < 0 & b < 0) ^ (a < 0 & c < 0) ^ (b < 0 & c < 0))
        {
            result = "+";
        }


        Console.WriteLine("\nThe result is: {0}",result);
    }
}

