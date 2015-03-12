using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter the number in decimal");
        ulong numberDecimal = ulong.Parse(Console.ReadLine());
        ulong temp = numberDecimal;
        StringBuilder strBin = new StringBuilder();

        while (temp >= 1)           //Divide by 2 until the result is lower than 1
        {                           //Every time add the reminder to a string. Written backwards the final result is the binary number.
            if (temp % 2 == 1)
            {
                strBin.Append('1');
            }
            else
            {
                strBin.Append('0');
            }
            temp = temp / 2;
        }

        Console.WriteLine("The number in decimal representation is: {0}", numberDecimal);
        Console.Write("The number in  binary representation is: ");
        for (int i = strBin.Length - 1; i >= 0; i--)                //Print the string backwards. This is the binary number.
        {
            Console.Write(strBin[i]);
        }
        Console.WriteLine();
    }
}

