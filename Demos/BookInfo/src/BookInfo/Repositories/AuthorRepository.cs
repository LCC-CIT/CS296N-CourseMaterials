using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class AuthorRepository : IAuthor
    {
        public List<Author> GetAllAuthorsAlphabetic()
        {
            // Temporary development implementation
            var authors = new List<Author>();
            authors.Add(new Author() { Name = "Jame Austen", Birthday = new DateTime(12, 16, 1775) });
            authors.Add(new Author() { Name = "William Shakespere", Birthday = new DateTime(4, 1, 1564) });
            return authors;
        }

        public Author GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
