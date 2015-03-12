using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PointInsideCircleOutsideRectangle
{
    static void Main()
    {
        double r = 1.5;

        Console.WriteLine("Enter X:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Y:");
        double y = double.Parse(Console.ReadLine());
        string answer=" ";

        bool insideCircle = ((Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2)) <= Math.Pow(r, 2));

        bool insideRectangle = (((x >= -1) && (x <= 5)) && ((y >= -1) && (y <= 1)));

        if (insideCircle && insideRectangle)
        {
            answer = "no";
        }

        else if ((insideCircle == false) && (insideRectangle))
        {
            answer = "no";
        }

        else if ((insideCircle) && (insideRectangle == false))
        {
            answer = "yes";
        }

        else if ((insideCircle == false) && (insideRectangle == false))
        {
            answer = "no";
        }

        Console.WriteLine("Inside K & outside of R: {0}\n", answer);

        Main();         //This executes the Main method again.
    }
}

