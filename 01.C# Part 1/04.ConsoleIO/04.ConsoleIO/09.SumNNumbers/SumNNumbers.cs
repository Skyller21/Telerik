using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumNNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements to be added:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the numbers");
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }
        Console.WriteLine(new string('-',40));
        Console.WriteLine("Sum = {0}",sum);
        Console.WriteLine(new string('-', 40));
    }
}


