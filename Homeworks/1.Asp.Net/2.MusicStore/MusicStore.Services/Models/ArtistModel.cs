namespace MusicStore.Services.Models
{
    using MusicStore.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    Name = a.Name,
                    Country = a.Country,
                    BirthDate = a.BirthDate
                };
            }
        }

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}