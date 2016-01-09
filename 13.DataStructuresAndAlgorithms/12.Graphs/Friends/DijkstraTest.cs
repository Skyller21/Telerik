namespace DijkstraLINQ
{
    using System;
    using System.Linq;

    public class DijkstraTest
    {
        public static void Main()
        {

            var data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var nodes = data[0];
            var streets = data[1];
            var h = data[2];

            string[] hospitals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var graph = new Graph();

            for (int i = 0; i < nodes; i++)
            {
                graph.AddNode((i + 1).ToString());
            }


            for (int i = 0; i < streets; i++)
            {
                var connData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                graph.AddConnection(connData[0], connData[1], int.Parse(connData[2]), true);
            }


            var calculator = new DistanceCalculator();

            var minSum = double.MaxValue;

            for (int i = 0; i < hospitals.Length; i++)
            {
                var distances = calculator.CalculateDistances(graph, hospitals[i]);  // Start from "G"

                var sum = distances.Where(x => hospitals.All(p => p != x.Key)).Sum(x => x.Value);

                if (sum < minSum)
                {
                    minSum = sum;
                }
            }

            Console.WriteLine(minSum);



        }
    }
}
