using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ModifyBitAtPosition
{
    static void Main()
    {
        Console.WriteLine("Enter the number");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter position of the bit");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit value");
        int v = int.Parse(Console.ReadLine());

        int mask = 1 << p;
        Console.WriteLine("n={0}\np={1}\nv={2}", n, p, v);

        if (v == 1)
        {

            Console.WriteLine("The old number is = {0} = {1}\n\rThe new number is = {2} = {3}\n", Convert.ToString(n, 2).PadLeft(32, '0'), n, Convert.ToString(n | mask, 2).PadLeft(32, '0'), n | mask);
        }
        else
        {
            Console.WriteLine(
                "The old number is = {0} = {1}\n\rThe new number is = {2} = {3}\n", Convert.ToString(n, 2).PadLeft(32, '0'), n, Convert.ToString(n & ~(mask), 2).PadLeft(32, '0'), n & ~mask);
        }

        Main();
    }
}

