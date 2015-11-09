
namespace _05.FindAllSales
{
    using System;
    using System.Linq;
    using _01.NorthwindDbContext;

    internal class Startup
    {
        private const string Region = "NM";
        private static readonly DateTime StartDate = new DateTime(1998, 05, 05);
        private static readonly DateTime EndDate = new DateTime(1999, 05, 05);

        private static void Main(string[] args)
        {
            AllOrders(Region, StartDate, EndDate);
        }

        public static void AllOrders(string region, DateTime start, DateTime end)
        {
            var ctx = new NorthwindEntities();

            ctx.Orders.Where(o => o.ShipRegion == region &&
                                  o.OrderDate > start &&
                                  o.OrderDate < end)
                .Select(o => new
                {
                    o.OrderID,
                    o.ShipRegion,
                    o.OrderDate
                })
                .ToList()
                .ForEach(
                    o =>
                        Console.WriteLine(string.Format("ID: {0}, Region: {1}, Date: {2}", o.OrderID,
                            o.ShipRegion ?? "N/A", o.OrderDate.Value.ToShortDateString())));
        }
    }
}
