﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopRestApi.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IRepository<Customer> _cr = DllFacade.GetCustomerRepository();

        // GET: api/Customers
        public List<Customer> GetCustomers()
        {
            return _cr.Read();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _cr.Read(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != customer.Id)
                return BadRequest("Ids do not match");

            var customerToTest = _cr.Read(id);
            if (customerToTest == null)
                return NotFound();

            _cr.Update(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _cr.Create(customer);

            return CreatedAtRoute("DefaultApi", new {id = customer.Id}, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _cr.Read(id);
            if (customer == null)
                return NotFound();

            _cr.Delete(id);

            return Ok(customer);
        }
    }
}