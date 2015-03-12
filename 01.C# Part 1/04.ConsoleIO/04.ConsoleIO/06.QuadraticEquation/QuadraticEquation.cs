using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("You have to input the coefficients \"a\" \"b\" and \"c\" of the quadratic equation \n\rax^2+bx+c=0");
        Console.WriteLine("Enter value of a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of c:");
        double c = double.Parse(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;
        double xOne = ((-b + Math.Sqrt(discriminant)) / (2 * a));
        double xTwo = ((-b - Math.Sqrt(discriminant)) / (2 * a));

        System.Console.WriteLine("The equation is {0}x^2{1}{2}x{3}{4}=0",a,b<0?"":"+",b,c<0?"":"+",c);
        System.Console.WriteLine(new string('-',40));
        if (discriminant > 0)
        {
            
            Console.WriteLine("Root x1 = {0}", xOne);
            Console.WriteLine("Root x2 = {0}", xTwo);
        }
        else
        {
            Console.WriteLine("There are no real roots!");
        }
        System.Console.WriteLine(new string('-', 40));
    }
}


