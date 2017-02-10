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

                author = new Author { Name = "C. S. Lewis" };
                context.Authors.Add(author);
                book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                book.Authors.Add(author);
                context.Books.Add(book);

                author = new Author { Name = "Samuel Shellabarger" };
                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                context.Authors.Add(author);
                book.Authors.Add(author);
                context.Books.Add(book);

                author = new Author() { Name = "Jame Austen", Birthday = new DateTime(1775, 12, 16) };
                context.Authors.Add(author);
                author = new Author() { Name = "William Shakespere", Birthday = new DateTime(1564, 4, 1) };
                context.Authors.Add(author);

                author = new Author() { Name = "Kathy Sierra" };
                context.Authors.Add(author);
                book = new Book { Title = "Head First Design Patterns", Date = DateTime.Parse("10/1/2004") };
                book.Authors.Add(author);
                author = new Author() { Name = "Eric Freeman" };
                context.Authors.Add(author);
                book.Authors.Add(author);
                author = new Author() { Name = "Bert Bates" };
                context.Authors.Add(author);
                book.Authors.Add(author);
                context.Books.Add(book);

                context.SaveChanges();
            }
        }
    }
}
