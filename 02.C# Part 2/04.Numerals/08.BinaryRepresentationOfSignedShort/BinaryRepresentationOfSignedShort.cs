using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BinaryRepresentationOfSignedShort
{
    static void Main()
    {
        Console.WriteLine("Enter signed short to convert to binary:");
        short number = short.Parse(Console.ReadLine());
        Console.WriteLine("The binary represantation of the number is: {0}",SignedShortToBinary(number));
    }

    static StringBuilder SignedShortToBinary(short number)
    {
        short negNumber = 0;
        StringBuilder binary = new StringBuilder();
        if (number < 0)
        {
            negNumber = (short)(number+short.MaxValue+1);
            while (negNumber > 0)
            {
                if (negNumber % 2 == 0)
                {
                    binary.Insert(0, 0);
                }
                else
                {
                    binary.Insert(0, 1);
                }
                negNumber = (short)(negNumber / 2);
            }
            for (int i = binary.Length; i < 15; i++)
            {
                binary.Insert(0, 0);
            }

            binary.Insert(0, 1);
            return binary;
        }
        else
        {
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
                number = (short)(number / 2);
            }
            for (int i = binary.Length; i < 16; i++)
            {
                binary.Insert(0, 0);
            }
            return binary;
        }
    }
}

