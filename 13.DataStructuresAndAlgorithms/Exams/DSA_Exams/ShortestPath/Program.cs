using System;

namespace ShortestPath
{
    using System.Collections.Generic;

    class Program
    {
        private static char[] data;
        private static int counter;
        private static HashSet<string> set = new HashSet<string>();
        static void Main(string[] args)
        {
            data = Console.ReadLine().ToCharArray();

            Solve(0);
            Console.WriteLine(counter);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

        }

        private static void Solve(int i)
        {
            if (i == data.Length)
            {
                counter++;
                set.Add(new string(data));
                return;
            }
            if (data[i] == '*')
            {
                data[i] = 'L';
                Solve(i + 1);

                data[i] = 'R';
                Solve(i + 1);

                data[i] = 'S';
                Solve(i + 1);

                data[i] = '*';
            }
            else
            {
                Solve(i + 1);
            }
        }
    }
}
