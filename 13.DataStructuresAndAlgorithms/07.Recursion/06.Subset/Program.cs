using System;
using System.Text;

namespace _06.Subset
{
    using System.Linq;

    class Program
    {
        private static string[] arr;
        private static string[] set;
        private static int k;
        private static StringBuilder sb;
        private static int counter = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number k(for genereating from n):");
            k = int.Parse(Console.ReadLine());

            sb = new StringBuilder();
            set = new string[k];
            arr = new[] { "планета", "чалгийка", "мазна" };

            GenerateCombinations(0, 0);

            Console.WriteLine(sb.ToString().Trim(new char[] { ',', ' ' }));
            Console.WriteLine("Number of combinations: {0}", counter);
        }

        private static void GenerateCombinations(int index, int start)
        {
            if (index >= k)
            {
                counter++;
                sb.Append("(");
                sb.Append(string.Join(" ", set));
                sb.Append("), ");
            }
            else
            {
                for (int i = start; i < arr.Count(); i++)
                {
                    set[index] = arr[i];

                    GenerateCombinations(index + 1, i + 1);
                }
            }
        }
    }
}
