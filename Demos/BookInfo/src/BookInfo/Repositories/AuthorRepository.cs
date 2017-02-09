using System;
using System.Collections.Generic;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> GetAllAuthors()
        {
            // Temporary development implementation
            var authors = new List<Author>();
            authors.Add(new Author() { Name = "Jame Austen", Birthday = new DateTime(1775, 12, 16) });
            authors.Add(new Author() { Name = "William Shakespere", Birthday = new DateTime(1564,4, 1) });
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
