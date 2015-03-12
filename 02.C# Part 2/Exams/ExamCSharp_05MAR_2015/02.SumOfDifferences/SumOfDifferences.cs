using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class SumOfDifferences
{
    static void Main(string[] args)
    {
        string[] text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


        int index = 1;

        BigInteger sum = 0;

        while (index < text.Length)
        {
            long diff = Math.Abs(long.Parse(text[index]) - long.Parse(text[index-1]));

            if (diff%2==0)
            {
                index += 2;
            }
            else
            {
                index++;
                sum += diff;
            }
        }

        Console.WriteLine(sum);
    }
}
