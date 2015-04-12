using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _5.BitsToBits
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            string allNums = "";

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
                //Console.WriteLine(arr[i]);

            }
            //Console.WriteLine(allNums);

            int counterOnes = 0;
            int temp = 0;
            for (int i = n - 1; i >= 0; i--)
            {


                if ((arr[i] & 1) != 1 && i != n - 1)
                {
                    temp = 0;
                }
                for (int j = 0; j < 30; j++)
                {
                    int mask = 1;

                    if ((arr[i] & (mask << j)) >> j == 1)
                    {
                        temp++;
                    }
                    else
                    {
                        temp = 0;
                    }
                    if (temp > counterOnes)
                    {
                        counterOnes = temp;
                    }
                }


            }

            int counterZeros = 0;
            temp = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if ((arr[i] & 1) == 1 && i != n - 1)
                {
                    temp = 0;
                }

                for (int j = 0; j < 30; j++)
                {
                    int mask = 1;

                    if ((arr[i] & (mask << j)) >> j == 0)
                    {
                        temp++;
                    }
                    else
                    {
                        temp = 0;
                    }
                    if (temp > counterZeros)
                    {
                        counterZeros = temp;
                    }
                }
            }


            Console.WriteLine(counterZeros);
            Console.WriteLine(counterOnes);

        }
    }
}
