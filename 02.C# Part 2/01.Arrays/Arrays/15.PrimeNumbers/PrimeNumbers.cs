using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            int[] list = new int[10000000];

            for (int i = 2; i < list.Length; i++)
            {
                if (list[i]==1)                         //If the number is already checked as prime -> continue
                {
                    continue;
                }
                for (int j = i*2; j < list.Length; j+=i)        //j=i*2 -> this avoids marking the current prime number  
                {
                    list[j] = 1;
                }
            }
            //Print the numbers. For 10 000 000 numbers it's a lot of time. You could try for smaller count :)
            for (int i = 2; i < list.Length; i++)
            {
                if (list[i]==0)
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
