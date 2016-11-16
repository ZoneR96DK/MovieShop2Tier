using System;
using System.Collections.Generic;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Logic
{
    public class MovieRandomizer
    {
        private static MovieRandomizer _instance;

        public static MovieRandomizer Instance => _instance ?? (_instance = new MovieRandomizer());

        private MovieRandomizer() { }

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