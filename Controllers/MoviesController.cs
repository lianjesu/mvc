using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyLJ.Models;
using StudyLJ.ViewModel;
using System.Data.Entity;

namespace StudyLJ.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        //GET: Movies
        public ActionResult Index()
        {
            var movies = this._context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        //GET: Movies/Details/{id}
        public ActionResult Details(int id)
        {
            var movie = this._context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            
            if (movie == null)
                return HttpNotFound();
            
            return View(movie);
        }

        /*
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new{ page=1,sortBy="name" });
        }


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        public ActionResult Random(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        */
    }
}