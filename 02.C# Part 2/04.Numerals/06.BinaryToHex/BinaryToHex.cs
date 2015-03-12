using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryToHex
{
    static void Main()
    {
        Console.WriteLine( "The hexadecmal represantation of the number is: {0}",ConvertBinaryToHex() ); 
    }

    static StringBuilder ConvertBinaryToHex()
    {
        Console.WriteLine("Enter binary number to convert into hexadecimal value:");
        string binary = Console.ReadLine();
        List<char> binList = binary.ToList();
        StringBuilder hex = new StringBuilder();
        for (int i = binList.Count(); i < 64; i++)
        {
            binList.Insert(0,'0');
        }

        for (int i = 0; i < binList.Count() ; i+=4)
        {
            switch(binList[i].ToString() + binList[i + 1].ToString() + binList[i + 2].ToString() + binList[i + 3].ToString())
            {
                case "0000": hex.Append(""); break;
                case "0001": hex.Append("1"); break;
                case "0010": hex.Append("2"); break;
                case "0011": hex.Append("3"); break;
                case "0100": hex.Append("4"); break;
                case "0101": hex.Append("5"); break;
                case "0110": hex.Append("6"); break;
                case "0111": hex.Append("7"); break;
                case "1000": hex.Append("8"); break;
                case "1001": hex.Append("9"); break;
                case "1010": hex.Append("A"); break;
                case "1011": hex.Append("B"); break;
                case "1100": hex.Append("C"); break;
                case "1101": hex.Append("D"); break;
                case "1110": hex.Append("E"); break;
                case "1111": hex.Append("F"); break;
                default: Console.WriteLine("Wrong Input"); break;
            }
        }
        return hex;
    }
}

