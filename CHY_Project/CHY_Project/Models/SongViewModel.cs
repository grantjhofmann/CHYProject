using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
=======
using System.Linq;
using System.Web;
using CHY_Project.Models;
>>>>>>> origin/master

namespace CHY_Project.Models
{
    public class SongViewModel
    {
<<<<<<< HEAD
        public Int32 id { get; set; }
        [Display(Name = "Song Name")]
        public String SongName { get; set; }

        public virtual List<Artist> Artists { get; set; }

        public virtual Album Album { get; set; }

        public Decimal RegularPrice { get; set; }

        public Decimal DiscountPrice { get; set; }
=======
        public decimal AvgRating { get; set; }

        public virtual List<Song> Songs { get; set; }
        public virtual List<Rating> Ratings { get; set; }

>>>>>>> origin/master
    }
}