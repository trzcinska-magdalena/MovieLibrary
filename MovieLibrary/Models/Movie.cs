﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Runtime { get; set; }
        public string Language { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string DVD { get; set; }
        public string Released { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string Poster { get; set; }
    }
}
