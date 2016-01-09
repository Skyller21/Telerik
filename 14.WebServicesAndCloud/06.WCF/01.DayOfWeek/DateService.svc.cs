namespace _01.DayOfWeek
{
    using System;
    using System.Globalization;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DateService : IDateService
    {
        private CultureInfo ci = new CultureInfo("bg-BG");
        public string GetDayOfWeek(DateTime date)
        {
            return date.ToString("dddd", ci);
        }

        public string GetTodayDay()
        {
            return DateTime.Now.ToString("DD", ci);
        }
    }
}
