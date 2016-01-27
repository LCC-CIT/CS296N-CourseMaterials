using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreDemo1.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        List<Stack> stacks = new List<Stack>();

        public List<Stack> Stacks
        {
            get { return stacks; }
        }
    }
}