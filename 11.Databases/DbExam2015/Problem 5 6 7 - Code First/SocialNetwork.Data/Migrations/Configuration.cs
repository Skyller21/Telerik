namespace SocialNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetwork.Data.SocialNetworkContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Make it false when deploying
            this.AutomaticMigrationDataLossAllowed = false;

            // ContextKey = "SocialNetwork.Data.SocialNetworkContext";
        }

        protected override void Seed(SocialNetwork.Data.SocialNetworkContext context)
        {
        }
    }
}
