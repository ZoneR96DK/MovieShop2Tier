using System.Net;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopAdmin.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IManager<Address> _am = DllFacade.GetAddressManager();
        private readonly IManager<Customer> _cm = DllFacade.GetCustomerManager();

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = _am.Read();
            return View(addresses);
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = _am.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_cm.Read(), "Id", "FirstName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,StreetName,StreetNumber,City,PostalCode,Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                _am.Create(address);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_cm.Read(), "Id", "FirstName", address.Id);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = _am.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_cm.Read(), "Id", "FirstName", address.Id);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StreetName,StreetNumber,City,PostalCode,Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                _am.Update(address);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(_cm.Read(), "Id", "FirstName", address.Id);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = _am.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _am.Delete(id);
            return RedirectToAction("Index");
        }
    }
}