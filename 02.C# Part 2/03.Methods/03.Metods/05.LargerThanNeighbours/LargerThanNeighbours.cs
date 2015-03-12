using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the index to check in the array");
            int index = int.Parse(Console.ReadLine());
            int[] myArray = { 1, 5, 6, 1, 2, 0, -6, 1, 2, 5 };
            Console.WriteLine("The array is:");
            Console.WriteLine(new string('-', 40));
            PrintArray(myArray);
            Console.WriteLine(new string('-', 40));
            CheckIfBigger(myArray, index);
        }

        static void CheckIfBigger(int[] array, int index)
        {
            if (index>0 && index<array.Length-1)
            {
                if (array[index]>array[index-1] && array[index]>array[index+1])
                {
                    Console.WriteLine("The element at index \'{0}\' is bigger than its neighbours",index);
                }
                else
                {
                    Console.WriteLine("The element at index \'{0}\' is NOT bigger than its neighbours", index);
                }
            }
            else if (index < 0 || index > array.Length - 1)
            {
                Console.WriteLine("There is no element with this index in the array");
            }
            else
            {
                Console.WriteLine("The element at index \'{0}\' has not got two neighbours",index);
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
