using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class BookRepository : IBookRepository
    {
        Book book = new Book() { Title = "Lord of the Rings", Date = DateTime.Parse("1937") };
        

        public Book GetBookByTitle(string title)
        {
            return book;
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
