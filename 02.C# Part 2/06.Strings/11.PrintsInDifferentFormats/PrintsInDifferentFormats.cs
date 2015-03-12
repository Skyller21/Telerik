using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintsInDifferentFormats
{
    static void Main()
    {
        Console.WriteLine("Enter a number to convert");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("\n\rDecimal format");
        Console.WriteLine("{0,15:D}",number);
        Console.WriteLine("\n\rHexadecimal format");
        Console.WriteLine("{0,15:X}", number);
        Console.WriteLine("\n\rPercentage");
        Console.WriteLine("{0,15:P}", number);
        Console.WriteLine("\n\rSecientific notation");
        Console.WriteLine("{0,15:E}", number);
    }
}

