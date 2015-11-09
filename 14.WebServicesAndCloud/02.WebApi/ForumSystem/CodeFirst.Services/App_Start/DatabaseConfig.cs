namespace CodeFirst.Services
{
    using Data;
    using System.Data.Entity;
    using CodeFirst.Data;
    using CodeFirst.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());

            // Only when creating db
            ForumDbContext.Create().Database.Initialize(true);
        }
    }
}