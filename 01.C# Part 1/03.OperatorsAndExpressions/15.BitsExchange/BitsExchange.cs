using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitsExchange
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        uint i = uint.Parse(Console.ReadLine());
        int p = 3;
        int q = 24;
        int k = 3;

        int b = 0;

        uint result = i;

        Console.WriteLine("The initial number {0} = {1} in binary", i, Convert.ToString(i, 2).PadLeft(32, '0'));
        int count = Convert.ToString(i, 2).Length;
        //Console.WriteLine(count);

        for (b = 0; (b <= 32); b++)
        {
            int mask = 1 << b;
            uint temp = i & (uint)mask;

            if ((b >= p) & (b <= (p + k - 1)))
            {
                if (temp >> b != 0)
                {
                    result = result | ((uint)1 << q);
                }
                else
                {
                    result = result & ~((uint)1 << q);
                } q++;
            }
            else if ((b >= q - k) & (b <= q - 1))
            {
                if (temp >> b != 0)
                {
                    result = (result | ((uint)1 << p));
                }
                else
                {
                    result = (result & ~((uint)1 << p));
                }
                p++;
            }
        }
        Console.WriteLine("    The new number {0} = {1} in binary", result, Convert.ToString(result, 2).PadLeft(32, '0'));

    }
}

