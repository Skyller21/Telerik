namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;
    using SocialNetwork.Data.Migrations;

    public class SocialNetworkContext : DbContext
    {
        // Your context has been configured to use a 'SocialNetworkContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SocialNetwork.Data.SocialNetworkContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SocialNetworkContext' 
        // connection string in the application configuration file.
        public SocialNetworkContext()
            : base("name=SocialNetworkContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<SocialNetworkContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}