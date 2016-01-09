namespace BullsAndCows.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BullsAndCows.Data.BullsAndCowsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BullsAndCows.Data.BullsAndCowsDbContext context)
        {

        }
    }
}
