namespace MusicStore.Services.Controllers
{   
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Data.Repositories;
    using MusicStore.Models;
    using MusicStore.Services.Models;

    public class SongsController : ApiController
    {
        private readonly IGenericRepository<Song> songs;

        public SongsController()
            :this(new GenericRepository<Song>())
        {
        }

        public SongsController(IGenericRepository<Song> songs)
        {
            this.songs = songs;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var allSongs = this.songs.All().Select(SongModel.FromSongs);
            return Ok(allSongs);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newSong = new Song()
            {
                Title = song.Title,
                Genre = song.Genre,
                Year = song.Year
            };

            this.songs.Add(newSong);
            this.songs.SaveChanges();

            song.SongId = newSong.SongId;
            return Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingSong = this.songs.All().FirstOrDefault(s => s.SongId == id);

            if (existingSong == null)
            {
                return this.BadRequest("No Song with matching id exists.");
            }

            existingSong.Title = song.Title;
            existingSong.Year = song.Year;
            existingSong.Genre = song.Genre;
            this.songs.SaveChanges();

            return this.Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.songs.All().FirstOrDefault(a => a.SongId == id);

            if (existingSong == null)
            {
                return this.BadRequest("No Artist with matching id exists.");
            }

            this.songs.Delete(existingSong);
            this.songs.SaveChanges();

            return this.Ok();
        }
    }
}