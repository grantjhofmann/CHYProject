using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Artist : Content
    {
        public Int32 ArtistID { get; set; }

        public String ArtistName { get; set; }

        public virtual List<Song> Songs { get; set; }

    }
}