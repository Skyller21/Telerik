using System;
using System.Collections.Generic;

namespace OfficeSpace2
{
    using System.Collections;
    using System.Linq;

    public class Program
    {
        private static int[,] matrix;
        private static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Graph g = new Graph(n);
            //g.AddEdge(5, 2);
            //g.AddEdge(5, 0);
            //g.AddEdge(4, 0);
            //g.AddEdge(4, 1);
            //g.AddEdge(2, 3);
            //g.AddEdge(3, 1);

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (data.Count() == 1 && data[0] == 0)
                {
                    continue;
                }

                for (int j = 0; j < data.Length; j++)
                {
                    g.AddEdge(j, i);
                }
            }

            // Create a graph given in the above diagram


            Console.WriteLine("Following is a Topological " +
                               "sort of the given graph");
            g.TopologicalSort();

        }
    }

    // A Java program to print topological sorting of a DAG

    // This class represents a directed graph using adjacency
    // list representation
    public class Graph
    {
        private int V;   // No. of vertices
        private List<List<int>> adj; // Adjacency List

        //Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<List<int>>();
            for (int i = 0; i < v; ++i)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // A recursive function used by TopologicalSort
        public void topologicalSortUtil(int v, bool[] visited, Stack stack)
        {
            // Mark the current node as visited.
            visited[v] = true;


            // Recur for all the vertices adjacent to this vertex

            foreach (var i1 in adj[v])
            {

                if (!visited[i1])
                    topologicalSortUtil(i1, visited, stack);
            }

            // Push current vertex to stack which stores result
            stack.Push(v);
        }

        // The function to do Topological Sort. It uses recursive
        // topologicalSortUtil()
        public void TopologicalSort()
        {
            Stack stack = new Stack();

            // Mark all the vertices as not visited
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;

            // Call the recursive helper function to store Topological
            // Sort starting from all vertices one by one
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, stack);

            // Print contents of stack
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop() + " ");
        }


    }
}
