using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExtractBitNumberThree
{
    static void Main()
    {
        Console.WriteLine("Enter a number to check the third bit:");
        int i = int.Parse(Console.ReadLine());
        
        byte b = 3;

        int mask = 1 << b;              //Example: If the num is 36. Its representation in binary format is 100100
                                        //If we want to check the third bit (b=3) we move the number "1" 3 times to the left.
                                        //1 in binary is again 1. 
                                        //        543210 - Number of the bits
                                        //So 36 = 100100
                                        //    1 = 000001
                                        // 1<<3 = 001000

                                       //i&mask = 100100 & 001000 = 0
        int result = i & mask;
        Console.WriteLine("number {0} in decimal is = {1} in binary",i, Convert.ToString(i, 2).PadLeft(32, '0'));

        if (result == 0)               //If the result is 0 it means that the bit is 0. Else the results is not zero. 
        {
            Console.WriteLine("Bit number {0} is 0\n", b);
        }
        else
        {
            Console.WriteLine("Bit number {0} is 1\n", b);
        }

        Main();
    }
}
