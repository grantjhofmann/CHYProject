using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class SongDetailsViewModel
    {
        public Int32 ContentID { get; set; }

        [Display(Name = "Song Name")]
        public String SongName { get; set; }

        public Decimal RegularPrice { get; set; }

        public Decimal DiscountPrice { get; set; }

        public Boolean Featured { get; set; }

        public List<Artist> Artists { get; set; }

        //TODO: make this a list if we get around to fixing the m->m relationship b/w song and album
        public Album Album { get; set; }

        public List<Genre> Genres { get; set; }

        //[Required(ErrorMessage = "You must give a rating to submit.")]
        [Range(1, 5, ErrorMessage = "Your rating must be a whole number between one and five.")]
        public String Stars { get; set; }

        public String Comment { get; set; }

        public Content Item { get; set; }

        public AppUser Customer { get; set; }

        public SongDetailsViewModel()
        {
            Genres = new List<Genre>();
            Artists = new List<Artist>();
        }
    }
}