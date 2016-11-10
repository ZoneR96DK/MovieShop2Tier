using System.Net;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopAdmin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IManager<Customer> _cm = DllFacade.GetCustomerManager();
        private readonly IManager<Movie> _mm = DllFacade.GetMovieManager();
        private readonly IManager<Order> _om = DllFacade.GetOrderManager();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = _om.Read();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_cm.Read(), "Id", "FirstName");
            ViewBag.MovieId = new SelectList(_mm.Read(), "Id", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,MovieId,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _om.Create(order);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_cm.Read(), "Id", "FirstName", order.CustomerId);
            ViewBag.MovieId = new SelectList(_mm.Read(), "Id", "Title", order.MovieId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(_cm.Read(), "Id", "FirstName", order.CustomerId);
            ViewBag.MovieId = new SelectList(_mm.Read(), "Id", "Title", order.MovieId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,MovieId,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                _om.Update(order);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_cm.Read(), "Id", "FirstName", order.CustomerId);
            ViewBag.MovieId = new SelectList(_mm.Read(), "Id", "Title", order.MovieId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _om.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _om.Delete(id);
            return RedirectToAction("Index");
        }
    }
}