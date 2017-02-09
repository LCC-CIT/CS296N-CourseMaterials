using BookInfo.Controllers;
using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookInfo.Tests
{
    public class BookTests
    {
        [Fact]
        // Test BookController getting a list of authors
        public void DoesGetBooks()
        {
            // Arrange
            var repository = new FakeBookRepository();
            BookController controller = new BookController(repository);

            // Act
            var books = controller.Index().ViewData.Model as List<Book>;

            // Assert
            Assert.Equal(repository.GetAllBooks()[0].Title,
                books[0].Title);
            Assert.Equal(repository.GetAllBooks()[0].Date,
                books[0].Date);
            Assert.Equal(repository.GetAllBooks()[0].Authors,
                books[0].Authors);
            Assert.Equal(repository.GetAllBooks()[1].Title,
                books[1].Title);
            Assert.Equal(repository.GetAllBooks()[1].Date,
                books[1].Date);
            Assert.Equal(repository.GetAllBooks()[1].Authors,
                books[1].Authors);
        }
    }
}
