using System;

namespace ConsoleClient
{
    using DateServiceTest;

    class Startup
    {
        static void Main(string[] args)
        {
            using (var client = new DateServiceClient())
            {

                var dayBefore10Days = client.GetDayOfWeek(DateTime.Now.AddDays(-10));

                var dayToday = client.GetTodayDay();


                Console.WriteLine($"Денят преди 10 дена е бил {dayBefore10Days}.");
                Console.WriteLine($"Днес е {dayToday}.");
            }
        }
    }
}
