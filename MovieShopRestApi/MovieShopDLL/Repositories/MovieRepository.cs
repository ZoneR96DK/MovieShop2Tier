using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Repositories
{
    internal class MovieRepository : AbstractRepository<Movie>
    {
        private static MovieRepository _instance;

        private MovieRepository()
        {
        }

        public static MovieRepository Instance => _instance ?? (_instance = new MovieRepository());

        public override Movie Create(MovieShopContext db, Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return movie;
        }

        public override Movie Read(MovieShopContext db, int id)
        {
            return db.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == id);
        }

        public override List<Movie> Read(MovieShopContext db)
        {
            return db.Movies.Include(m => m.Genre).ToList();
        }

        public override Movie Update(MovieShopContext db, Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return movie;
        }

        public override void Delete(MovieShopContext db, int id)
        {
            db.Entry(db.Movies.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}