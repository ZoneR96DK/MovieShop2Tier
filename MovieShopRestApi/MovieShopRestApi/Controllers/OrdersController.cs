using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopRestApi.Controllers
{
    public class OrdersController : ApiController
    {
        private IRepository<Order> _or = DllFacade.GetOrderRepository();
        
        // GET: api/Orders
        public List<Order> GetOrders()
        {
            return _or.Read();
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = _or.Read(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            Order orderToTest = _or.Read(id);
            if (orderToTest == null)
            {
                return NotFound();
            }

            _or.Update(order);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _or.Create(order);

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = _or.Read(id);
            if (order == null)
            {
                return NotFound();
            }

            _or.Delete(id);

            return Ok(order);
        }

        
    }
}