namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CodeFirst.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ForumDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ForumDbContext context)
        {
        }
    }
}