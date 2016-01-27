using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStoreDemo1.Models
{
    public class BookStoreDbInitializer :
        DropCreateDatabaseAlways<BookStoreDemoContext>
    {
        protected override void Seed(BookStoreDemoContext context)
        {
            Stack stack1 = new Stack { Location = "A1" };
            Book mobyDick =
                new Book { Title = "Moby Dick", Author = "Herman Melville" };
            Book readyPlayerOne =
                new Book { Title = "Ready Player One", Author = "Ernest Cline" };
            stack1.Books.Add(mobyDick);
            stack1.Books.Add(readyPlayerOne);
            context.Stacks.Add(stack1);

            base.Seed(context);
        }
    }
}