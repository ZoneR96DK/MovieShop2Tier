using System.Collections.Generic;
using MovieShopDLL.Context;

namespace MovieShopDLL.Repositories
{
    internal abstract class AbstractRepository<T> : IRepository<T>
    {
        public T Create(T item)
        {
            using (var db = new MovieShopContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var addedItem = Create(db, item);
                db.SaveChanges();
                return addedItem;
            }
        }

        public T Read(int id)
        {

            using (var db = new MovieShopContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Read(db, id);
            }
        }

        public List<T> Read()
        {
            using (var db = new MovieShopContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Read(db);
            }
        }

        public T Update(T item)
        {
            using (var db = new MovieShopContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Update(db, item);
            }
        }

        public void Delete(int id)
        {
            using (var db = new MovieShopContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                Delete(db, id);
            }
        }

        public abstract T Create(MovieShopContext db, T item);

        public abstract T Read(MovieShopContext db, int id);

        public abstract List<T> Read(MovieShopContext db);

        public abstract T Update(MovieShopContext db, T item);

        public abstract void Delete(MovieShopContext db, int id);
    }
}