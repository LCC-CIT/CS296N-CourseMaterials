using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStoreDemo1.Models
{
    // public class BookStoreDbInitializer : DropCreateDatabaseAlways<BookStoreDemoContext>
    public class BookStoreDbInitializer : DropCreateDatabaseIfModelChanges<BookStoreDemoContext>    
    {
        protected override void Seed(BookStoreDemoContext context)
        {
            Book mobyDick =
                new Book { Title = "Moby Dick", Author = "Herman Melville", Price = 11.99m };
            Book readyPlayerOne =
                new Book { Title = "Ready Player One", Author = "Ernest Cline", Price = 14.00m };
            Stack stack1 = new Stack { Location = "A1" };
            stack1.Books.Add(mobyDick);
            stack1.Books.Add(readyPlayerOne);

            Book grapesOfWrath =
                new Book { Title = "The Grapes of Wrath", Author = "John Steinbeck", Price = 12.49m };
            Book incorrigibleChildren =
                new Book { Title = "The Incorrigible Children of Ashton Place", Author = "Maryrose Wood", Price = 10.89m };
            Stack stack2 = new Stack { Location = "A2" };
            stack2.Books.Add(grapesOfWrath);
            stack2.Books.Add(incorrigibleChildren);

            context.Stacks.Add(stack1);
            context.Stacks.Add(stack2);

            base.Seed(context);
        }
    }
}