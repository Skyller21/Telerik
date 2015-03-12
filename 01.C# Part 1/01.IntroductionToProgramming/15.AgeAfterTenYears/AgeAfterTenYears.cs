using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AgeAfterTenYears
{
    static void Main(string[] args)
    {
        bool check = true;
        byte age;

        do                                                        //do-while loop 
        {
            Console.WriteLine("Enter your age now:");
            check = byte.TryParse(Console.ReadLine(), out age);    //Check if the string can be parsed
            if (age > 120)                                         //Check if the years now are bigger than 120 (you can change it if you like)
            {
                check = false;
            }
        } while (!check);

        Console.WriteLine("After 10 years you'll be {0} years old\n", age + 10); //Prints your age after ten years
    }
}

