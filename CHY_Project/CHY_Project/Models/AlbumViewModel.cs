using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class AlbumViewModel
    {
        public Int32 id { get; set; }

        [Display(Name = "Album Name")]
        public String AlbumName { get; set; }

        //NOTE: Do albums have artists in their own right or do they have artists by virtue of the songs on them?

        public virtual List<Artist> Artists { get; set; }

        public virtual List<Song> Songs { get; set; }

        //TODO: Find datatype for album art
        [DataType(DataType.ImageUrl)]
        public string AlbumArt { get; set; }

        public Decimal RegularPrice { get; set; }

        public Decimal DiscountPrice { get; set; }
    }
}