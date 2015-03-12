using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumbersOneToN
{
    static void Main()
    {
        int number;
        bool check = true;

        do                                                              //This loop checks the input validity
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
            Console.WriteLine(i);
        }
    }
}

