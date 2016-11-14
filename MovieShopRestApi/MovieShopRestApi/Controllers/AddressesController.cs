using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopRestApi.Controllers
{
    public class AddressesController : ApiController
    {
        private readonly IRepository<Address> _ar = DllFacade.GetAddressRepository();

        // GET: api/Addresses
        public List<Address> GetAddresses()
        {
            return _ar.Read();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            var address = _ar.Read(id);
            if (address == null)
                return NotFound();

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != address.Id)
                return BadRequest("Ids do not match");

            var addressToTest = _ar.Read(id);
            if (addressToTest == null)
                return NotFound();

            _ar.Update(address);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ar.Create(address);

            return CreatedAtRoute("DefaultApi", new {id = address.Id}, address);
        }

        // /DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            
            var address = _ar.Read(id);
            if (address == null)
                return NotFound();

            _ar.Delete(id);

            return Ok(address);
        }
    }
}