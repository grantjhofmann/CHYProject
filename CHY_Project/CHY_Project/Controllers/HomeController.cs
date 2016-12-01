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
            List<FeaturedContentViewModel> FArtists = new List<FeaturedContentViewModel>();
            List<Artist> FeaturedArtists = db.Artists.Where(a => a.Featured == true).ToList();
            
            foreach (var artist in FeaturedArtists)
            {
                FeaturedContentViewModel featuredArtist = new FeaturedContentViewModel();
                featuredArtist.ArtistName = artist.ArtistName;

                FArtists.Add(featuredArtist);
            }

            List<FeaturedContentViewModel> FSongs = new List<FeaturedContentViewModel>();
            List<Song> FeaturedSongs = db.Songs.Where(s => s.Featured == true).ToList();

            foreach (var song in FeaturedSongs)
            {
                FeaturedContentViewModel featuredSong = new FeaturedContentViewModel();
                featuredSong.ArtistName = song.SongName;

                FArtists.Add(featuredSong);
            }

            List<FeaturedContentViewModel> FAlbums = new List<FeaturedContentViewModel>();
            List<Album> FeaturedAlbums = db.Albums.Where(a => a.Featured == true).ToList();

            foreach (var album in FeaturedAlbums)
            {
                FeaturedContentViewModel featuredAlbum = new FeaturedContentViewModel();
                featuredAlbum.AlbumName = album.AlbumName;

                FArtists.Add(featuredAlbum);
            }
            //List<Song> FeaturedSongs;
            //var query2 = db.Songs.Where(s => s.Featured == true);

            //FeaturedSongs = query2.ToList();

            //ViewBag.FeaturedSongs = FeaturedSongs;

            //List<Album> FeaturedAlbums;
            //var query3 = db.Albums.Where(c => c.Featured == true);

            //FeaturedAlbums = query3.ToList();

            //ViewBag.FeaturedAlbums = FeaturedAlbums;
            return View();
        }
    }
}