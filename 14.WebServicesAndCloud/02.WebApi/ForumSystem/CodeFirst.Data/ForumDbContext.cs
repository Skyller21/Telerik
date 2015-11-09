namespace CodeFirst.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
        using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models.ServiceModels;

    public class ForumDbContext : IdentityDbContext<User>, IForumDbContext
    {
        public ForumDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
            modelBuilder.Entity<Tag>().Property(x => x.Text).IsUnicode(true);
            modelBuilder.Entity<Tag>().Property(x => x.Text).HasMaxLength(255);
            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<PostAnswer> PostAnswers { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }
        
        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }
    }
}
