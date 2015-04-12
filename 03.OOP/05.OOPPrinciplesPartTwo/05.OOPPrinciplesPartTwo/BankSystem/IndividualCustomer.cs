using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class IndividualCustomer:Customer
    {
        private string sociaID;

        public IndividualCustomer(string name, string address, string socialID) : base(name, address)
        {
            this.SociaID = socialID;
        }

        public string SociaID
        {
            get { return this.sociaID; }
            set { this.sociaID = value; }
        }
    }
}
