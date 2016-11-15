using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class CustomerServiceGateway : AbstractServiceGateway<Customer>
    {
        private static CustomerServiceGateway _instance;

        private CustomerServiceGateway()
        {
        }

        public static CustomerServiceGateway Instance => _instance ?? (_instance = new CustomerServiceGateway());

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
            db.Entry(db.Customers.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}