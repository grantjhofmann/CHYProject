using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CHY_Project.Models
{
    public class Genre
    {

        [Key]
        public Int32 GenreID { get; set; }

        [Required]
        public String GenreName { get; set; }

        public virtual List<Content> Contents { get; set; }
    }
}