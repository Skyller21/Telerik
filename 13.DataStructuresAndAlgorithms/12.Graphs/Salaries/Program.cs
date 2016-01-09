using System;

namespace Salaries
{
    class Program
    {
        private static long[] cache;
        private static bool[,] graph;
        private static int nodes;

        static void Main(string[] args)
        {
            nodes = int.Parse(Console.ReadLine());
            cache = new long[nodes];
            graph = new bool[nodes, nodes];

            // Read the adjacent matrix
            for (int i = 0; i < nodes; i++)
            {
                char[] connections = Console.ReadLine().ToCharArray();

                for (int j = 0; j < connections.Length; j++)
                {
                    graph[i, j] = (connections[j] == 'Y');
                }
            }

            long sumOfSalaries = 0;

            for (int i = 0; i < nodes; i++)
            {
                sumOfSalaries += FindSalary(i);
            }

            Console.WriteLine(sumOfSalaries);
        }


        static long FindSalary(int employee)
        {
            if (cache[employee] > 0)
            {
                return cache[employee];
            }

            long salary = 0;

            for (int i = 0; i < nodes; i++)
            {
                if (graph[employee, i])
                {
                    salary += FindSalary(i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            cache[employee] = salary;
            return salary;
        }
    }
}
