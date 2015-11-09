
namespace _02.DataAccessObjectClass
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _01.NorthwindDbContext;

    class Startup
    {
        static void Main(string[] args)
        {
            // The other columns are nullable :)
            var customer = new Customer()
            {
                CustomerID = "TELRK",
                CompanyName = "Telerik Acedemy"
            };

            var customerModified = new Customer()
            {
                CustomerID = "TELRK",
                CompanyName = "Telerik Acedemy MODIFIED"
            };

            //InsertCustomer(customer);

            //ModifyCustomer(customerModified);

            //DeleteCustomer(customer);
        }


        public static void InsertCustomer(Customer customer)
        {
            var ctx = new NorthwindEntities();
            if (ctx.Customers.Any(c => c.CustomerID == customer.CustomerID))
            {
                Console.WriteLine("Already existing customer");
                return;
            }
            ctx.Customers.Add(customer);
            Console.WriteLine("Adding customer {0}", customer.CompanyName);
            ctx.SaveChanges();
        }

        public static void ModifyCustomer(Customer customer)
        {
            var ctx = new NorthwindEntities();
            var customerFound = ctx.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (customerFound == null)
            {
                Console.WriteLine("No such customer");
                return;
            }
            Console.WriteLine("Modifying customer {0}", customerFound.CompanyName);
            ctx.Customers.AddOrUpdate(customer);
            ctx.SaveChanges();
        }


        public static void DeleteCustomer(Customer customer)
        {
            var ctx = new NorthwindEntities();
            var customerFound = ctx.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (customerFound == null)
            {
                Console.WriteLine("No such customer");
                return;
            }
            Console.WriteLine("Deleting customer {0}", customerFound.CompanyName);
            ctx.Customers.Remove(customerFound);
            ctx.SaveChanges();
        }
    }
}
