using Microsoft.AspNetCore.Mvc;
using Mission6_Diaz.Models;
using System.Diagnostics;

namespace Mission6_Diaz.Controllers
{

    // inherits from controller class
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext temp) //contructor
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
            return View();
        }

        // post from form to db
        [HttpPost]
        public IActionResult Form(Application response)
        {
            _context.Movies.Add(response); // add record to db
            _context.SaveChanges();

            // message if successful submit
            ViewData["SuccessMessage"] = "Form submitted successfully.";
            return View("Form", response);
        }
    }
}
