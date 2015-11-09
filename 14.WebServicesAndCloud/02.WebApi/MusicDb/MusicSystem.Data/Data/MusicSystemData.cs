using System;
using System.Collections.Generic;

namespace MusicSystem.Data.Data
{
    using Models;
    using Repositories;

    public class MusicSystemData : IMusicSystemData
    {
        private IMusicSystemContext context;
        private IDictionary<Type, object> repositories;

        public MusicSystemData()
            : this(new MusicSystemContext())
        {
        }

        public MusicSystemData(IMusicSystemContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public IRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public IRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
        }

        public IRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(EfGenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
