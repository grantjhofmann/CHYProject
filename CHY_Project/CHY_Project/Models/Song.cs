using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class Song : Product
    {
        [Key]
        public String SongID { get; set; }

        [Required]
        [Display(Name ="Song Name")]
        public String SongName { get; set; }

        [Required]
        public virtual List<Artist> Artists { get; set;}

        public virtual Album Album { get; set; }

        public Song()
        {
            Genres = new List<Genre>();
            Artists = new List<Artist>();
        }
    }
}