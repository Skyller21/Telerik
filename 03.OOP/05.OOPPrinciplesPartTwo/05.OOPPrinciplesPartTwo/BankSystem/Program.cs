using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer customer = new CompanyCustomer();
            
            CompanyCustomer customer = new CompanyCustomer("Philips","Munich","Main company address",BusinessSector.Other);

            DepositAccount account = new DepositAccount(customer, 12132358.47M,5M);
            Console.WriteLine(account.Balance);
            Console.WriteLine( account.CalculateInterest(14) );
            account.Deposit(100000M);
            Console.WriteLine(account.Balance);
            account.Withdraw(500000M);
            Console.WriteLine(account.Balance);
            
        }
    }
}
