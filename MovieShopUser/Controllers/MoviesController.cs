using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopDLL.ServiceGateways;
using MovieShopUser.Models;
using PagedList;

namespace MovieShopUser.Controllers
{
    public class MoviesController : Controller
    {
        private int NUMBER_OF_TABLE_ITEMS_PER_PAGE = 5;
        private IServiceGateway<Movie> _mm = DllFacade.GetMovieManager();
        private IServiceGateway<Genre> _gm = DllFacade.GetGenreManager();

        // GET: Movie
        // Paged site with search filter and genre filter. This also get data for 5 random films displayed on the top of the page.
        public ActionResult Index(string sortOrder ,string searchString, string currentFilter, int? page, int? genreId)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentSort = searchString;
            List<Movie> movies = _mm.Read();
            
            int pageSize = NUMBER_OF_TABLE_ITEMS_PER_PAGE;
            int pageNumber = (page ?? 1);

            
            RandomisedMovieManager randomMovieManager = RandomisedMovieManager.Instance;
            var movieViewModel = new MovieViewModel()
            {
                RandomMovies = randomMovieManager.PickFiveRandomFilms(),
                Genres = _gm.Read()
            };

            if (!String.IsNullOrEmpty(searchString))
            {
                var stringFilter = movies.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToPagedList(pageNumber, pageSize);
                movieViewModel.MoviesForTable = stringFilter;
                if(genreId != null) { 
                    movieViewModel.MoviesForTable = stringFilter.Where(x => x.Genre.Id == genreId.Value).ToPagedList(pageNumber, pageSize);
                }
                return View(movieViewModel);
            }
            if (genreId != null)
            {
                movieViewModel.MoviesForTable = _mm.Read().Where(x => x.Genre.Id == genreId.Value).ToPagedList(pageNumber, pageSize);
                return View(movieViewModel);
            }
            movieViewModel.MoviesForTable = _mm.Read().ToPagedList(pageNumber, pageSize);
            return View(movieViewModel);
        }

        // GET: Movie/Details/5
        //GET method for Details.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
    }
}
