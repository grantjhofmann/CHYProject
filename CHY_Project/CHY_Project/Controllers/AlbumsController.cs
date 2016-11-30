using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;

namespace CHY_Project.Controllers
{
    public class AlbumsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Albums
        public ActionResult Index()
        {

            List<Album> AllAlbums = db.Albums.ToList();
            ViewBag.AlbumCount = CountAlbums(AllAlbums);
            ViewBag.TotalAlbumCount = CountAlbums(AllAlbums);

            
            return View(db.Albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            //TODO: make list of songs
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            Album album = new Album();
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllSongs = GetAllSongs();
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,RegularPrice,DiscountPrice,Featured,AlbumName,AlbumArt")] Album album, Int32[] Artists, Int32[] Genres, Int32[] Songs)
        {
            //if (ModelState.IsValid)
            //{
                
            //    db.Albums.Add(album);
            //    db.SaveChanges();
            //}

            if (Artists != null)
            {
                album.Artists = new List<Artist>();
                foreach (int Id in Artists)
                {

                    Artist artist = db.Artists.Find(Id);
                    
                    //Artist artist = db.Artists.Find(Convert.ToString(Id));
                    album.Artists.Add(artist);
                }
            }


            if (Genres != null)
            {
                album.Genres = new List<Genre>();
                //song.Genres = new List<Genre>();
                foreach (int Id in Genres)
                {
                    
                    Genre genre = db.Genres.Find(Id);
                    album.Genres.Add(genre);
                }
            }

            //TODO: Add logic to make sure a song can only be added to one album

            if (Songs != null)
            {
                album.Songs = new List<Song>();
                foreach (int Id in Songs)
                {
                    
                    //Song song = db.Songs.FirstOrDefault(i => i.ContentID == Id);
                    Song song = db.Songs.Find(Id);
                    album.Songs.Add(song);
                }
            }

            Guid guidAlbumProductID = Guid.NewGuid();
            Guid guidAlbumID = Guid.NewGuid();

            String stringAlbumProductID = guidAlbumProductID.ToString();
            String stringAlbumID = guidAlbumID.ToString();

            album.ProductID = stringAlbumProductID;
            album.AlbumID = stringAlbumID;
            if (ModelState.IsValid)
            {

                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllSongs = GetAllSongs();
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllSongs = GetAllSongs();
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,RegularPrice,DiscountPrice,Featured,AlbumName,AlbumArt")] Album album, String[] Artists, Int32[] Genres, String[] Songs)
        {
            if (ModelState.IsValid)
            {
                Album albumtochange = db.Albums.Find(album.ContentID);

                if (Songs != null)
                {
                    foreach (string Id in Songs)
                    {
                        Song song = db.Songs.FirstOrDefault(i => i.SongID == Id);
                        albumtochange.Songs.Add(song);
                    }
                }
                if (Artists != null)
                {
                    foreach (string Id in Artists)
                    {
                        Artist artist = db.Artists.FirstOrDefault(i => i.ArtistID == Id);
                        albumtochange.Artists.Add(artist);
                    }
                }
                if (Genres != null)
                {
                    album.Genres = new List<Genre>();
                    foreach (int Id in Genres)
                    {
                        Genre genre = db.Genres.Find(Id);
                        album.Genres.Add(genre);
                    }
                }

                //TODO: Uncomment once album art functionality built.
                //TODO: Add album art as a property above
                //albumtochange.AlbumArt = album.AlbumArt;
                albumtochange.RegularPrice = album.RegularPrice;
                albumtochange.DiscountPrice = album.DiscountPrice;
                albumtochange.Featured = album.Featured;
                albumtochange.AlbumName = album.AlbumName;
                albumtochange.AlbumArt = album.AlbumArt;

                db.Entry(albumtochange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllSongs = GetAllSongs();
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Contents.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Album Search
        public ActionResult Search()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllSongs = GetAllSongs();
            return View();
        }

        //Search Results
        public ActionResult SearchResults(string NameSearchString, string ArtistSearchString, Int32[] SelectedGenres/*, TODO: Add parameter for Rating, once that is set up*/)
        {
            List<Album> SelectedAlbums = new List<Album>();
            List<Album> AllAlbums = db.Albums.ToList();

            var query = from a in db.Albums
                        select a;

            var qtest = query;

            if (NameSearchString != null && NameSearchString != "")
            {
                query = query.Where(a => a.AlbumName.Contains(NameSearchString));
            }

            if (ArtistSearchString != null && ArtistSearchString != "")
            {
                query = query.Where(a => a.Artists.Any(ar => ar.ArtistName.Contains(ArtistSearchString)));
            }

            if (qtest != query)
            {
                SelectedAlbums = query.ToList();
            }

            //TODO: Add rating search once that functionality is live

            List<Album> AlbumsInGenre;
            if (SelectedGenres != null)
            {
                foreach (int id in SelectedGenres)
                {
                    Genre genre = db.Genres.Find(id);

                    AlbumsInGenre = query.Where(a => a.Genres.Any(g => g.GenreID.Equals(id))).ToList();
                    foreach (Album a in AlbumsInGenre)
                    {
                        if (SelectedAlbums.Contains(a) == false)
                        {
                            SelectedAlbums.Add(a);
                        }
                    }
                }
            }

            //TODO: Add Ascending/Descending for name, artist, rating



            ViewBag.AlbumCount = CountAlbums(SelectedAlbums);
            ViewBag.TotalAlbumCount = CountAlbums(AllAlbums);

            return View("Index", SelectedAlbums);
        }
        public MultiSelectList GetAllSongs()
        {
            var songquery = from s in db.Songs
                            orderby s.SongName
                            select s;
            List<Song> AllSongs = songquery.ToList();
            MultiSelectList AllSongsList = new MultiSelectList(AllSongs, "ContentID", "SongName");
            return AllSongsList;
        }
        public MultiSelectList GetAllSongs (Album album)
        {
            var songquery = from s in db.Songs
                            orderby s.SongName
                            select s;
            List<Song> AllSongs = songquery.ToList();
            List<String> SelectedSongs = new List<String>();

            foreach (Song s in album.Songs)
            {
                SelectedSongs.Add(s.SongID);
            }

            MultiSelectList AllSongsList = new MultiSelectList(AllSongs, "ContentID", "SongName", SelectedSongs);
            return AllSongsList;
        }

        //TODO: integrate list functionality
        public MultiSelectList GetAllArtists()
        {
            var artistquery = from a in db.Artists
                              orderby a.ArtistName
                              select a;
            List<Artist> AllArtists = artistquery.ToList();

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ContentID", "ArtistName");
            return AllArtistsList;
        }
        public MultiSelectList GetAllArtists (Album album)
        {
            var artistquery = from a in db.Artists
                              orderby a.ArtistName
                              select a;
            List<Artist> AllArtists = artistquery.ToList();
            List<String> SelectedArtists = new List<string>();

            foreach (Artist a in album.Artists)
            {
                SelectedArtists.Add(a.ArtistID);
            }

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ContentID", "ArtistName", SelectedArtists);
            return AllArtistsList;
        }

        //TODO: make genre list method
        public MultiSelectList GetAllGenres()
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName");
            return AllGenresList;
        }
        public MultiSelectList GetAllGenres(Album album)
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            List<Int32> SelectedGenres = new List<Int32>();

            foreach (Genre g in album.Genres)
            {
                SelectedGenres.Add(g.GenreID);
            }

            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName", SelectedGenres);
            return AllGenresList;
        }

             public Int32 CountAlbums(List<Album> AlbumList)
        {
            //find list of albums
            var query = from c in AlbumList
                        orderby c.AlbumID
                        select c;
            //execute query and store in list
            List<Album> countedAlbum = query.ToList();

            int albumCount = countedAlbum.Count();

            return albumCount;
        }
    }
    }

