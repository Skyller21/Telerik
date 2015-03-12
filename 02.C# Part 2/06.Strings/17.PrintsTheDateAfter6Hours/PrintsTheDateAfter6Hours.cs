using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintsTheDateAfter6Hours
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter the first date: (DD.MM.YYYY HH:mm:ss) 24hour format");
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime added = firstDate.AddHours(6.5);
            string dayOfWeek = added.ToString("dddd", new CultureInfo("bg-BG"));

            Console.WriteLine("The date and time after 6 and a half hours will be: {0}, {1}",added,dayOfWeek);
        }
        catch (FormatException)
        {
            Console.WriteLine("The date is in wrong format!\n\rPlease enter the date in DD.MM.YYYY format");
            Console.WriteLine();
            Main();
        }
    }
}


