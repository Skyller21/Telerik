
namespace _06.NorthwindTwin
{
    using _01.NorthwindDbContext;

    class Startup
    {
        static void Main(string[] args)
        {
            // Change "initial catalog=Northwind" to "initial catalog=NorthwindTwin" in App.congif file
            var ctx = new NorthwindEntities();

            ctx.Database.CreateIfNotExists();
        }
    }
}
