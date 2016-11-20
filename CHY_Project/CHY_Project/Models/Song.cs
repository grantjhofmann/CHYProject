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
        public Int32 SongID { get; set; }

        [Required]
        public String SongName { get; set; }

        [Required]
        public virtual List<Artist> Artists { get; set;}
        

        public virtual Album Album { get; set; }
    }
}