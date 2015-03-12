using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringMax20Characters
{
    static void Main()
    {
        Console.WriteLine("Enter string");
        string str = Console.ReadLine();

        if (str.Length < 20)
        {
            str=str.PadRight(20,'*');
        }
        Console.WriteLine(str);
    }
}
