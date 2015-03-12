using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.QuickSort
{
    class QuickSort
    {
        static void Main(string[] args)
        {
            int[] unsortedArray = { -1, 5, 2, 0, 4, 1, 6, 3, 9, 8 };
            PrintArray(unsortedArray);

            QuickSortAlgorithm(unsortedArray, 0, unsortedArray.Length - 1);
            PrintArray(unsortedArray);
        }

        static void QuickSortAlgorithm(int[] array, int start, int end)
        {
            

            int i = start, j = end;
            int pivot = array[start +(end - start) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap the elements
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (start < j)
            {
                QuickSortAlgorithm(array, start, j);
            }

            if (i < end)
            {
                QuickSortAlgorithm(array, i, end);
            }
            
        }

        //Method for printing the array
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
