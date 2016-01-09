namespace Exam.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TeleimotDbContext : IdentityDbContext<User>, ITeleimotDbContext
    {
        public TeleimotDbContext()
            : base("DefaultConnection", false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasRequired(r => r.RatedUser).WithMany(u => u.ReceivedRatings);
            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }
    }
}