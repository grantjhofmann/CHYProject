using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class Song : Product
    {
        public Int32 SongID { get; set; }

        public String SongName { get; set; }

        public virtual List<Artist> Artists { get; set;}
 
        public virtual Album Album { get; set; }
    }
}