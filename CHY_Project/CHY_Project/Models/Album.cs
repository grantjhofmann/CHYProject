using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class Album : Product
    {
        public Int32 AlbumID { get; set;}

        [Required]
        [Display(Name ="Album Name")]
        public String AlbumName { get; set; }

        //NOTE: Do albums have artists in their own right or do they have artists by virtue of the songs on them?
        [Required]
        public virtual List<Artist> Artists { get; set; }

        public virtual List<Song> Songs { get; set; }

        //TODO: Find datatype for album art
        [DataType (DataType.ImageUrl)]
        public string AlbumArt { get; set;}
        //look for image in seed
    }
}