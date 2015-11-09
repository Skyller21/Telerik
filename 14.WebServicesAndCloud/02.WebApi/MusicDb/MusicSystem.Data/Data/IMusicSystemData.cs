namespace MusicSystem.Data.Data
{
    using Models;
    using Repositories;

    public interface IMusicSystemData
    {
        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Song> Songs { get; }

        void SaveChanges();

        void Dispose();
    }
}
