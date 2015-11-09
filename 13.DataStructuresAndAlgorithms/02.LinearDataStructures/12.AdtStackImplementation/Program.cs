using System;

namespace _12.AdtStackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new AdtStack<int>();

            Console.WriteLine("Initial count: {0}", stack.Count());
            Console.WriteLine("Initial capacity: {0}", stack.Capacity);

            stack.Push(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(-4);
            Console.WriteLine("\nAfter add count: {0}", stack.Count());
            Console.WriteLine("After add enough elements to increase array capacity: {0}", stack.Capacity);
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nThe last element in the stack is: {0}", stack.Peek());

            stack.Pop();
            Console.WriteLine("\nAfter remove count: {0}", stack.Count());
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
