using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CheckIfTheYearIsLeap
{
    static void Main()
    {
        Console.WriteLine("Enter the year you want to check:");
        int year = int.Parse(Console.ReadLine());
        bool checkLeap = DateTime.IsLeapYear(year);
        if (checkLeap)
        {
            Console.WriteLine("The year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", year);
        }
        
    }
}

