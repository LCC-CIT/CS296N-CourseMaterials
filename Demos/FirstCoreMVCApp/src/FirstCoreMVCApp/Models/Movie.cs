using System;
using System.Collections.Generic;

namespace FirstCoreMVCApp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Actors { get; set; }
    }
}
