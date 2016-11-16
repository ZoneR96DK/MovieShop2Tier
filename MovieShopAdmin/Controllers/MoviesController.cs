using System.Net;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopAdmin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IServiceGateway<Genre> _gm = DllFacade.GetGenreServiceGateway();
        private readonly IServiceGateway<Movie> _mm = DllFacade.GetMovieServiceGateway();

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _mm.Read();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_gm.Read(), "Id", "Name");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _mm.Create(movie);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(_gm.Read(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(_gm.Read(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _mm.Update(movie);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_gm.Read(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _mm.Delete(id);
            return RedirectToAction("Index");
        }
    }
}