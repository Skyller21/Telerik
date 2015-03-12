using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecimalToHex
{
    static void Main()
    {
        Console.WriteLine("The hexadecimal represantation of the number is: {0}", ConvertFromDecimalToHex());
    }

    static StringBuilder ConvertFromDecimalToHex()
    {

        Console.WriteLine("Enter a 64bit unsigned decimal number to convert to hexadecimal");

        ulong number = ulong.Parse(Console.ReadLine());
        StringBuilder hex = new StringBuilder();
        while (number > 0)
        {
            switch (number % 16)
            {
                case 0: hex.Insert(0, '0'); break;
                case 1: hex.Insert(0, '1'); break;
                case 2: hex.Insert(0, '2'); break;
                case 3: hex.Insert(0, '3'); break;
                case 4: hex.Insert(0, '4'); break;
                case 5: hex.Insert(0, '5'); break;
                case 6: hex.Insert(0, '6'); break;
                case 7: hex.Insert(0, '7'); break;
                case 8: hex.Insert(0, '8'); break;
                case 9: hex.Insert(0, '9'); break;
                case 10: hex.Insert(0, 'A'); break;
                case 11: hex.Insert(0, 'B'); break;
                case 12: hex.Insert(0, 'C'); break;
                case 13: hex.Insert(0, 'D'); break;
                case 14: hex.Insert(0, 'E'); break;
                case 15: hex.Insert(0, 'F'); break;
                default: Console.WriteLine("Wrong input"); break;
            }
            number = number / 16;
        }
        return hex;
    }
}

