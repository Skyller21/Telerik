using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RandomNumbersInRange
{
    static void Main()
    {
        Console.WriteLine("Enter the numbers count to randomise");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the min bound of the range");
        int min = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the max bound of the range");
        int max = int.Parse(Console.ReadLine());

        Random randomise = new Random();

        Console.WriteLine("The randomised list of n numbers is:\n--------------------");
        for (int i = 1; i <= n; i++)
        {
            Console.Write(randomise.Next(min,max)+" ");
        }
        Console.WriteLine();
    }
}

