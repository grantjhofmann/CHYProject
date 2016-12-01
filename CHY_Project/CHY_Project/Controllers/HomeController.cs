using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;

namespace CHY_Project.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Home
        public ActionResult Index()
        {
            //List<FeaturedContentViewModel> FContent = new List<FeaturedContentViewModel>();

            //List<Artist> FeaturedArtists = db.Artists.Where(a => a.Featured == true).ToList();

            //foreach (var artist in FeaturedArtists)
            //{
            //    FeaturedContentViewModel featuredArtist = new FeaturedContentViewModel();
            //    featuredArtist.ArtistName = artist.ArtistName;

            //    FContent.Add(featuredArtist);
            //}

            //List<Song> FeaturedSongs = db.Songs.Where(s => s.Featured == true).ToList();

            //foreach (var song in FeaturedSongs)
            //{
            //    FeaturedContentViewModel featuredSong = new FeaturedContentViewModel();
            //    featuredSong.ArtistName = song.SongName;

            //    FContent.Add(featuredSong);
            //}

            //List<Album> FeaturedAlbums = db.Albums.Where(a => a.Featured == true).ToList();

            //foreach (var album in FeaturedAlbums)
            //{
            //    FeaturedContentViewModel featuredAlbum = new FeaturedContentViewModel();
            //    featuredAlbum.AlbumName = album.AlbumName;

            //    FContent.Add(featuredAlbum);
            //}


            List<Song> FeaturedSongs;
            var query = db.Songs.Where(s => s.Featured == true);

            FeaturedSongs = query.ToList();

            ViewBag.FeaturedSongs = FeaturedSongs;

            List<Album> FeaturedAlbums;
            var query2 = db.Albums.Where(c => c.Featured == true);

            FeaturedAlbums = query2.ToList();

            ViewBag.FeaturedAlbums = FeaturedAlbums;

            List<Artist> FeaturedArtists;
            var query3 = db.Artists.Where(c => c.Featured == true);

            FeaturedArtists = query3.ToList();

            ViewBag.FeaturedArtists = FeaturedArtists;

            return View();
        }
    }
}