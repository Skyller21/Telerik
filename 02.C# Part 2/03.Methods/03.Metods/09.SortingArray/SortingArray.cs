using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SortingArray
{
    class SortingArray
    {
        static int len;
        static int index;

        static void Main()
        {
            Console.WriteLine("Enter the length of the array");
            len = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter index of starting number for portion of the array");
            index = int.Parse(Console.ReadLine());
            int[] newArray = new int[len];

            newArray = RandomGenerate(newArray);
            Console.WriteLine("The generated array is");
            PrintArray(newArray);
            Console.WriteLine("The maximal element in the portion of the array starting with index[{0}] is: {1}", index, FindMax(index, newArray));
            Console.WriteLine();            //Enter a new line
            Console.WriteLine("The array in Descending order:");
            SortDescending(newArray);
            PrintArrayInline(newArray);
            Console.WriteLine();            //enter a new line
            Console.WriteLine("The array in Ascending order:");
            SortAscending(newArray);
            PrintArrayInline(newArray);


        }

        static int[] RandomGenerate(int[] randomArray)
        {
            Random randomNumber = new Random();
            randomArray = new int[len];

            for (int i = 0; i < len; i++)
            {
                randomArray[i] = randomNumber.Next(50);
            }
            return randomArray;
        }

        static void PrintArray(int[] randomArray)
        {
            for (int i = 0; i < randomArray.Length; i++)
            {
                Console.WriteLine("Element [{0}] = {1}", i, randomArray[i]);
            }
            Console.WriteLine();
        }

        static void PrintArrayInline(int[] randomArray)
        {
            for (int i = 0; i < randomArray.Length; i++)
            {
                Console.Write("{0} ", randomArray[i]);
            }
            Console.WriteLine();
        }

        static void SwapElementsDescending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int temp = 0;
                if (array[i] < array[i + 1])
                {
                    temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                }
            }
        }

        static void SwapElementsAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int temp = 0;
                if (array[i] > array[i + 1])
                {
                    temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                }
            }
        }



        static int FindMax(int element, int[] array)
        {

            element = array[index];
            for (int i = index; i < len - 1; i++)
            {
                if (element < array[i])
                {
                    element = array[i];
                }
            }
            return element;

        }

        static int[] SortDescending(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                SwapElementsDescending(array);
            }
            return array;
        }

        static int[] SortAscending(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                SwapElementsAscending(array);
            }
            return array;
        }
    }
}
