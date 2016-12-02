using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;

namespace CHY_Project.Controllers
{
    public class ReportsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SongReport()
        {
            List<SongReportViewModel> SongReportViewModels = new List<SongReportViewModel>();
            List<Song> songlist = db.Songs.ToList();
            foreach (Song song in db.Songs)
            {
                Int32 SaleCount;
                SaleCount = 0;

                Decimal TotalRevenue;
                TotalRevenue = 0.00m;
                List<OrderDetail> OrderDetails = db.OrderDetails.Where(x => x.Product.ContentID == song.ContentID).ToList();
                foreach(OrderDetail orderdetail in OrderDetails)
                {
                    SaleCount += 1;
                    TotalRevenue += orderdetail.ExtendedPrice;
                }

                SongReportViewModel songreport = new SongReportViewModel();
                songreport.SongName = song.SongName;
                songreport.Revenue = TotalRevenue;
                songreport.SalesCount = SaleCount;

                SongReportViewModels.Add(songreport);
            }
            ViewBag.SongReports = SongReportViewModels;

            return View();
        }

        public ActionResult AlbumReport()
        {
            List<AlbumReportViewModel> AlbumReportViewModels = new List<AlbumReportViewModel>();
            List<Album> albumlist = db.Albums.ToList();
            foreach (Album album in db.Albums)
            {
                Int32 SaleCount;
                SaleCount = 0;

                Decimal TotalRevenue;
                TotalRevenue = 0.00m;
                List<OrderDetail> OrderDetails = db.OrderDetails.Where(x => x.Product.ContentID == album.ContentID).ToList();
                foreach (OrderDetail orderdetail in OrderDetails)
                {
                    SaleCount += 1;
                    TotalRevenue += orderdetail.ExtendedPrice;
                }

                AlbumReportViewModel albumreport = new AlbumReportViewModel();
                albumreport.AlbumName = album.AlbumName;
                albumreport.Revenue = TotalRevenue;
                albumreport.SalesCount = SaleCount;

                AlbumReportViewModels.Add(albumreport);
            }
            ViewBag.AlbumReports = AlbumReportViewModels;

            return View();
        }
    }
}
