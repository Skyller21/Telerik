using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class CompanyCustomer:Customer
    {
        private string companyID;
        private BusinessSector businessSector;

        public CompanyCustomer(string name,string address,string companyID, BusinessSector businessSector):base(name,address)
        {
            this.CompanyID = companyID;
            this.businessSector = businessSector;
        }

        public BusinessSector Sector
        {
            get { return this.businessSector; }
            set { this.businessSector = value; }
        }

        public string CompanyID
        {
            get { return this.companyID; }
            set { this.companyID = value; }
        }
    }
}
