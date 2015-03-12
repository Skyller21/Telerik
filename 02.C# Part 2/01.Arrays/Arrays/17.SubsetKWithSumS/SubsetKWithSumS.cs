using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.SubsetKWithSumS
{
    class SubsetKWithSumS
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input size of the array");
            int size = int.Parse(Console.ReadLine());
            int[] inputArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("array[{0}] = ", i);
                inputArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Input subset size");
            int subsetSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Input searched sum");
            int sum = int.Parse(Console.ReadLine());

            int[] tempArray = new int[subsetSize];


            FindCombosWithSum(inputArray, tempArray, 0, 0, subsetSize, sum);

        }

        static void FindCombosWithSum(int[] inputArray, int[] tempArray, int start, int index, int subsetSize, int sum)
        {

            // Print the combo if it is equal to the sum
            if (index == subsetSize)
            {
                if (tempArray.Sum() == sum)
                {
                    PrintCombo(tempArray, sum);
                }
                return;            //Break the current recursion level
            }

            //Recursively call the method for all elements 
            for (int i = start; i <= inputArray.Length - 1; i++)
            {
                tempArray[index] = inputArray[i];
                start = i + 1;
                FindCombosWithSum(inputArray, tempArray, start, index + 1, subsetSize, sum);
            }

        }

        //Method for printing the subset
        static void PrintCombo(int[] array, int sum)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                {
                    Console.Write(array[i] + " + ");
                }
                else
                {
                    Console.WriteLine(array[i] + " = " + sum);
                }
            }
        }
    }
}
