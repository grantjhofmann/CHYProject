using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHY_Project.Models
{
    public class AlbumReportViewModel
    {
        public String AlbumName { get; set; }
        public Decimal Revenue { get; set; }
        public Int32 SalesCount { get; set; }
    }

    public class SongReportViewModel
    {
        public String SongName { get; set; }
        public Decimal Revenue { get; set; }
        public Int32 SalesCount { get; set; }
    }

    public class GenreReportViewModel
    {

    }
}