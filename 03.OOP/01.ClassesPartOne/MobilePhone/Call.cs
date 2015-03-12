using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        private readonly decimal CallPricePerMinute = 0.37M;
        private DateTime date;

        public decimal PriceCall
        {
            get { return CallPricePerMinute; }
        }

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }
        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            private set { time = value; }
        }
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            private set
            {
                Regex regex = new Regex("\\+*\\d{3,}|([Pp]rivate [Nn]umber)");
                if (!regex.Match(value).Success)
                {
                    throw new ArgumentOutOfRangeException("The phone must be at least 3 digits");
                }
                phoneNumber = value;
            }
        }
        private int duration;

        public int Duration
        {
            get { return duration; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The duration must not be negative number");
                }
                duration = value;
            }
        }

        public Call()
        {

        }

        public Call(DateTime date, DateTime time, string phoneNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

    }
}
