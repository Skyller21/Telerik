namespace _13.AdtQueueImplementation
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var queue = new AdtQueue<int>();
            Console.WriteLine("Count initial: {0}", queue.Count());
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(-4);


            Console.WriteLine("\nCount after enqueue: {0}", queue.Count());
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPeek the queue: {0}", queue.Peek());
            queue.Dequeue();


            Console.WriteLine("\nCount after dequeue: {0}", queue.Count());
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
