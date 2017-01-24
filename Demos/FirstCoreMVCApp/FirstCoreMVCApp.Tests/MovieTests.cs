using FirstCoreMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FirstCoreMVCApp.Tests
{
    public class MovieTests
    {
        [Fact]
        public void CanChangeMovieTitle()
        {
            // Arrange
            var m = new Movie {Title = "Bahu Bali",
                ReleaseDate = new DateTime(2012,1,1) };
            const string title = "Three Idiots";
            // Act
            m.Title = title;
            //Assert
            Assert.Equal(title, m.Title);
        }

        [Fact]
        public void DoesHaveMovieActorsList()
        {
            // Arrange

            var m = new Movie();
            // Act - nothing to do
            // Assert
            Assert.Null(m.Actors);
        }

        [Fact]
        public void CanAddMovieActors()
        {
            // Arrange
            var m = new Movie();
            m.Actors = new List<string>();

            // Act
            m.Actors.Add("Tom Cruze");
            m.Actors.Add("Will Smith");

            // Assert
            Assert.Equal(m.Actors.Count, 2);
        }

        [Fact]
        public void IsRightAddMovieActors()
        {
            // Arrange
            var m = new Movie();
            m.Actors = new List<string>();

            // Act
            m.Actors.Add("Tom Cruze");
            m.Actors.Add("Will Smith");

            // Assert
            Assert.True(m.Actors[0] == "Tom Cruze" &&
                            m.Actors[1] == "Will Smith");
        }
    }
}
