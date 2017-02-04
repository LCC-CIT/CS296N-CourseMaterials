
using BookInfo.Controllers;
using BookInfo.Models;
using System.Collections.Generic;
using Xunit;

namespace BookInfo.Tests
{
    public class AuthorTests
    {
        public AuthorTests()
        {
        }

        [Fact]
        // Test AuthorController getting a list of authors
        public void DoesGetAuthors()
        {
            // Arrange
            FakeAuhtorRepository repository = new FakeAuhtorRepository();
            HomeController controller = new HomeController(repository);

            // Act
            List<Author> authors = controller.Authors().ViewData.Model as List<Author>;

            // Assert
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[0].Name,
                authors[0].Name);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[0].Birthday,
                authors[0].Birthday);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[1].Name,
                authors[1].Name);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[1].Birthday,
                authors[1].Birthday);

        }
    }

}
