using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NotDivisibleByThreeAndSeven
{
    static void Main()
    {
        int number;
        bool check = true;

        do
        {
            Console.WriteLine("Enter a positive integer");
            check = int.TryParse(Console.ReadLine(), out number);
            if (number <= 0)
            {
                check = false;
            }
        } while (!check);

        Console.WriteLine("\n-------------------");
        for (int i = 1; i <= number; i++)
        {
            if (i % 3 != 0 & i % 7 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}

