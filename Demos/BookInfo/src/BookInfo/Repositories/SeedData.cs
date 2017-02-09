using BookInfo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Books.Any())
            {
                Author author = new Author { Name = "J. R. R. Tolkien" };
                context.Authors.Add(author);
                Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937") }; // month/day/year
                book.Authors.Add(author);
                context.Books.Add(book);

                book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                book.Authors.Add(new Author { Name = "C. S. Lewis" });
                context.Books.Add(book);

                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                book.Authors.Add(new Author { Name = "Samuel Shellabarger" });
                context.Books.Add(book);
            }
        }
    }
}
