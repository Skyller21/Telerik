// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
using System;
namespace _06.PrintASequence
{
    class PrintASequence
    {
        static void Main()
        {
            int[] numbers = new int[10];
            for (int number = 0; number < 10; number++)
            {
                if (number % 2 == 0) numbers[number] = number + 2;
                else numbers[number] = -(number + 2);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
