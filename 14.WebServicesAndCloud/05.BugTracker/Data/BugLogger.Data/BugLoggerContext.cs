namespace BugLogger.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class BugLoggerContext : IdentityDbContext<User>, IBugLoggerContext
    {
        public BugLoggerContext()
            : base("BugLogger", throwIfV1Schema: false)
        {
        }

        public IDbSet<Bug> Bugs { get; set; }

        public static BugLoggerContext Create()
        {
            return new BugLoggerContext();
        }
    }
}
