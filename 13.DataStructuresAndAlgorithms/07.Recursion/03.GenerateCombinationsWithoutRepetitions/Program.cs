using System;
using System.Text;

namespace _03.GenerateCombinationsWithoutRepetitions
{
    using System.Collections.Generic;

    class Program
    {
        private static int[] arr;
        private static int n;
        private static int k;
        private static StringBuilder sb;
        private static int counter = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number n:");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number k(for genereating from n):");
            k = int.Parse(Console.ReadLine());

            sb = new StringBuilder();
            arr = new int[k];

            var list = new List<int>();
            GenerateCombinations(0, 0);

            Console.WriteLine(sb.ToString().Trim(new char[] { ',', ' ' }));
            Console.WriteLine("Number of combinations {0} of {1}: {2}", k, n, counter);
        }

        private static void GenerateCombinations(int index, int start)
        {
            if (index >= k)
            {
                counter++;
                sb.Append("(");
                sb.Append(string.Join(" ", arr));
                sb.Append("), ");
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i + 1;

                    GenerateCombinations(index + 1, i + 1);
                }
            }
        }
    }
}
