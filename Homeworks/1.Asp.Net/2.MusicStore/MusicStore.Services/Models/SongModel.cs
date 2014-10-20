using MusicStore.Models;
using System;
using System.Linq.Expressions;

namespace MusicStore.Services.Models
{
    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSongs
        {
            get
            {
                return s => new SongModel
                {
                    Title = s.Title,
                    Genre = s.Genre,
                    Year = s.Year
                };
            }
        }

        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
    }
}