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

        public ActionResult GenreReport()
        {
            List<Genre> Genres = db.Genres.ToList();
            List<GenreReportViewModel> TopArtists = new List<GenreReportViewModel>();
            foreach(Genre genre in Genres)
            {
                List<Artist> Artists = db.Artists.ToList();
                
                GenreReportViewModel TopArtist = new GenreReportViewModel();
                foreach (Artist artist in Artists)
                {
                    if (artist.Genres.Contains(genre))
                    {
                        int songpurchases = 0;
                        int albumpurchases = 0;
                        decimal songrevenue = 0.00m;
                        decimal albumrevenue = 0.00m;
                        decimal totalrevenue = 0.00m;
                        GenreReportViewModel artistinstance = new GenreReportViewModel();
                        List<Song> SongsByArtist = db.Songs.Where(x => x.Artists.Contains(artist)).ToList();
                        foreach (Song song in SongsByArtist)
                        {
                            Int32 SaleCount;
                            SaleCount = 0;

                            Decimal TotalSongRevenue;
                            TotalSongRevenue = 0.00m;
                            List<OrderDetail> OrderDetails = db.OrderDetails.Where(x => x.Product.ContentID == song.ContentID).ToList();
                            foreach (OrderDetail orderdetail in OrderDetails)
                            {
                                SaleCount += 1;
                                TotalSongRevenue += orderdetail.ExtendedPrice;
                            }

                            songpurchases += SaleCount;
                            songrevenue += TotalSongRevenue;
                        }

                        List<Album> AlbumsByArtist = db.Albums.Where(x => x.Artists.Contains(artist)).ToList();
                        foreach (Album album in AlbumsByArtist)
                        {
                            Int32 SaleCount;
                            SaleCount = 0;

                            Decimal TotalAlbumRevenue;
                            TotalAlbumRevenue = 0.00m;
                            List<OrderDetail> OrderDetails = db.OrderDetails.Where(x => x.Product.ContentID == album.ContentID).ToList();
                            foreach (OrderDetail orderdetail in OrderDetails)
                            {
                                SaleCount += 1;
                                TotalAlbumRevenue += orderdetail.ExtendedPrice;
                            }

                            albumpurchases += SaleCount;
                            albumrevenue += TotalAlbumRevenue;
                        }
                        artistinstance.ArtistName = artist.ArtistName;
                        artistinstance.GenreName = genre.GenreName;
                        totalrevenue = albumrevenue + songrevenue;
                        artistinstance.AlbumPurchases = albumpurchases;
                        artistinstance.AlbumRevenue = albumrevenue;
                        artistinstance.SongPurchases = songpurchases;
                        artistinstance.SongRevenue = songrevenue;
                        artistinstance.TotalRevenue = totalrevenue;
                        if (totalrevenue >= TopArtist.TotalRevenue)
                        {
                            TopArtist = artistinstance;
                        }
                    }
                }
                //Add top artist of that genre to the list
                TopArtists.Add(TopArtist);
            }
            ViewBag.TopArtists = TopArtists;

            return View();
        }
    }
}
