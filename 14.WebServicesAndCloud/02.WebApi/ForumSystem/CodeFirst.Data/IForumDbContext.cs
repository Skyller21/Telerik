namespace CodeFirst.Data
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IForumDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<PostAnswer> PostAnswers { get; set; }

        IDbSet<Tag> Tags { get; set; }
        
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
