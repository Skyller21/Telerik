using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.PermutationOfSet
{
    class PermutationOfSet
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Input number of the elements");
            //int n = int.Parse(Console.ReadLine());


            int[] array = { 1, 2, 3 };

            Permutation(array, array.Length, 0);
        }

        static void Permutation(int[] array, int n, int i)
        {
            if (i >= n - 1)
            {
                PrintCombo(array);
                return;
            }
            else
            {
                Permutation(array, n, i + 1);
                for (int j = i + 1; j < n; j++)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    Permutation(array, n, i + 1);
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
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
