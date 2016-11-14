﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopRestApi.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IRepository<Movie> _mr = DllFacade.GetMovieRepository();

        // GET: api/Movies
        public List<Movie> GetMovies()
        {
            return _mr.Read();
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _mr.Read(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != movie.Id)
                return BadRequest("Ids do not match");

            var movieToTest = _mr.Read(id);
            if (movieToTest == null)
                return NotFound();

            _mr.Update(movie);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _mr.Create(movie);

            return CreatedAtRoute("DefaultApi", new {id = movie.Id}, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _mr.Read(id);
            if (movie == null)
                return NotFound();

            _mr.Delete(id);

            return Ok(movie);
        }
    }
}