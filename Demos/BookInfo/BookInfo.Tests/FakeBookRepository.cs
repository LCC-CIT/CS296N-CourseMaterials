using BookInfo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;

namespace BookInfo.Tests
{
    public class FakeBookRepository : IBookRepository
    {
        public Book GetBookByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
