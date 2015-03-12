using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CheckABitAtPosition
{
    static void Main()
    {
        Console.WriteLine("Enter a number to check bit:");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the bit position to extract");
        byte b = byte.Parse(Console.ReadLine());
        bool check = true;

        int mask = 1 << b;
        int result = i & mask;
        Console.WriteLine("number {0} in decimal is = {1} in binary", i, Convert.ToString(i, 2).PadLeft(32, '0'));

        if (result == 0)
        {
            check = false;
        }
        else
        {
            check = true;
        }

        Console.WriteLine("Bit at position {0} == 1: {1}", b,check.ToString().ToLower());

        Main();
    }
}

