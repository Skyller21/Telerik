namespace BitCalculator.Web.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext()
            : base("name=CalculatorDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(30, 5));
        }
        public virtual IDbSet<Unit> Units { get; set; }
    }
}