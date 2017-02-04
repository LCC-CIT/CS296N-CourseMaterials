using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfo.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorRepository authorRepo;

        public HomeController(IAuthorRepository repo)
        {
             authorRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Authors()
        {
            var repo = new AuthorRepository();
            var authors = repo.GetAllAuthorsAlphabetic();
            return View(authors);
        }
    }
}
