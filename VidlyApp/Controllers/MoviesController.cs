using System.Collections.Generic;
using System.Web.Mvc;
using VidlyApp.ViewModels;
using VidlyApp.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Data.Entity.Validation;

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
        public ActionResult MovieForm()
        {
            var membershipTypes = _context.moviesTypes.ToList();
            var viewModel = new MovieTypesViewModel
            {
                MoviesTypes = membershipTypes,
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {

                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var cust = _context.Movies.Single(c => c.Id == movie.Id);
                cust.Name = movie.Name;
                cust.ReleasedDate = movie.ReleasedDate;
                cust.MoviesTypeId = movie.MoviesTypeId;
                cust.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieTypesViewModel
            {
                movie = movie,
                MoviesTypes = _context.moviesTypes.ToList()
            };
            return View("MovieForm", viewModel);
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