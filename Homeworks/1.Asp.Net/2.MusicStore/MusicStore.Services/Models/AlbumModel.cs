using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MusicStore.Services.Models
{
    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel
                {
                    Title = a.Title,
                    Producer = a.Producer,
                    Year = a.Year
                };
            }
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}