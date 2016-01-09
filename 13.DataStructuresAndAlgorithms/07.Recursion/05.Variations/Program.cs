namespace _05.Variations
{
    using System;
    using Utils;

    class Program
    {
        private static string[] arr;
        private static string[] set;
        private static int k;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number n for generating array with lenght n:");
            var n = int.Parse(Console.ReadLine());
            arr = new string[n];


            Console.WriteLine("Enter a number k to generate k from n variations:");
            k = int.Parse(Console.ReadLine());
            set = new string[k];


            for (int i = 0; i < n; i++)
            {
                arr[i] = RandomGenerator.GetRandomString(2, 3);
            }
            Console.WriteLine("Generated array: {{{0}}}", string.Join(", ", arr));

            GenerateVariations(0);

        }

        private static void GenerateVariations(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(", ", set));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    set[index] = arr[i];
                    GenerateVariations(index + 1);
                }
            }
        }
    }
}
