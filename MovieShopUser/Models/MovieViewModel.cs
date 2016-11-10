using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    //RandomMovies = List of 5 movies on the top of the index page
    //MoviesForTable = List for movies in table
    //Genres = Filter need
    public class MovieViewModel
    {
        public List<Movie> RandomMovies { get; set; }
        public PagedList.IPagedList<Movie> MoviesForTable { get; set; }
        public List<Genre> Genres { get; set; }
    }
}