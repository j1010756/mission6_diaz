using Microsoft.AspNetCore.Mvc;
using Mission6_Diaz.Models;
using System.Diagnostics;

namespace Mission6_Diaz.Controllers
{

    // inherits from controller class
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) //contructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        // get about page
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        // get form to fill out
        [HttpGet]
        public IActionResult Form()
        {
            // create viewbag to get category names from category table
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            // return view with the movie categories
            return View("Form", new Movie());
        }

        // post from form to db
        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to db
                _context.SaveChanges();

                // message if successful submit
                ViewData["SuccessMessage"] = "Form submitted successfully.";
                return View("Form", response);
            }
            else // invalid data
            {
                // create viewbag to get category names from category table
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                // return view with their inputs and error messages
                return View(response);
            }
        }

        public IActionResult MovieCollection()
        {
            // use linq to get info from database
            var movies = _context.Movies

                // order movies by title
                .OrderBy(x => x.Title).ToList();

            // past list into view so we see them
            return View(movies);
        }


        // get edit page
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // get single record we want to edit by id
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // return record
            return View("Form", recordToEdit);
        }

        // post method for editing
        [HttpPost]
        public IActionResult EditMovie(Movie updatedForm)
        {
            // update info
            _context.Update(updatedForm);

            // save change to db
            _context.SaveChanges();

            // redirect to movie collection
            return RedirectToAction("MovieCollection");
        }

        // get delete page
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            // get single record we want to delete by id
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            // return record
            return View(recordToDelete);
        }

        // post method for deleting
        public IActionResult DeleteConfirmation(Movie record)
        {
            // remove record
            _context.Movies.Remove(record);

            // confirm deletion
            _context.SaveChanges();

            // return user to movie collection
            return RedirectToAction("MovieCollection");
        }
    }
}
