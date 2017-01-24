using FirstCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstCoreMVCApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        public IActionResult ShowMovies()
        {
            var movie1 = new Movie();
            movie1.Title = "Armageddon";
            movie1.ReleaseDate = new System.DateTime(1998, 7, 1);
            movie1.Actors = new List<string>() {"Bruce Willis",
            "Ben Afflic", "Steve Bucemi", "Liv Taylor"};

            return View(movie1);
        }
    }
}
