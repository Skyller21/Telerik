using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ApearanceCount
{
    class ApearanceCount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number to search in the array");
            int num = int.Parse(Console.ReadLine());
            int[] myArray = { 1, 5, 6, 1, 2, 0, -6, 1, 2, 5 };
            Console.WriteLine("The array is:");
            Console.WriteLine(new string('-',40));
            PrintArray(myArray);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("The number {0} is in the array: {1} times", num, CountAppearance(myArray, num));
        }

        static int CountAppearance(int[] array, int num)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
