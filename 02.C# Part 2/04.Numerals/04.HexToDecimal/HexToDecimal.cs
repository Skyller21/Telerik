using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HexToDecimal
{
    static void Main()
    {
        Console.WriteLine("The decimal represantation of the number is: {0}",ConvertFromHexToDecimal());
    }

    static ulong ConvertFromHexToDecimal()
    {
        Console.WriteLine("Enter hexadecimal number to convert to decimal:");
        string hex = Console.ReadLine();
        string[] hexArray = new string[hex.Length];
        ulong number = 0;

        for (int i = 0; i < hex.Length; i++)
        {
            hexArray[i] = hex.Substring(i, 1);
        }
        Array.Reverse(hexArray);
        for (int i = 0; i < hexArray.Length; i++)
        {
            switch (hexArray[i].ToUpper())
            {
                case "1": number = number + 1*(uint)Math.Pow(16, i); break;
                case "2": number = number + 2*(uint)Math.Pow(16, i); break;
                case "3": number = number + 3*(uint)Math.Pow(16, i); break;
                case "4": number = number + 4*(uint)Math.Pow(16, i); break;
                case "5": number = number + 5*(uint)Math.Pow(16, i); break;
                case "6": number = number + 6*(uint)Math.Pow(16, i); break;
                case "7": number = number + 7*(uint)Math.Pow(16, i); break;
                case "8": number = number + 8*(uint)Math.Pow(16, i); break;
                case "9": number = number + 9*(uint)Math.Pow(16, i); break;
                case "A": number = number + 10*(uint)Math.Pow(16, i); break;
                case "B": number = number + 11*(uint)Math.Pow(16, i); break;
                case "C": number = number + 12*(uint)Math.Pow(16, i); break;
                case "D": number = number + 13*(uint)Math.Pow(16, i); break;
                case "E": number = number + 14*(uint)Math.Pow(16, i); break;
                case "F": number = number + 15*(uint)Math.Pow(16, i); break;
                default: Console.WriteLine("Wrong Input"); break;
            }
        }
        return number;
    }
}

