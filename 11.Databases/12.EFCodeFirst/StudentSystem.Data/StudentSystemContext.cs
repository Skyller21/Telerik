namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}