using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DivideBySevenAndFive
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input a number to see if it is dividable into 7 and 5 at the same time:");
        int numberToCheck = int.Parse(Console.ReadLine());

        if (numberToCheck%5==0 && numberToCheck%7==0)
        {
            Console.WriteLine("The number {0} is divideable to 5 and 7 at the same time without reminder",numberToCheck);
        }
        else
        {
            Console.WriteLine("The number {0} is NOT divideable to 5 and 7 at the same time without reminder", numberToCheck);
        }
    }
}

