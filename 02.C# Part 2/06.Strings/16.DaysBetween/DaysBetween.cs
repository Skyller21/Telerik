using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DaysBetween
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter the first date: (DD.MM.YYYY)");
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Enter the second date: (DD.MM.YYYY)");
            DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            TimeSpan daysBetween = (secondDate - firstDate);
            
            Console.WriteLine("The days between the two dates are: {0}",daysBetween.TotalDays);
        }
        catch (FormatException)
        {
            Console.WriteLine("The date is in wrong format!\n\rPlease enter the date in DD.MM.YYYY format");
            Console.WriteLine();
            Main();
        }
    }
}

