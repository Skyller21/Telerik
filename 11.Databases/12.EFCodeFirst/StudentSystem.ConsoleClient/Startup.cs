namespace StudentSystem.ConsoleClient
{
    using System.Linq;
    using Data;

    class Startup
    {
        static void Main()
        {
            var ctx = new StudentSystemContext();

            var students = ctx.Students.ToList();

            ctx.SaveChanges();
        }
    }
}
