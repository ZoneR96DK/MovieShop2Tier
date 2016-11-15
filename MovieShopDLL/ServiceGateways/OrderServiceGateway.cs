using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class OrderServiceGateway : AbstractServiceGateway<Order>
    {
        private static OrderServiceGateway _instance;

        private OrderServiceGateway()
        {
        }

        public static OrderServiceGateway Instance => _instance ?? (_instance = new OrderServiceGateway());

        public override Order Create(MovieShopContext db, Order order)
        {
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