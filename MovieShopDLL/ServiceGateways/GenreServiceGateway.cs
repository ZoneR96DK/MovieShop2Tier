using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class GenreServiceGateway : AbstractServiceGateway<Genre>
    {
        private static GenreServiceGateway _instance;

        private GenreServiceGateway()
        {
        }

        public static GenreServiceGateway Instance => _instance ?? (_instance = new GenreServiceGateway());

        public override Genre Create(MovieShopContext db, Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();
            return genre;
        }

        public override Genre Read(MovieShopContext db, int id)
        {
            return db.Genres.FirstOrDefault(x => x.Id == id);
        }

        public override List<Genre> Read(MovieShopContext db)
        {
            return db.Genres.ToList();
        }

        public override Genre Update(MovieShopContext db, Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
            return genre;
        }

        public override void Delete(MovieShopContext db, int id)
        {
            db.Entry(db.Genres.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}