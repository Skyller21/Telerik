using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Circle
{
    static void Main()
    {
        Console.WriteLine("Enter the radius of a circle:");
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("The perimeter of the circle is: {0}", 2 * Math.PI * r);
        Console.WriteLine("The area of the circle is: {0}", Math.PI * r * r);
    }
}


