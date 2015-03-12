using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.CombinationsOfSet
{
    class CombinationsOfSet
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of the elements");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Input variations number");
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            Combinations(0, 1, array, k, n);

        }

        static void Combinations(int index, int start, int[] array, int k, int n)
        {
            if (index == k)
            {
                PrintCombo(array);
                return;
            }
            for (int i = start; i <= n; i++)
            {
                array[index] = i;
                start = i + 1;
                Combinations(index + 1, start, array, k, n);
            }
        }
        //Method for printing the subset
        static void PrintCombo(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
