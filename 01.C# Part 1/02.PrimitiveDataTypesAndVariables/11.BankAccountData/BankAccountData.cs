using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BankAccountData
{
    static void Main(string[] args)
    {
        string holderName = "Santa Claus";
        uint amountMoney = 24593498;
        string bankName = "UniCredit Bulbank";
        string iban = "BG010203040506****";
        string bic = "BGUNCRSF";
        string creditCardOne = "12345678000000000";
        string creditCardTwo = "12345678111111111";
        string creditCardThree = "12345678222222222";
        Console.WriteLine("Name: {0}", holderName);
        Console.WriteLine("Balance: {0}", amountMoney);
        Console.WriteLine("Bank: {0}", bankName);
        Console.WriteLine("IBAN: {0}", iban);
        Console.WriteLine("BIC: {0}", bic);
        Console.WriteLine("Card 1: {0}", creditCardOne);
        Console.WriteLine("Card 2: {0}", creditCardTwo);
        Console.WriteLine("Card 3: {0}\n", creditCardThree);
    }
}

