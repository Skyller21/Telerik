namespace BugLogger.Server.Api.App_Start
{
    using Data;
    using System.Data.Entity;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerContext, Configuration>());

            BugLoggerContext.Create().Database.Initialize(true);
        }

    }
}