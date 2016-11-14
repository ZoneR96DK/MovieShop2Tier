using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Repositories
{
    internal class CustomerRepository : AbstractRepository<Customer>
    {
        private static CustomerRepository _instance;

        private CustomerRepository()
        {
        }

        public static CustomerRepository Instance => _instance ?? (_instance = new CustomerRepository());

        public override Customer Create(MovieShopContext db, Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        public override Customer Read(MovieShopContext db, int id)
        {
            return db.Customers.Include(c => c.Address).FirstOrDefault(x => x.Id == id);
        }

        public override List<Customer> Read(MovieShopContext db)
        {
            return db.Customers.Include(c => c.Address).ToList();
        }

        public override Customer Update(MovieShopContext db, Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return customer;
        }

        public override void Delete(MovieShopContext db, int id)
        {

            db.Entry(db.Addresses.FirstOrDefault(y => y.Id == id)).State = EntityState.Deleted;
            db.Entry(db.Customers.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}