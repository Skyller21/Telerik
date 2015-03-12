using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine(ConvertFromDecimalToBinary());
    }

    static StringBuilder ConvertFromDecimalToBinary()
    {

        Console.WriteLine("Enter a 32bit unsigned number to convert to binary");

        uint number = uint.Parse(Console.ReadLine());
        StringBuilder binary = new StringBuilder();
        while (number > 0)
        {
            if (number % 2 == 0)
            {
                binary.Insert(0, 0);
            }
            else
            {
                binary.Insert(0, 1);
            }
            number = number / 2;
        }
        Console.WriteLine(binary);
        for (int i = binary.Length; i < 32; i++)
        {
            binary.Insert(0, 0);
        }

        return binary;
    }




}


