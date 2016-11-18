using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Content
    {
        public Int32 ContentID { get; set; }

        public virtual List<Genre> Genres { get; set;}

        public virtual List<Rating> Ratings { get; set; }

    }
}