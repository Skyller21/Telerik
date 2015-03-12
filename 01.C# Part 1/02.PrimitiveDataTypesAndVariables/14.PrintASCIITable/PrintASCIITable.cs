using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintASCIITable
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 256; i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write((char)i + " ");
            }
        }
        Console.WriteLine("\n");
    }
}

