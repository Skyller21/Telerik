using System;

class SingleBankAccount
{
    static void Main()
    {
        /*
         Problem 11. Bank Account Data
            A bank account has a holder name (first name, middle name and last name), available amount of money (balance), 
            bank name, IBAN, 3 credit card numbers associated with the account.
            Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
         */
        string holderName = "Teodor Spaskov Nikolov";             
        string bankName = "Societe Generale Express bank";
        string iBAN = "BBTT123456789012345678";

        decimal? balance = null;  
        decimal accountNumber1 = 1234567812345678;
        decimal accountNumber2 = 1234567812345679;
        decimal accountNumber3 = 1234567812345670;

        balance = 1111111111.23M;

        Console.WriteLine(" Holder Name: " + holderName + "\n\n Balance: " + balance.GetValueOrDefault() +
            "\n\n Bank name: " + bankName + "\n\n IBAN: " + iBAN + 
            "\n\n Account nunber 1: " + accountNumber1 + "\n\n Account nunber 2: "
            + accountNumber2 + "\n\n Account nunber 3: " + accountNumber3);
        Console.WriteLine();

    }
}


