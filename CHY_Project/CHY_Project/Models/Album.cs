using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Album : Product
    {
        public Int32 AlbumID { get; set;}

        public String AlbumName { get; set; }

        //NOTE: Do albums have artists in their own right or do they have artists by virtue of the songs on them?
        public virtual List<Artist> Artists { get; set; }

        public virtual List<Song> Songs { get; set; }

        //TODO: Find datatype for album art
        //public [DATATYPE] AlbumArt { get; set;}
        //look for image in seed
    }
}