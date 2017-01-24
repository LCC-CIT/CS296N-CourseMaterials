using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LambdaDemo
{
	class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
	}

	class Program
	{
		// Can get a book by using the search method which is passed in as an argument
		static Book GetBook(string searchParam, List<Book> books, Func<string, List<Book>, Book> search)
		{
			return search(searchParam, books);
		}

		static void Main(string[] args)
		{
			List<Book> books = new List<Book>  {
			new Book() {Title = "Book1", Author = "Auth1", Year = 2013},
			new Book() {Title = "Book2", Author = "Auth2", Year = 2010},
			new Book() {Title = "Book3", Author = "Auth3", Year = 1900},
			};

			Book bookFound = GetBook("Book2", books,
				(title, bookList) =>
				{
					foreach (Book b in books)
						if (b.Title == title)
							return b;
					return null;
				});
		}
	}
}