using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Trapezoids
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter lower side of trapezoid:");
        ushort a = ushort.Parse(Console.ReadLine());
        Console.WriteLine("Enter upper side of trapezoid:");
        ushort b = ushort.Parse(Console.ReadLine());
        Console.WriteLine("Enter height of trapezoid:");
        ushort h = ushort.Parse(Console.ReadLine());

        Console.WriteLine("The area of trapezoid is (({0}+{1})/2)*{2}={3}", a, b, h, (a + b) * h / 2);
    }
}

