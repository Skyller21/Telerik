namespace MusicSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class MusicSystemContext : IdentityDbContext<User>, IMusicSystemContext
    {
        public MusicSystemContext()
                 : base("name=MusicSystemContext", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

     
        public static MusicSystemContext Create()
        {
            return new MusicSystemContext();
        }

    }
}