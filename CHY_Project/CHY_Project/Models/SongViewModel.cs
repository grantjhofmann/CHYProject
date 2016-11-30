using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHY_Project.Models;

namespace CHY_Project.Models
{
    public class SongViewModel
    {
        public decimal AvgRating { get; set; }

        public virtual List<Song> Songs { get; set; }
        public virtual List<Rating> Ratings { get; set; }

    }
}