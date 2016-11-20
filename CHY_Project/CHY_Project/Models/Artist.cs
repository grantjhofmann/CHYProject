using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CHY_Project.Models
{
    public class Artist : Content
    {
        public Int32 ArtistID { get; set; }

        [Required]
        [Display(Name ="Artist Name")]
        public String ArtistName { get; set; }

        [Required]
        public virtual List<Song> Songs { get; set; }
        
        [Required]
        [Display(Name ="Albums")]
        public virtual List<Album> Albums { get; set; }
    }
}