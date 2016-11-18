using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Rating
    {
        public Int32 RatingID { get; set; }

        public virtual AppUser Customer { get; set; }

        public String Comment { get; set; }

        //TODO: Finalize decision on Starcount datatype
        public enum Stars { one, two, three, four, five }

        public Stars Starcount { get; set; }

        public virtual Content Content { get; set; }
    }
}