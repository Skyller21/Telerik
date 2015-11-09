
namespace _07.ConcurrentChanges
{
    using System.Linq;
    using _01.NorthwindDbContext;

    class Startup
    {
        static void Main(string[] args)
        {
            // The second saved context will override the first saved one. In this case PESHO is the master. :D
            // You can use pessimistic concurrency to be sure that the user will see the changes in the db.
            // You can use transactions in order to be sure that everything is consistent.
            var ctx1 = new NorthwindEntities();

            ctx1.Customers.FirstOrDefault().CompanyName = "GOSHO";

            var ctx2 = new NorthwindEntities();

            ctx2.Customers.FirstOrDefault().CompanyName = "PESHO";


            ctx1.SaveChanges();
            ctx2.SaveChanges();

        }
    }
}
