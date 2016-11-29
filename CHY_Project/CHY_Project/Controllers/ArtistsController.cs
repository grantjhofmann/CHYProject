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
            List<Artist> AllArtists = db.Artists.ToList();

            ViewBag.ArtistsCount = CountArtists(AllArtists);
            ViewBag.TotalArtistsCount = CountArtists(AllArtists);
            return View(db.Artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,ArtistName")] Artist artist, Int32[] Genres)
        {
            if (Genres != null)
            {
                artist.Genres = new List<Genre>();
                //song.Genres = new List<Genre>();
                foreach (int Id in Genres)
                {
                    Genre genre = db.Genres.Find(Id);
                    artist.Genres.Add(genre);
                }
            }

            if (ModelState.IsValid)
            {
                Guid guidArtistID = Guid.NewGuid();
                String stringArtistID = guidArtistID.ToString();

                artist.ArtistID = stringArtistID;

                db.Contents.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres();
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
            ViewBag.AllGenres = GetAllGenres(artist);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,ArtistName,Featured")] Artist artist, Int32[] Genres)
        {
            if (ModelState.IsValid)
            {
                Artist artisttochange = db.Artists.Find(artist.ContentID);
                artisttochange.Genres.Clear();
                if (Genres != null)
                {
                    artist.Genres = new List<Genre>();
                    //song.Genres = new List<Genre>();
                    foreach (int Id in Genres)
                    {
                        Genre genre = db.Genres.Find(Id);
                        artisttochange.Genres.Add(genre);
                    }
                }
                artisttochange.ArtistName = artist.ArtistName;
                artisttochange.Featured = artist.Featured;

                db.Entry(artisttochange).State = EntityState.Modified;
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
            foreach(Song song in artist.Songs)
            {
                song.Artists.Remove(artist);
            }
            foreach(Album album in artist.Albums)
            {
                album.Artists.Remove(artist);
            }
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

        //Artist Search
        public ActionResult Search()
        {
            //TODO: write getallgenres
            //ViewBag.AllGenres = GetAllGenres();
            //TODO: write getallartists
            //ViewBag.AllArtists = GetAllArtists();
            //TODO: Write a get all albums method (?)
            //ViewBag.AllAlbums = GetAllAlbums();
            return View();
        }

        //Search Results
        public ActionResult SearchResults(string NameSearchString, List<Genre> GenresSearched/*, TODO: Add parameter for Rating, once that is set up*/)
        {
            List<Artist> SelectedArtists = new List<Artist>();
            List<Artist> AllArtists = db.Artists.ToList();

            var query = from a in db.Artists
                        select a;


            //NOTE: Ask Katie if this is an "is equal to" or a "contains" search
            if (NameSearchString != null && NameSearchString != "")
            {
                query = query.Where(a => a.ArtistName.Contains(NameSearchString));
            }

            //TODO: Add genre search

            //TODO: Add rating search once that functionality is live

            //TODO: Add ascending/descening for name, rating

            SelectedArtists = query.ToList();

            ViewBag.ArtistCount = CountArtists(SelectedArtists);
            ViewBag.TotalArtistCount = CountArtists(AllArtists);

            return View("Index", SelectedArtists);

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
        public MultiSelectList GetAllGenres()
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
          
            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName");
            return AllGenresList;
        }
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
        public Int32 CountArtists(List<Artist> ArtistList)
        {
            //find list of artists
            var query = from c in ArtistList
                        orderby c.ArtistID
                        select c;
            //execute query and store in list
            List<Artist> countedArtists = query.ToList();

            int artistCount = countedArtists.Count();

            return artistCount;
        }

    }
}
