using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class LoanAccount:Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.CustomerType is IndividualCustomer)
            {
                if (months > 3)
                {
                    return base.CalculateInterest(months - 3);
                }
                    
                else
                {
                    return 0;
                }
            }
            else 
            {
                if (months > 2)
                {
                    return base.CalculateInterest(months - 2);
                }

                else
                {
                    return 0;
                }
                   
            }
            
        }

        
    }
}
