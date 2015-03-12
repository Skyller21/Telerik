using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateNumberOfWorkdays
{
    static void Main()
    {
        DateTime startDate = DateTime.Today;
        DateTime endDate = Check();
        Console.WriteLine();
        int countDays = Days(endDate, startDate);
        int holidays = Holidays(endDate, startDate);
        Console.WriteLine("The working days between\n\rtoday\t{0:d} inclusive and\n\t{1:d} inclusive are: {2}", DateTime.Today.Date, endDate.Date, countDays - holidays);
        Console.WriteLine();
    }

    static DateTime Check()
    {
        bool check;
        DateTime endDate;
        do
        {
            Console.WriteLine("Enter the end date");
            check = DateTime.TryParse(Console.ReadLine(), out endDate);
        } while (!check);
        return endDate;
    }

    static int Holidays(DateTime endDate, DateTime startDate)
    {
        var holidays = new List<DateTime>();
        int holidaysToRemove = 0;
        holidays.Add(new DateTime(2015, 1, 1));
        holidays.Add(new DateTime(2015, 3, 1));
        holidays.Add(new DateTime(2015, 3, 2));
        holidays.Add(new DateTime(2015, 4, 10));
        holidays.Add(new DateTime(2015, 4, 13));
        holidays.Add(new DateTime(2015, 5, 1));
        holidays.Add(new DateTime(2015, 5, 6));
        holidays.Add(new DateTime(2015, 9, 21));
        holidays.Add(new DateTime(2015, 9, 22));
        holidays.Add(new DateTime(2015, 12, 24));
        holidays.Add(new DateTime(2015, 12, 25));
        

        for (int i = 0; i < holidays.Count(); i++)
        {
            if (holidays[i] <= endDate && holidays[i] >= startDate)
            {
                holidaysToRemove++;
            }
        }
        return holidaysToRemove;
    }

    static int Days(DateTime endDate, DateTime startDate)
    {
        var spanDays = (endDate - startDate).Days;
        DateTime dayCheck = startDate;
        int counterDays = 0;
        for (int i = 0; i <= spanDays; i++)
        {
            if (dayCheck.DayOfWeek != DayOfWeek.Saturday && dayCheck.DayOfWeek != DayOfWeek.Sunday)
            {
                counterDays++;
            }
           dayCheck = dayCheck.AddDays(1);
        }
        return counterDays;
    }
}

