using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class DepositAccount:Account,IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }

        public void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("You cannot withdraw 0 or negative ammount of money");
            }
            this.Balance -= money;
        }
    }
}
