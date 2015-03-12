using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.VariationsOfSet
{
    class VariationsOfSet
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of the elements");
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Input variations number");
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            Variations(0, array, k, n);
        }

        static void Variations(int index, int[] array, int k, int n)
        {
            if (index == k)
            {
                PrintCombo(array);
                return;
            }

            for (int counter = 1; counter <= n; counter++)
            {
                array[index] = counter;
                Variations(index + 1, array, k, n);
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
