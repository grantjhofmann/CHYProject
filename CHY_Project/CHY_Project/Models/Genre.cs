using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }

        public String GenreName { get; set; }

        public virtual List<Content> Contents { get; set; }
    }
}