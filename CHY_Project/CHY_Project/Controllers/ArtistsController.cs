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

        public enum ArtistSort { Name, Rating }

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
        [Authorize(Roles = "Manager")]
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
        public ActionResult Create([Bind(Include = "ContentID,ArtistName,Featured")] Artist artist, Int32[] Genres)
        {
            if (ModelState.IsValid)
            {
                Guid guidArtistID = Guid.NewGuid();
                String stringArtistID = guidArtistID.ToString();

                artist.ArtistID = stringArtistID;

                if (Genres != null)
                {
                    artist.Genres = new List<Genre>();
                    foreach (int Id in Genres)
                    {
                        Genre genre = db.Genres.Find(Id);
                        artist.Genres.Add(genre);
                    }
                }

                db.Contents.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres();
            return View(artist);
        }
        [Authorize(Roles = "Manager")]
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

            Artist artisttochange = db.Artists.Find(artist.ContentID);
            artisttochange.Genres.Clear();

            if (Genres != null)
            {
                artist.Genres = new List<Genre>();
                foreach (int Id in Genres)
                {
                    Genre genre = db.Genres.Find(Id);
                    artist.Genres.Add(genre);
                }
            }

            artisttochange.ArtistName = artist.ArtistName;
            artisttochange.Featured = artist.Featured;
            if (ModelState.IsValid)
            {

                db.Entry(artisttochange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres(artist);
            return View(artist);
        }
        [Authorize(Roles = "Manager")]
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
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }


        public ActionResult SearchResults(string NameSearchString, Int32[] SelectedGenres, ArtistSort SelectedSort, SongsController.SortOrder SelectedSortOrder/*, TODO: Add parameter for Rating, once that is set up*/)
        {
            List<Artist> SelectedArtists = new List<Artist>();
            List<Artist> AllArtists = db.Artists.ToList();

            var query = from a in db.Artists
                        select a;

            var qtest = query;

            if (NameSearchString != null && NameSearchString != "")
            {
                query = query.Where(a => a.ArtistName.Contains(NameSearchString));
            }

            if (qtest != query)
            {
                SelectedArtists = query.ToList();
            }

            //TODO: Add rating search once that functionality is live

            List<Artist> ArtistInGenre;
            if (SelectedGenres != null)
            {
                foreach (int id in SelectedGenres)
                {
                    Genre genre = db.Genres.Find(id);

                    ArtistInGenre = query.Where(a => a.Genres.Any(g => g.GenreID.Equals(id))).ToList();
                    foreach (Artist a in ArtistInGenre)
                    {
                        if (SelectedArtists.Contains(a) == false)
                        {
                            SelectedArtists.Add(a);
                        }
                    }
                }
            }

            if (SelectedArtists.Count == 0)
            {
                SelectedArtists = db.Artists.ToList();
            }

            switch (SelectedSort)
            {
                case ArtistSort.Name:
                    SelectedArtists = SelectedArtists.OrderBy(s => s.ArtistName).ToList(); break;
                //TODO: Add song sort by rating case once that funtionality is live
                //case SongSort.Rating:
                    //; break;
            }

            switch (SelectedSortOrder)
            {
                case SongsController.SortOrder.Ascending:
                    SelectedArtists = SelectedArtists; break;

                case SongsController.SortOrder.Descending:
                    SelectedArtists.Reverse(); break;
            }

            ViewBag.ArtistsCount = CountArtists(SelectedArtists);
            ViewBag.TotalArtistsCount = CountArtists(AllArtists);
            ViewBag.AllGenres = GetAllGenres();

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

        public MultiSelectList GetAllGenres()
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName");
            return AllGenresList;
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
