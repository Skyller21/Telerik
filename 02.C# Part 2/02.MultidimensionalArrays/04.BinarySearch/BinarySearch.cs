using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an array space separated. exapmple:(2 5 1 0 4)");
            string[] strArr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[strArr.Length];

            int k = int.Parse(Console.ReadLine());

            //Fill the array with int
            for (int i = 0; i < strArr.Length; i++)
            {
                array[i] = int.Parse(strArr[i]);
            }

            Array.Sort(array);
            int count = 0;
            for (int i = k; i >= 0;  i--)
            {
                int index = Array.BinarySearch(array, i);

                if (index>=0)
                {
                    Console.WriteLine("The biggest number <= {0} is: {1}",k,array[index]);
                    count++;
                    break;
                }
            }
            if (count==0)
            {
                Console.WriteLine("The number {0} is smaller than all the numbers in the array.",k);
            }

        }
    }
}
