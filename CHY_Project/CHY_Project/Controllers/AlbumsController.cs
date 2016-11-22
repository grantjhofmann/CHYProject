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
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,ProductID,RegularPrice,DiscountPrice,Featured,AlbumID,AlbumName")] Album album)
        {
            if (ModelState.IsValid)
            {
                Guid guidAlbumProductID = Guid.NewGuid();
                Guid guidAlbumID = Guid.NewGuid();

                String stringAlbumProductID = guidAlbumProductID.ToString();
                String stringAlbumID = guidAlbumID.ToString();

                album.ProductID = stringAlbumProductID;
                album.AlbumID = stringAlbumID;

                db.Contents.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,ProductID,RegularPrice,DiscountPrice,Featured,AlbumID,AlbumName")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
        //TODO: integrate list functionality
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

            MultiSelectList AllSongsList = new MultiSelectList(AllSongs, "SongID", "SongName", SelectedSongs);
            return AllSongsList;
        }

        //TODO: integrate list functionality
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

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ArtistID", "ArtistName", SelectedArtists);
            return AllArtistsList;
        }

        //TODO: make genre list method
        public MultiSelectList GetAllGenres(Album album)
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            List<Int32> SelectedGenres = new List<Int32>();

            foreach(Genre g in album.Genres)
            {
                SelectedGenres.Add(g.GenreID);
            }

            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName", SelectedGenres);
            return AllGenresList;
        }
    }
}
