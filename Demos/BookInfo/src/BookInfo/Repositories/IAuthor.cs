using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Repositories
{
    public interface IAuthor
    {
        List<Author> GetAuthorsByBook(Book book);
        List<Author> GetAllAuthorsAlphabetic();
        Author GetAuthorByName(string name);
    }
}
