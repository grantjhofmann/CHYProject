using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHY_Project.Models
{
    public class Rating
    {
        public Int32 RatingID { get; set; }

        [Required]
        public virtual AppUser Customer { get; set; }

        //[Required (ErrorMessage = "You must comment on why you gave this rating")]
        //public String Comment { get; set; }

        //TODO: Finalize decision on Starcount datatype
        public enum Stars { one, two, three, four, five }

        [Required (ErrorMessage ="You must actually give a rating to submit.")]
        [Range(1,5, ErrorMessage = "Your rating must be a whole number between one and five.")]
        public Stars Starcount { get; set; }

        [Required]
        public virtual Content Content { get; set; }
    }
}