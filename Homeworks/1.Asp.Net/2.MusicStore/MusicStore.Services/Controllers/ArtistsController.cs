namespace MusicStore.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Models;
    using MusicStore.Data.Repositories;
    using MusicStore.Services.Models;

    public class ArtistsController : ApiController
    {
        private readonly IGenericRepository<Artist> artists;

        public ArtistsController()
            : this(new GenericRepository<Artist>())
        {
        }

        public ArtistsController(IGenericRepository<Artist> artists)
        {
            this.artists = artists;
        }

        
        [HttpGet]
        public IHttpActionResult All()
        {
            var allArtists = this.artists.All().Select(ArtistModel.FromArtist);
            return this.Ok(allArtists);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newArtist = new Artist()
            {
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate
            };

            this.artists.Add(newArtist);
            this.artists.SaveChanges();

            artist.ArtistId = newArtist.ArtistId;
            return this.Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingArtist = this.artists.All().FirstOrDefault(a => a.ArtistId == id);

            if (existingArtist == null)
            {
                return this.BadRequest("No Artist with matching id exists.");
            }

            existingArtist.Name = artist.Name;
            existingArtist.Country = artist.Country;
            existingArtist.BirthDate = artist.BirthDate;
            this.artists.SaveChanges();

            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.artists.All().FirstOrDefault(a => a.ArtistId == id);

            if (existingArtist == null)
            {
                return this.BadRequest("No Artist with matching id exists.");
            }

            this.artists.Delete(existingArtist);
            this.artists.SaveChanges();

            return this.Ok();
        }

    }
}
