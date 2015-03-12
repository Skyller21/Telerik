using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintASequence
{
    static void Main(string[] args)
    {
        int startNumber = 2;
        int lengthOfSequnce = 10;
        for (int i = startNumber; i < lengthOfSequnce + startNumber; i++)       //Loops from startNumber to the desired length of the sequence
        {                                                                       
            if (i != lengthOfSequnce + startNumber - 1)                         //Checks if the it is the last number of the sequence, if it's not
            {                                                                   //it will put a comma after the member...
                if (i % 2 == 0)
                {                                                               
                    Console.Write("{0}, ", i);
                }
                else
                {
                    Console.Write("{0}, ", -i);
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}", i);                                //...else the comma will be removed
                }
                else
                {
                    Console.WriteLine("{0}", -i);
                }
            }
        }
    }
}

