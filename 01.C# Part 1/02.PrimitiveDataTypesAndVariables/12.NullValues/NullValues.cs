using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NullValues
{
    static void Main(string[] args)
    {
        int? a = null;
        double? b = null;

        Console.WriteLine("a= {0}", a);     //a has null value
        Console.WriteLine("b= {0}", b);     //b has null value
        Console.WriteLine();
        //--------------------------------------------------------
        int number = 5;
        int? nullNumber = number;

        Console.WriteLine(number);
        Console.WriteLine(nullNumber.HasValue);
        Console.WriteLine(nullNumber);
        Console.WriteLine();

        nullNumber = null;
        Console.WriteLine(nullNumber.HasValue);
        Console.WriteLine();

        number = nullNumber.GetValueOrDefault();
        Console.WriteLine(number);   
    }
}

