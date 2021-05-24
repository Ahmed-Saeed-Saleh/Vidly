using System.Collections.Generic;
using System.Web.Mvc;
using VidlyApp.ViewModels;
using VidlyApp.Models;
using System.Data.Entity;
using System.Linq;

namespace VidlyApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieType).ToList();
            return View(movies);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        public ActionResult Details(int id )
        {
            var movie = _context.Movies.Include(c=>c.MovieType).SingleOrDefault(c=>c.Id==id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

    }
}