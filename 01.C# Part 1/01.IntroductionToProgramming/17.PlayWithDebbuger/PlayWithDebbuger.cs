using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayWithDebbuger
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter the length of the sequence");
        int lengthOfSequnce = int.Parse(Console.ReadLine());
        for (int i = 1; i < lengthOfSequnce; i++)                               //Loops from startNumber to the desired length of the sequence
        {
            Console.Write(i);                                                   //Breakpoint

            if (i%2==0)                                                         //Conditional breakpoint. It will stop only if the condition is true.
            {
                Console.Write(" {0}", "even");
            }
            Console.WriteLine();
        }
    }
}

