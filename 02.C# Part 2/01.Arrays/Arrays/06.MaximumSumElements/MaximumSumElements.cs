using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class MaximumSumElements
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of the array");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of elements to sum");
        int elements = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements of the array");
        List<int> list = new List<int>();

        for (int i = 0; i < size; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        List<int> list1 = list.OrderByDescending(x => x).ToList();

        int sum = 0;
        for (int i = 0; i < elements; i++)
        {
            sum += list1[i];
        }

        Console.WriteLine("The maximal sum of {0} elements in the array is: {1}",elements,sum);
    }
}
