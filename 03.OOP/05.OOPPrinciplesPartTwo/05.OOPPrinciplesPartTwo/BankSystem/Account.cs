using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Account:IDepositable
    {
        private Customer customerType;
        private decimal balance;
        private decimal interestRate;


        public Account(Customer customer,decimal balance, decimal interestRate)
        {
            this.CustomerType = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        public Customer CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The interest rate must not be negative value");
                }
                interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months == 0)
            {
                return 0;
            }
            return (months*this.interestRate*this.Balance)/100;
        }

        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw  new ArgumentException("You cannot deposit 0 or negative ammount of money");
            }
            this.Balance += money;
        }
    }
}
