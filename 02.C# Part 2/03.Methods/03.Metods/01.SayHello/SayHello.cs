using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SayHello
{
    class SayHello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string yourName = Console.ReadLine();
            TextInfo textInfo = new CultureInfo("bg-Bg", false).TextInfo;       //Makes the name with 
            yourName = textInfo.ToTitleCase(yourName);                          //first letter as capital.
            Console.WriteLine(new string('-',40));
            SayHelloMethod(yourName);
        }

        static void SayHelloMethod(string name)
        {
            Console.WriteLine("Hello, {0}!", name );
        }
    }
}
