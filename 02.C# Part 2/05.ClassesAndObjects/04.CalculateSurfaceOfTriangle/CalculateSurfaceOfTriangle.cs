using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateSurfaceOfTriangle
{
    static void Main()
    {
        Console.WriteLine("Enter side of the triangle");
        double side = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter altitude to the side of the triangle");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine( "The area of the triangle is: {0}",Triangle.CalculateAreaOfTriangle(side, height));
        Console.WriteLine();

        Console.WriteLine("Enter side A of the triangle");
        double sideA = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side B of the triangle");
        double sideB = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side C of the triangle");
        double sideC = double.Parse(Console.ReadLine());
        Console.WriteLine("The area of the triangle is: {0}", Triangle.CalculateAreaOfTriangle(sideA,sideB,sideC));
        Console.WriteLine();

        Console.WriteLine("Enter side A of the triangle");
        double sideA1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side B of the triangle");
        double sideB1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side the angle between the sides");
        float angleAB = float.Parse(Console.ReadLine());
        Console.WriteLine("The area of the triangle is: {0}", Triangle.CalculateAreaOfTriangle(sideA1, sideB1, angleAB));

    }
}

class Triangle
{
    public static double CalculateAreaOfTriangle(double side, double height)
    {
        double area = side * height / 2;
        return area;
    }

    public static double CalculateAreaOfTriangle(double sideA, double sideB, double sideC)
    {
        double p = (sideA+sideB+sideC)/2;
        double area = Math.Sqrt(p*(p-sideA)*(p-sideB)*(p-sideC));
        return area;
    }

    public static double CalculateAreaOfTriangle(double sideA, double sideB, float angleAB)
    {
        
        double area = sideA*sideB*Math.Sin(angleAB*Math.PI/180)/2;
        return area;
    }
}

