using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecimalToHex
{
    static void Main()
    {
        List<char> myList = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        Console.WriteLine("Enter the number in decimal");
        ulong numberDecimal = ulong.Parse(Console.ReadLine());
        ulong temp = numberDecimal;
        StringBuilder strHex = new StringBuilder();

        //Use this link or check google https://www.wisc-online.com/learn/formal-science/mathematics/tmh6207/an-algorithm-for-converting-a-hexadecimal-number-to-a-decimal-number

        while (temp >= 1)
        {
            strHex.Append(myList[(int)temp % 16]);
            temp = temp / 16;
        }

        Console.WriteLine("The number in     decimal representation is: {0}", numberDecimal);
        Console.Write("The number in hexadecimal representation is: ");
        for (int i = strHex.Length - 1; i >= 0; i--)
        {
            Console.Write(strHex[i]);
        }
        Console.WriteLine();

    }
}

