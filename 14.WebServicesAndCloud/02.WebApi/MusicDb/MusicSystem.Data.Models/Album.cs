using System;
using System.Collections.Generic;

namespace MusicSystem.Data.Models
{
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? YearOfRelease { get; set; }

        public string Producer { get; set; }

        public ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }
    }
}
