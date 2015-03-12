using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


class PrintMyName
{
    static void Main(string[] args)
    {
        Console.Title = "Print Name";
        
        //Console.WriteLine("Enter your last name: ");
        bool check = true;
        string firstName;
        bool isDigitInName = true;

        do                                                                 //This do-while loop checks if the inputed name is correct
        {                                                                  //(does not contain numbers or is minimum 2 characters long)                     
            Console.WriteLine("Enter your first name: ");
            firstName = Console.ReadLine();
            isDigitInName = firstName.Any(c => char.IsDigit(c));
            if (firstName.Length >= 2 & isDigitInName == false)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        } while (!check);

        TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
        Console.WriteLine("\nYour name is: {0} (Nickname: The Ninja Warrior)\n", myTI.ToTitleCase(firstName)); //Makes the first letter capital (TitleCase)
    }
}
