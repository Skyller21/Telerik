namespace BitCalculator.Web.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BitCalculator.Web.Data.CalculatorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BitCalculator.Web.Data.CalculatorDbContext context)
        {
            if (!context.Units.Any())
            {
                var unitsList = new List<Unit>()
                {
                    new Unit()
                    {
                        Type="bit",
                        BitValue = 1m,
                        CalculatedValue = 1m,
                        Symbol = "b"
                    },
                    new Unit()
                    {
                        Type="Byte",
                        BitValue = 8m,
                        CalculatedValue = 8m,
                        Symbol = "B"
                    },
                    new Unit()
                    {
                        Type="Kilobit",
                        BitValue = 1000m,
                        CalculatedValue = 1000m,
                        Symbol = "Kb"
                    },
                    new Unit()
                    {
                        Type="Kilobyte",
                        BitValue = 8000m,
                        CalculatedValue = 8000m,
                        Symbol = "KB"
                    },
                    new Unit()
                    {
                        Type="Megabit",
                        BitValue = 1000000m,
                        CalculatedValue = 1000000m,
                        Symbol = "Mb"
                    },
                    new Unit()
                    {
                        Type="Megabyte",
                        BitValue =  8000000m,
                        CalculatedValue =  8000000m,
                        Symbol = "MB"
                    },
                    new Unit()
                    {
                        Type="Gigabit",
                        BitValue = 1000000000m,
                        CalculatedValue = 1000000000m,
                        Symbol = "Gb"
                    },
                    new Unit()
                    {
                        Type="Gigabyte",
                        BitValue = 8000000000m,
                        CalculatedValue = 8000000000m,
                        Symbol = "GB"
                    },
                    new Unit()
                    {
                        Type="Terabit",
                        BitValue = 1000000000000m,
                        CalculatedValue = 1000000000000m,
                        Symbol = "Tb"
                    },
                    new Unit()
                    {
                        Type="Terabyte",
                        BitValue =  8000000000000m,
                        CalculatedValue =  8000000000000m,
                        Symbol = "TB"
                    },
                    new Unit()
                    {
                        Type="Petabit",
                        BitValue = 1000000000000000m,
                        CalculatedValue = 1000000000000000m,
                        Symbol = "Pb"
                    },
                    new Unit()
                    {
                        Type="Petabyte",
                        BitValue = 8000000000000000m,
                        CalculatedValue = 8000000000000000m,
                        Symbol = "PB"
                    },
                    new Unit()
                    {
                        Type="Exabit",
                        BitValue =  1000000000000000000m,
                        CalculatedValue =  1000000000000000000m,
                        Symbol = "Eb"
                    },
                    new Unit()
                    {
                        Type="Exabyte",
                        BitValue =  8000000000000000000m,
                        CalculatedValue =  8000000000000000000m,
                        Symbol = "EB"
                    }
                };

                foreach (var unit in unitsList)
                {
                    context.Units.Add(unit);
                }

                context.SaveChanges();
            }
        }
    }
}
