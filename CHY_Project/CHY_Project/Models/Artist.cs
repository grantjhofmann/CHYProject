using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CHY_Project.Models
{
    public class Artist : Content
    {
        [Key]
        public String ArtistID { get; set; }

        [Required]
        [Display(Name ="Artist Name")]
        public String ArtistName { get; set; }

        
        public virtual List<Song> Songs { get; set; }
        
        
        [Display(Name ="Albums")]
        public virtual List<Album> Albums { get; set; }
    }
}