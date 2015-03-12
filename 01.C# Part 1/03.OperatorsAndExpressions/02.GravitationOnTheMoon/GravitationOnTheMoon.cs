using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GravitationOnTheMoon
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your wieght in kg:");
        double weightOnEarth = double.Parse(Console.ReadLine());

        double weightOnMoon = weightOnEarth * 0.17;

        Console.WriteLine("Your weight on the Moon will be: {0}",weightOnMoon);
    }
}

