using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rectangle
{
    static double width;
    static double height;
    static void Main(string[] args)
    {
        Console.WriteLine("Input the weight of the rectangle:");
        width = double.Parse(Console.ReadLine());
        Console.WriteLine("Input the height of the rectangle:");
        height = double.Parse(Console.ReadLine());

        double perimeterOfRectangle = 2 * (width + height);
        double areaOfRectangle = width * height;

        Console.WriteLine("The area of the rectangle is: {0}cm^2", areaOfRectangle);
        Console.WriteLine("The perimeter of the rectangle is : {0}cm", perimeterOfRectangle);
    }
}

