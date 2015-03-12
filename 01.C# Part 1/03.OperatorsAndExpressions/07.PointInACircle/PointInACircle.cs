using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PointInACircle
{
    static void Main(string[] args)
    {
        double r = 2;
        bool check;

        Console.WriteLine("Enter X:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Y:");
        double y = double.Parse(Console.ReadLine());

        if ((Math.Pow(x, 2) + Math.Pow(y, 2)) > Math.Pow(r, 2))
        {
            check = false;
            Console.WriteLine("inside: {0}",check);
        }
        else
        {
            check = true;
            Console.WriteLine("inside: {0}",check);
        }
    }
}

