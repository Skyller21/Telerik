using System;

namespace _11.ImplementLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new AdtLinkedList<int>();

            linkedList.Add(5);
            linkedList.Add(1);
            linkedList.Add(-8);

            Console.WriteLine("After adding count: {0}", linkedList.Count());
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.Remove(1);
            Console.WriteLine("\nAfter removing count: {0}", linkedList.Count());

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }



        }
    }
}
