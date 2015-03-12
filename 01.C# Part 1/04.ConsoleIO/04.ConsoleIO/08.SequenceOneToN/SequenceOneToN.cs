using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceOneToN
{
    static void Main()
    {
        Console.WriteLine("Enter a positive number:");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Number[{0}] = {1}", i, i);
        }
    }
}


