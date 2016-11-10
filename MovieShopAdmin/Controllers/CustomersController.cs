using System.Net;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopAdmin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IManager<Address> _am = DllFacade.GetAddressManager();
        private readonly IManager<Customer> _cm = DllFacade.GetCustomerManager();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _cm.Read();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _cm.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName");
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cm.Create(customer);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _cm.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cm.Update(customer);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(_am.Read(), "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _cm.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cm.Delete(id);
            return RedirectToAction("Index");
        }
    }
}