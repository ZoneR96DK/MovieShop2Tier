using System;
using System.Collections.Generic;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    public class RandomisedMovieManager
    {
        private static RandomisedMovieManager _instance;

        public static RandomisedMovieManager Instance => _instance ?? (_instance = new RandomisedMovieManager());

        private RandomisedMovieManager() { }

        public List<Movie> PickFiveRandomFilms()
        {
            using (var db = new MovieShopContext())
            {
                Random rnd = new Random();
                List<Movie> randomisedList = new List<Movie>();
                for (int i = 0; i< 5; i++)
                {
                    var fullList = db.Movies.ToList();
                    var count = fullList.Count();
                    var rndNr = rnd.Next(count);
                    var isRandomNumber = fullList.Skip(rndNr).FirstOrDefault();
                    if (randomisedList.Contains(isRandomNumber))
                    {
                        i--;
                    } else {
                    randomisedList.Add(isRandomNumber);
                    }
                }
                return randomisedList;
            }
        }
    }
}