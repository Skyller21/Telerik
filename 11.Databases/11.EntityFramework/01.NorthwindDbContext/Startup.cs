using System;
using System.Linq;

namespace _01.NorthwindDbContext
{
    class Startup
    {
        static void Main(string[] args)
        {
            var ctx = new NorthwindEntities();

            ctx.Categories.Select(c => c.CategoryName).ToList().ForEach(Console.WriteLine);
        }
    }
}
