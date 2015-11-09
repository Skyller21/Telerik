using System.Linq;
using System.Web.Http;

namespace MusicSystem.Server.Api.Controllers
{
    using Data.Data;
    using Data.Models;
    using DataTransferModels;
    using System.Web.Http.Cors;


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/artists")]
    public class ArtistsController : ApiController
    {
        private IMusicSystemData data;

        public ArtistsController()
        {
            this.data = new MusicSystemData();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Artists.All().ToList();
            return this.Ok(artists);
        }

        public IHttpActionResult GetById(int id)
        {
            return this.Ok(this.data.Artists.GetById(id));
        }

        public IHttpActionResult Post(ArtistRequestModel artist)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            this.data.Artists.Add(new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate,
            });

            this.data.SaveChanges();
            return this.Ok(artist.Name);
        }

        public IHttpActionResult Put(UpdateArtistRequestModel artistModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var artistFound = this.data.Artists.GetById(id);

            if (artistFound == null)
            {
                return this.NotFound();
            }

            artistFound.Name = artistModel.Name;
            artistFound.Country = artistModel.Country;

            this.data.SaveChanges();
            return this.Ok(id);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.data.Artists.GetById(id);
            this.data.Artists.Delete(artist);

            this.data.SaveChanges();

            return this.Ok();
        }

    }
}
