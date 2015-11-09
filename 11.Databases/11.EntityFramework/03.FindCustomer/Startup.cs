namespace _03.FindCustomer
{
    using System;
    using System.Linq;
    using _01.NorthwindDbContext;

    class Startup
    {
        private const int YearOfOrder = 1997;
        private const string ShippedToCountry = "Canada";

        static void Main(string[] args)
        {
            Console.WriteLine("With LINQ");
            GetOrdersWithLinq(YearOfOrder, ShippedToCountry);
            Console.WriteLine("===================");
            Console.WriteLine("With native SQL query");
            GetOrdersWIthNativeQuery(YearOfOrder, ShippedToCountry);
        }

        private static void GetOrdersWIthNativeQuery(int yearOfOrder, string shippedToCountry)
        {
            var ctx = new NorthwindEntities();

            var ordersListNativeSql = ctx.Database.SqlQuery<OrderDTO>(@"SELECT c.CompanyName, o.OrderID FROM CUSTOMERS c
                                                                        JOIN Orders o 
                                                                        ON c.CustomerID = o.CustomerID 
                                                                        WHERE YEAR(o.OrderDate) = " + yearOfOrder +
                                                                        @"AND o.ShipCountry = '" + shippedToCountry + "'");

            ordersListNativeSql.ToList()
                .ForEach(ol => Console.WriteLine(string.Format("OrderID: {0} - Customer: {1}", ol.OrderId, ol.CompanyName)));
        }

        private static void GetOrdersWithLinq(int yearOfOrder, string shippedToCountry)
        {
            var ctx = new NorthwindEntities();

            var ordersList =
                ctx.Orders.Where(o => o.OrderDate.Value.Year == yearOfOrder && o.ShipCountry == shippedToCountry)
                    .Select(o => new
                    {
                        o.OrderID,
                        o.Customer.CompanyName
                    });

            ordersList.ToList()
                .ForEach(ol => Console.WriteLine(string.Format("OrderID: {0} - Customer: {1}", ol.OrderID, ol.CompanyName)));
        }
    }
}
