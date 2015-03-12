using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumFiveNumbers
{
    static void Main()
    {
        double sum = 0;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter number {0}",i+1);
            double n = double.Parse(Console.ReadLine());
            sum += n;
        }
        Console.WriteLine("Sum = {0}", sum);


    }
}


