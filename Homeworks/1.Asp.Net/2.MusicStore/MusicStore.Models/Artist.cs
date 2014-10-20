using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}