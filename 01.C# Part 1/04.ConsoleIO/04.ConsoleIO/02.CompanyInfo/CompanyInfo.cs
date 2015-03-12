using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Adress:");
        string companyAdress = Console.ReadLine();
        Console.WriteLine("Phone number:");
        string companyPhone = Console.ReadLine();
        Console.WriteLine("Fax:");
        string companyFax = Console.ReadLine();
        Console.WriteLine("Web site:");
        string companyWeb = Console.ReadLine();
        Console.WriteLine("Manager first name:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Manager last name:");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Age:");
        string managerAge = Console.ReadLine();
        Console.WriteLine("Manager phone:");
        string managerPhone = Console.ReadLine();

        string dashes = new string('-', 30);
        string stars = new string('*', 30);
        Console.WriteLine("\n\r\n\rCOMPANY INFORMATION");
        Console.WriteLine(dashes);
        Console.WriteLine("Company name: {0}\n\rAdress: {1}\n\rPhone number: {2}\n\rFax number: {3}\n\rWeb site: {4}\n\r",
            companyName, companyAdress, companyPhone, companyFax, companyWeb);
        Console.WriteLine(stars);
        Console.WriteLine("\n\rMANAGER INFORMATION");
        Console.WriteLine(dashes);
        Console.WriteLine("Manager name: {0} {1}\n\rAge: {2}\n\rPhone number: {3}\n\r", managerFirstName,managerLastName, managerAge, managerPhone);



    }
}

