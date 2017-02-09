using BookInfo.Controllers;
using BookInfo.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookInfo.Tests
{
    public class BookTests
    {
        FakeBookRepository repository;
        BookController controller;
        List<Book> booksFromRepo;

        public BookTests()
        {
            // There is no state stored in the controller, so we can
            // do the arrange step once for all tests
            repository = new FakeBookRepository();
            booksFromRepo = repository.GetAllBooks().ToList();
            controller = new BookController(repository);
        }

        [Fact]
        // Test BookController getting a list of authors
        public void DoesGetBooks()
        {
            // Act
            var books = controller.Index().ViewData.Model as List<Book>;

            // Assert
            for (int i = 0; i < booksFromRepo.Count; i++ )
            {
                Assert.Equal(booksFromRepo[i].Title,
                    books[i].Title);
                Assert.Equal(booksFromRepo[i].Date,
                    books[i].Date);
                Assert.Equal(booksFromRepo[i].Authors,
                    books[i].Authors);
            }
        }

        [Fact]
        public void DoesGetBookByTitle()
        {
            // act
            var book = controller.BookByTitle("Lord of the Rings").ViewData.Model as Book;

            // assert
            var bookFromRepo = booksFromRepo[0];
            Assert.Equal(bookFromRepo, book);
        }

        [Fact]
        public void DoesGetAuthorsOfBook()
        {

            // act
            var authors = controller.AuthorsOfBook(booksFromRepo[1]).ViewData.Model as List<Author>;

            // assert
            var authorsFromRepo = booksFromRepo[1].Authors;
            Assert.Equal(authorsFromRepo, authors);
        }
    }
}
