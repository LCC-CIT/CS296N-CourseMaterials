using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookByTitle(string title);
        List<Book> GetBooksByAuthor(Author author);
        List<Author> GetAuthorsByBook(Book book);
    }
}
