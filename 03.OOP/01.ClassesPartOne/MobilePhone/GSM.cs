using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class GSM
    {
        private List<Call> callHistory;
        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }


        private string model;
        private string make;
        private string owner;
        private decimal price;
        public Display Display { get; set; }
        public Battery Battery { get; set; }



        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Regex regex = new Regex("[^A-Za-zА-Яа-я- ]");
                    if (regex.IsMatch(value) || value.Length < 2)
                    {
                        throw new ArgumentException("#######The name should contains only letters and hyphen and should be longer than 1 character!");
                    }

                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    value = textInfo.ToTitleCase(value);
                    this.owner = value;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("######The price should be larger than 0!!!");
                }
                this.price = value;
            }
        }

        public GSM()
            : this(null, null, null, 0, null, null, new List<Call>())
        {

        }
        public GSM(string make, string model, decimal price)
        {
            this.Model = model;
            this.Make = make;
            this.Price = price;
        }
        public GSM(string make, string model, string owner)
        {
            this.Model = model;
            this.Make = make;
            this.Owner = owner;
        }
        public GSM(string make, string model, string owner, decimal price, Display display, Battery battery, List<Call> callHistory)
        {
            this.Model = model;
            this.Make = make;
            this.Owner = owner;
            this.Price = price;
            this.Battery = battery ?? new Battery();
            this.Display = display ?? new Display();
            this.CallHistory = callHistory;
        }

        public override string ToString()
        {
            return "Brand: " + (Make == null ? "N/A" : Make) +
                "\r\nModel: " + (Model == null ? "N/A" : Model) +
                "\r\nOwner: " + (Owner == null ? "N/A" : Owner) +
                "\r\nPrice: " + (Price == 0 ? "N/A" : Price.ToString() + "$");
        }

        private static GSM iPhone4S = new GSM("Apple", "iPhone 4s", "Batman", 500, null, null, new List<Call>());

        public static GSM IPhone4S
        {
            get
            {
                return GSM.iPhone4S;
            }
            set
            {
                GSM.iPhone4S = value;
            }
        }


        public void AddCall(Call callToAdd)
        {

            this.CallHistory.Add(callToAdd);
        }

        public void DeleteCall(int index)
        {
            this.CallHistory.RemoveAt(index);
        }

        public void DeleteAllHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculateCallPrice()
        {
            decimal totalPrice = 0;
            foreach (Call call in this.CallHistory)
            {
                totalPrice += call.Duration / 60 * call.PriceCall;
            }
            return totalPrice;
        }

        public Call FindLongestCall()
        {
            List<Call> list = this.CallHistory.OrderByDescending(x => x.Duration).ToList();

            return list[0];
        }

    }
}
