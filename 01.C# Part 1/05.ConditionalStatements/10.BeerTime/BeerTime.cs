using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BeerTime
{
    static void Main()
    {
        Console.WriteLine("Enter a time in the format \"hh:mm tt\"");
        DateTime time;
        

        bool check = DateTime.TryParse(Console.ReadLine(), out time);
        DateTime timeStart = new DateTime(time.Year, time.Month, time.Day, 13, 00, 00);
        DateTime timeEnd = new DateTime(time.Year, time.Month, time.Day, 03, 00, 00);

        
        if (check)
        {
            if (time.CompareTo(timeStart) == -1 & time.CompareTo(timeEnd) == 1)
            {
                Console.WriteLine("non-beer time");
            }
            else
            {
                Console.WriteLine("beer time");
            }
        }
        else
        {
            Console.WriteLine("non-valid time");
        }
    }
}

