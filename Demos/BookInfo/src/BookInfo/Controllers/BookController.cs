using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepo;

        public BookController(IBookRepository repo)
        {
            bookRepo = repo;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(bookRepo.GetAllBooks());
        }
    }
}
