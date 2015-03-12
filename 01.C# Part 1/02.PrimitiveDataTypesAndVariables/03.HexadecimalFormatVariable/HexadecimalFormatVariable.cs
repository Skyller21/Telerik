using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HexadecimalFormatVariable
{
    static void Main(string[] args)
    {
        int numberDecimal = 254;
        string numberHexString = Convert.ToString(numberDecimal, 16);
        Console.WriteLine("The number 254 in hexadecimal format is: {0}", numberHexString.ToUpper());

        int numberInHex = 0xFE;

        Console.WriteLine(numberInHex);


    }
}

