using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopRestApi.Controllers
{
    public class GenresController : ApiController
    {
        private readonly IRepository<Genre> _gr = DllFacade.GetGenreRepository();

        // GET: api/Genres
        public List<Genre> GetGenres()
        {
            return _gr.Read();
        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _gr.Read(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != genre.Id)
                return BadRequest("Ids do not match");

            _gr.Update(genre);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _gr.Create(genre);

            return CreatedAtRoute("DefaultApi", new {id = genre.Id}, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = _gr.Read(id);
            if (genre == null)
                return NotFound();

            _gr.Delete(id);

            return Ok(genre);
        }
    }
}