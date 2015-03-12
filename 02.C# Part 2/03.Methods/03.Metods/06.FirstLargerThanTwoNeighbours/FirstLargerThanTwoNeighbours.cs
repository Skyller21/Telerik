using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FirstLargerThanTwoNeighbours
{
    class FirstLargerThanTwoNeighbours
    {
        static void Main(string[] args)
        {
            int[] myArray = { 1, 5, 6, 1, 1, 2, -6, 1, 2, 5 };
            Console.WriteLine("The array is:");
            Console.WriteLine(new string('-', 40));
            PrintArray(myArray);
            Console.WriteLine(new string('-', 40));
            CheckIfBigger(myArray);
        }

        static void CheckIfBigger(int[] array)
        {
            int counter = 0;
            for (int index = 1; index < array.Length - 1; index++)
            {
                if (array[index] > array[index - 1] && array[index] > array[index + 1])
                {
                    Console.WriteLine("The first element in the array bigger than its neighbours is element[{0}] = {1}", index,array[index]);
                    counter++;
                    break;
                }
            }

            if (counter==0)
            {
                Console.WriteLine("There is no element bigger than its two neighbours in the array!");
            }
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
