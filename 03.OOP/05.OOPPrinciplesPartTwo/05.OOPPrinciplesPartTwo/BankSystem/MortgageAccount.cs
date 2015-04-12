using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class MortgageAccount:Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.CustomerType is IndividualCustomer)
            {
                if (months > 6)
                {
                    return base.CalculateInterest(months - 6);
                }
                    
                else
                {
                    return 0;
                }
            }
            else 
            {
                if (months < 12)
                {
                    return base.CalculateInterest(months)/2;
                }
                else
                {
                    return base.CalculateInterest(12)/2 + base.CalculateInterest(months - 12);
                }
                   
            }
            
        }

    }
}
