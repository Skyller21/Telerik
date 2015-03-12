using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FloatingPointNumberInIEEE754
{
    static float number;
    static float numberExp;
    static void Main()
    {
        Console.WriteLine("Enter a 32bit signed floating point number (C# type float):");
        number = float.Parse(Console.ReadLine());
        
        Console.WriteLine("The internal binary representation of\ngiven 32-bit signed floating-point number in IEEE 754 format is:\n");
        Console.WriteLine("The number {0} --> sign = {1}, exponent = {2}, mantissa = {3}",number,Sign(),Exponent(number),Mantissa());
        Console.WriteLine();
        Main();
    }

    static string Sign()
    {
        string sign = null;
        if (number > 0)
        {
            sign = "0";
        }
        else
        {
            sign = "1";
        }
        return sign;
    }

    static StringBuilder Exponent(float number)
    {
        StringBuilder exponent = new StringBuilder();
        int exp = 0;
        int counter = 1;
        numberExp = number*(-1);
        while (numberExp < 1 || numberExp > 2||numberExp<0)
        {
            if (Math.Abs(number) < 1)
            {
                numberExp = Math.Abs(number) * ((int)Math.Pow(2, counter));
                exp = -counter;
                counter++;
            }
            else
            {
                numberExp = Math.Abs(number) / ((int)Math.Pow(2, counter));
                exp = counter;
                counter++;
            }
            

        }
        exp = exp + 127;
        for (int i = 0; i < 8; i++)
        {
            if (exp % 2 == 0)
            {
                exponent.Insert(0, 0);
            }
            else
            {
                exponent.Insert(0, 1);
            }
            exp = exp / 2;
        }
        return exponent;
    }

    static StringBuilder Mantissa()
    {
        float mantissa = numberExp - 1;
        StringBuilder mant = new StringBuilder();
        for (int i = 1; i < 24; i++)
        {
            if (mantissa - 1 / Math.Pow(2, i) >= 0)
            {
                mantissa = mantissa - 1 / (float)Math.Pow(2, i);
                mant.Append("1");
            }
            else
            {
                mant.Append("0");
            }
        }
        return mant;
    }
}

