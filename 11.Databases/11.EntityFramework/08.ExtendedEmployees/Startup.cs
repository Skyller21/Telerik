using System;
using System.Linq;

namespace _08.ExtendedEmployees
{
    using _01.NorthwindDbContext;

    class Startup
    {
        static void Main(string[] args)
        {
            // The employee is extended. The class is partial and is in the 01.NorthwindDbContext project.
            using (var ctx = new NorthwindEntities())
            {
                var employee = ctx.Employees.FirstOrDefault();

                Console.WriteLine("Employee {0} categories:", employee.FirstName);

                foreach (var territory in employee.TerritoriesSet)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }
        }
    }
}
