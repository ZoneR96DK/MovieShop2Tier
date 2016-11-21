using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Repositories
{
    internal class OrderRepository : AbstractRepository<Order>
    {
        
        private static OrderRepository _instance;

        private OrderRepository()
        {
        }

        public static OrderRepository Instance => _instance ?? (_instance = new OrderRepository());
        

        public override Order Create(MovieShopContext db, Order order)
        {
            //db.Entry(order.Customer).State = EntityState.Unchanged;
            //db.Entry(order.Movie).State = EntityState.Unchanged;
            //db.Entry(order.Customer.Address).State = EntityState.Unchanged;

            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        public override Order Read(MovieShopContext db, int id)
        {
            return db.Orders.Include(o => o.Movie).Include(o => o.Customer).FirstOrDefault(x => x.Id == id);
        }

        public override List<Order> Read(MovieShopContext db)
        {
            return db.Orders.Include(o => o.Movie).Include(o => o.Customer).ToList();
        }

        public override Order Update(MovieShopContext db, Order order)
        {
            db.Entry(order.Customer).State = EntityState.Unchanged;
            db.Entry(order.Movie).State = EntityState.Unchanged;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return order;
        }

        public override void Delete(MovieShopContext db, int id)
        {
            db.Entry(db.Orders.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}