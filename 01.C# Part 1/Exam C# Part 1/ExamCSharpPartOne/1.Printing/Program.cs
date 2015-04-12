using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Printing
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal students = decimal.Parse(Console.ReadLine());
            decimal papers = decimal.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            decimal realmSheets = 500;

            decimal realms = (decimal)(students * papers) / realmSheets;

            Console.WriteLine("{0:F2}",students*papers/500*price);

        }
    }
}
