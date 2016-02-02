﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreDemo1.Models;

namespace BookStoreDemo1.Controllers
{
    public class BooksController : Controller
    {
        private BookStoreDemoContext db = new BookStoreDemoContext();

        // GET: /Books/
        public ActionResult Index()
        {
            
            return View(GetStacksAndBooks(0));
        }

        // GET: /Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BookViewModel book = GetStacksAndBooks(id).FirstOrDefault();
            BookViewModel book = GetBookandStack(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Books/Create
        public ActionResult Create()
        {
            ViewBag.StackLocations = 
                new SelectList(db.Stacks.OrderBy(s => s.Location), "StackID", "Location");

            return View();
        }

        // POST: /Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BookID,Title,Author,Price,ISBN, StackItem, StackLocations")] BookViewModel bookVM, int StackLocations)
        {
            if (ModelState.IsValid)
            {
                Stack stack = (from s in db.Stacks
                               where s.StackID == StackLocations
                               select s).FirstOrDefault();

                //TODO: Modify the view allow entering a new location
                if(stack == null)
                {
                    stack = new Stack() { Location = bookVM.StackItem.Location };
                    db.Stacks.Add(stack);
                }

                Book book = new Book()
                {
                    Author = bookVM.Author,
                    BookID = bookVM.BookID,
                    ISBN = bookVM.ISBN,
                    Price = bookVM.Price,
                    StackID = stack.StackID,
                    Title = bookVM.Title
                };
                
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookVM);
        }

        // GET: /Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BookID,Title,Author,Price,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Pass zero for all books, or an id for one book
        private List<BookViewModel> GetStacksAndBooks(int? bookId)
        {
            var books = new List<BookViewModel>();

            var stacks = from stack in db.Stacks.Include("Books")
                select stack;
       
            foreach (Stack s in stacks)
            {
                foreach (Book b in s.Books)
                {
                    if (b.BookID == bookId || 0 == bookId)
                    {
                        var bookVm = new BookViewModel();
                        bookVm.Author = b.Author;
                        bookVm.BookID = b.BookID;
                        bookVm.Title = b.Title;
                        bookVm.ISBN = b.ISBN;
                        bookVm.Price = b.Price;
                        bookVm.StackItem = s;
                        books.Add(bookVm);
                    }
                }
            }
            return books;
        }

        private BookViewModel GetBookandStack(int? bookId)
        {
            BookViewModel bookVM = (from b in db.Books
                                    join s in db.Stacks on b.StackID equals s.StackID
                                    where b.BookID == bookId
                                    select new BookViewModel {
                                        BookID = b.BookID,
                                        Author = b.Author,
                                        ISBN = b.ISBN,
                                        Price = b.Price,
                                        Title = b.Title,
                                        StackItem = s
                                    }).FirstOrDefault();
            return bookVM;
        }
    }
}