using System;

namespace _01.NestedLoopRecursive
{
    class Program
    {
        private static int[] arr;
        private static int k;
        private static int n;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number n:");
            n = int.Parse(Console.ReadLine());
            k = n;
            arr = new int[k];
            Generate(0);

        }

        private static void Generate(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i + 1;
                    Generate(index + 1);
                }
            }
        }
    }
}
