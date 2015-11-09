using System;

namespace _01.PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default compare of binary heap is Max.
            var priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(5);


            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
