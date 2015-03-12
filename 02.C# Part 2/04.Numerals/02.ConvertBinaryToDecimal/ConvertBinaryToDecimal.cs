using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConvertBinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("The decimal representation of 32bit unsigned number is:\n{0}",ConvertFromBinaryToDecimal());
    }

    static uint ConvertFromBinaryToDecimal()
    {
        Console.WriteLine("Enter binary number to convert to decimal");
        uint number = 0;
        string binary = Console.ReadLine();
        char[] array = binary.ToCharArray();
        Array.Reverse(array);

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == '1')
            {
                number = number + (uint)Math.Pow(2, i);
            }
            else if (array[i] == '0')
            {
                number = number + 0;
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
                ConvertFromBinaryToDecimal();
            }

        }
        return number;
    }

}

