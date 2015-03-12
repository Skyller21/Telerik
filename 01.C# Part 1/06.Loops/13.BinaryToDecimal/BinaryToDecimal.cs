using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Input a binary number");
        string binary = Console.ReadLine();
        long result = 0;
        int j = 0;

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if (binary[i] == '1')                       //Check if the bit on that position is one and if it is you add 2^j (j is bit position)
            {
                result = result + (long)Math.Pow(2, j);
            }
            j++;
        }
        Console.WriteLine("The number in binary  representation is: {0}\nThe number in decimal representation is: {1}",binary,result);
    }
}

