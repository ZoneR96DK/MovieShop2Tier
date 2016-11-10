using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Repositories
{
    internal class AddressRepository : AbstractRepository<Address>
    {
        private static AddressRepository _instance;

        private AddressRepository()
        {
        }

        public static AddressRepository Instance => _instance ?? (_instance = new AddressRepository());

        public override Address Create(MovieShopContext db, Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            return address;
        }

        public override Address Read(MovieShopContext db, int id)
        {
            return db.Addresses.Include(a => a.Customer).FirstOrDefault(x => x.Id == id);
        }

        public override List<Address> Read(MovieShopContext db)
        {
            return db.Addresses.Include(a => a.Customer).ToList();
        }

        public override Address Update(MovieShopContext db, Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return address;
        }

        public override void Delete(MovieShopContext db, int id)
        {
            db.Entry(db.Addresses.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}