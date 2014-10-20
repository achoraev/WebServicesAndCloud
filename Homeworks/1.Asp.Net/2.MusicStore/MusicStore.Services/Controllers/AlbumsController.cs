namespace MusicStore.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Models;
    using MusicStore.Data.Repositories;
    using MusicStore.Services.Models;

    public class AlbumsController : ApiController
    {
        private readonly IGenericRepository<Album> albums;

        public AlbumsController()
            :this(new GenericRepository<Album>())
        {
        }

        public AlbumsController(IGenericRepository<Album> albums)
        {
            this.albums = albums;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var allAlbums = this.albums.All().Select(AlbumModel.FromAlbum);
            return this.Ok(allAlbums);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAlbum = new Album()
            {
                Producer = album.Producer,
                Title = album.Title,
                Year = album.Year
            };

            this.albums.Add(newAlbum);
            this.albums.SaveChanges();

            album.AlbumId = newAlbum.AlbumId;
            return this.Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingAlbum = this.albums.All().FirstOrDefault(a => a.AlbumId == id);

            if (existingAlbum == null)
            {
                return this.BadRequest("No Album with matching id exists.");
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Year = album.Year;
            existingAlbum.Producer = album.Producer;
            
            this.albums.SaveChanges();

            return this.Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.albums.All().FirstOrDefault(a => a.AlbumId == id);

            if (existingArtist == null)
            {
                return this.BadRequest("No Artist with matching id exists.");
            }

            this.albums.Delete(existingArtist);
            this.albums.SaveChanges();

            return this.Ok();
        }
    }
}