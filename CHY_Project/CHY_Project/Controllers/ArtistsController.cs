using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;
using System.Globalization;

namespace CHY_Project.Controllers
{
    public class ArtistsController : Controller
    {
        //TODO: Restrict by Role
        private AppDbContext db = new AppDbContext();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(string id)
        {
            //TODO: list albums
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,ArtistName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                Guid guidArtistID = Guid.NewGuid();
                String stringArtistID = guidArtistID.ToString();

                artist.ArtistID = stringArtistID;

                db.Contents.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,ArtistID,ArtistName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Artist artist = db.Artists.Find(id);
            db.Contents.Remove(artist);
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
        //TODO: create album list for artist
        public MultiSelectList GetAllAlbums(Artist Artist)
        {
            var albumquery = from a in db.Albums
                             orderby a.AlbumName
                             select a;
            List<Album> AllAlbums = albumquery.ToList();
            List<String> SelectedAlbums = new List<String>();

            foreach (Album a in Artist.Albums)
            {
                SelectedAlbums.Add(a.AlbumID);
            }

            MultiSelectList AllAlbumsList = new MultiSelectList(AllAlbums, "AlbumID", "AlbumName", SelectedAlbums);
            return AllAlbumsList;
        }

        //TODO: Integrate selectlist functionality
        public MultiSelectList GetAllGenres(Artist artist)
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            List<Int32> SelectedGenres = new List<Int32>();

            foreach (Genre g in artist.Genres)
            {
                SelectedGenres.Add(g.GenreID);
            }

            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName", SelectedGenres);
            return AllGenresList;
        }
    }
}
