using System;
using System.Collections.Generic;

namespace OfficeSpace
{
    using System.Linq;

    class OfficeSpace
    {
        private static int[,] matrix;
        private static int n;



        static void Main(string[] args)
        {

            n = int.Parse(Console.ReadLine());

            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            matrix = new int[n, n];
            var counter = 0;

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (data.Count() == 1 && data[0] == 0)
                {
                    continue;
                }

                for (int j = 0; j < data.Length; j++)
                {
                    counter++;
                    matrix[j, i] = 1;
                }
            }



            if (counter == 0)
            {
                Console.WriteLine(times.Max());
                return;
            }


            //PrintAdjacentMatrix();


            //var matrix = new int[,]
            //                 {
            //                     { 0, 1, 0, 0, 1, 0 },
            //                     { 0, 0, 1, 1, 0, 0 },
            //                     { 0, 0, 0, 1, 0, 0 },
            //                     { 0, 0, 0, 0, 1, 1 },
            //                     { 0, 0, 0, 0, 0, 1 },
            //                     { 0, 0, 0, 0, 0, 0 },
            //                 };




            var graph = new Graph(matrix);
            graph.TestDfs();

            var sum = 0;

            graph.SortedElements.Reverse();

            for (int i = 0; i < graph.SortedElements.Count; i++)
            {
                sum += times[i];
            }

            Console.WriteLine(sum);

            //graph.ShowSort();
        }

        private static void PrintAdjacentMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }




    public class Graph
    {
        private readonly int[,] edges;

        private readonly int count;

        public bool[] VisitedElements;

        public List<int> SortedElements = new List<int>();

        public Graph(int[,] e)
        {
            this.edges = e;
            this.count = e.GetLength(0);
            this.VisitedElements = new bool[this.count];
        }

        public void Dfs(int startIndex)
        {
            this.VisitedElements[startIndex] = true;

            for (int k = 0; k < this.count; k++)
            {
                if ((this.edges[startIndex, k] == 1) && (this.VisitedElements[k] == false))
                {
                    this.Dfs(k);
                }
            }

            this.SortedElements.Add(startIndex);
        }


        public void TestDfs()
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.VisitedElements[i] == false)
                {
                    this.Dfs(i);
                }
            }
        }

        public void ShowSort()
        {
            this.SortedElements.Reverse();
            foreach (int node in this.SortedElements)
            {
                Console.Write("{0} ", node);
            }
        }
    }






}

