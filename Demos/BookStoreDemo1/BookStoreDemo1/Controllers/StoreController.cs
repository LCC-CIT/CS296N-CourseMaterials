using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreDemo1.Models;

namespace BookStoreDemo1.Controllers
{
    public class HomeController : Controller
    {
        Store store = new Store();

        public HomeController()
        {
            Stack stack1 = new Stack {Location="A1"};
            Book mobyDick = 
                new Book { Title = "Moby Dick", Author = "Herman Melville" };
            Book readyPlayerOne = 
                new Book { Title = "Ready Player One", Author = "Ernest Cline" };
            stack1.Books.Add(mobyDick);
            stack1.Books.Add(readyPlayerOne);
            store.Stacks.Add(stack1);
        }

        //
        // GET: /Store/
        public ActionResult Index()
        {
            ViewBag.Heading = "Welcome to Our Book Store!";
            return View();
        }

        public ActionResult Inventory()
        {
            List<Book> books = store.Stacks[0].Books;
            return View(books);
        }
	}
}