namespace Exam.Web.Api
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());

            TeleimotDbContext.Create().Database.Initialize(true);
        }
    }
}