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
    public class SongsController : Controller
    {
        public enum SongSort { Name, Artist, Rating}
        public enum SortOrder { Ascending, Descending}

        private AppDbContext db = new AppDbContext();

        // GET: Songs
        public ActionResult Index()
        {
            List<Song> AllSongs = db.Songs.ToList();

            ViewBag.SongCount = CountSongs(AllSongs);
            ViewBag.TotalSongCount = CountSongs(AllSongs);
            return View(db.Songs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {

            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,RegularPrice,DiscountPrice,Featured,SongName")] Song song, Int32[] Artists, Int32[] Genres)
        {
            
            if (Artists != null)
            {
                foreach (int Id in Artists)
                {
                    //Artist artist = new Artist();
                   // Artist artist = db.Artists.FirstOrDefault(i => i.ArtistID == Id);
                    Artist artist = db.Artists.Find(Id);
                    song.Artists.Add(artist);
                }
            }

            if (Genres != null)
            {

                //song.Genres = new List<Genre>();
                foreach (int Id in Genres)
                {
                    Genre genre = db.Genres.Find(Id);
                    song.Genres.Add(genre);
                }
            }
            
            Guid songproductGUID = Guid.NewGuid();
            String stringsongproductGUID = songproductGUID.ToString();

            Guid guidSongID = Guid.NewGuid();
            String stringguidsongID = guidSongID.ToString();

            song.ProductID = stringsongproductGUID;
            song.SongID = stringguidsongID;
            //ModelState.SetModelValue("ProductID", new ValueProviderResult(stringsongproductGUID, stringsongproductGUID, CultureInfo.InvariantCulture));
            //ModelState.SetModelValue("SongID", new ValueProviderResult(stringguidsongID, stringguidsongID, CultureInfo.InvariantCulture));


            if (ModelState.IsValid)
            {

                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllGenres = GetAllGenres(song);
            ViewBag.AllArtists = GetAllArtists(song);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,RegularPrice,DiscountPrice,Featured,SongName")] Song song, Int32[] Artists, Int32[] Genres)
        {
            if (ModelState.IsValid)
            {
                Song songToChange = db.Songs.Find(song.ContentID);
                songToChange.Genres.Clear();
                songToChange.Artists.Clear();

                if (Artists != null)
                {
                    foreach (int Id in Artists)
                    {
                        //Artist artist = db.Artists.FirstOrDefault(i => i.ArtistID == Id);
                        Artist artist = db.Artists.Find(Id);
                        songToChange.Artists.Add(artist);
                    }
                }
                if (Genres != null)
                {
                    //song.Genres = new List<Genre>();
                    foreach (int Id in Genres)
                    {
                        Genre genre = db.Genres.Find(Id);
                        songToChange.Genres.Add(genre);
                    }
                }

                songToChange.RegularPrice = song.RegularPrice;
                songToChange.DiscountPrice = song.DiscountPrice;
                songToChange.Featured = song.Featured;
                songToChange.SongName = song.SongName;

                db.Entry(songToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres(song);
            ViewBag.AllArtists = GetAllArtists(song);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            
            foreach(Genre genre in song.Genres)
            {
                genre.Contents.Remove(song);
            }
            

            foreach(Artist artist in song.Artists)
            {
                artist.Songs.Remove(song);
            }


            db.Songs.Remove(song);
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


        //Song Search
        public ActionResult Search()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            //TODO: Write a get all albums method (?)
            //ViewBag.AllAlbums = GetAllAlbums();
            return View();
        }

        //Search Results
        public ActionResult SearchResults(string NameSearchString, string ArtistSearchString, string AlbumSearchString, Int32[] SelectedGenres, SongSort SelectedSort, SortOrder SelectedSortOrder/*, TODO: Add parameter for Rating, once that is set up*/)
        {
            List<Song> SelectedSongs = new List<Song>();
            List<Song> AllSongs = db.Songs.ToList();

            var query = from s in db.Songs
                        select s;

            var qtest = query;

            if (NameSearchString != null && NameSearchString != "")
            {
                query = query.Where(s => s.SongName.Contains(NameSearchString));
            }

            if (ArtistSearchString != null && ArtistSearchString != "")
            {
                query = query.Where(s => s.Artists.Any(a => a.ArtistName.Contains(ArtistSearchString)));
            }

            if (AlbumSearchString != null && AlbumSearchString != "")
            {
                query = query.Where(s => s.Album.AlbumName.Contains(AlbumSearchString));
            }

            if (qtest != query)
            {
                SelectedSongs = query.ToList();
            }

            //TODO: Add rating search once that functionality is live

            List<Song> SongsInGenre;
            if (SelectedGenres != null)
            {
                foreach (int id in SelectedGenres)
                {
                    Genre genre = db.Genres.Find(id);

                    SongsInGenre = query.Where(s => s.Genres.Any(g => g.GenreID.Equals(id))).ToList();
                    foreach (Song s in SongsInGenre)
                    {
                        if (SelectedSongs.Contains(s) == false)
                        {
                            SelectedSongs.Add(s);
                        }
                    }
                }
            }
            if (SelectedSongs.Count == 0)
            {
                SelectedSongs = db.Songs.ToList();
            }

            switch (SelectedSort)
            {
                case SongSort.Name:
                    SelectedSongs = SelectedSongs.OrderBy(s => s.SongName).ToList(); break;
                case SongSort.Artist:
                    SelectedSongs = SelectedSongs.OrderBy(s=>s.Artists.First().ArtistName).ToList(); break;
                //TODO: Add song sort by rating case once that funtionality is live
                //case SongSort.Rating:
                    //; break;
            }

            switch (SelectedSortOrder)
            {
                case SortOrder.Ascending:
                    SelectedSongs = SelectedSongs; break;

                case SortOrder.Descending:
                    SelectedSongs.Reverse(); break;
            }

            ViewBag.SongCount = CountSongs(SelectedSongs);
            ViewBag.TotalSongCount = CountSongs(AllSongs);
            ViewBag.AllGenres = GetAllGenres();

            return View("Index", SelectedSongs);

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

        public MultiSelectList GetAllGenres(Song song)
        {
            var genrequery = from g in db.Genres
                             orderby g.GenreName
                             select g;
            List<Genre> AllGenres = genrequery.ToList();
            List<Int32> SelectedGenres = new List<Int32>();

            foreach (Genre g in song.Genres)
            {
                SelectedGenres.Add(g.GenreID);
            }

            MultiSelectList AllGenresList = new MultiSelectList(AllGenres, "GenreID", "GenreName", SelectedGenres);
            return AllGenresList;
        }

        public MultiSelectList GetAllArtists()
        {
            var artistquery = from a in db.Artists
                              orderby a.ArtistName
                              select a;
            List<Artist> AllArtists = artistquery.ToList();

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ContentID", "ArtistName");
            return AllArtistsList;
        }
        public MultiSelectList GetAllArtists(Song song)
        {
            var artistquery = from a in db.Artists
                              orderby a.ArtistName
                              select a;
            List<Artist> AllArtists = artistquery.ToList();
            List<Int32> SelectedArtists = new List<int>();

            foreach (Artist a in song.Artists)
            {
                SelectedArtists.Add(a.ContentID);
            }

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ContentID", "ArtistName", SelectedArtists);
            return AllArtistsList;
        }

        public Int32 CountSongs(List<Song> SongList)
        {
            //find list of songs
            var query = from c in SongList
                        orderby c.SongID
                        select c;
            //execute query and store in list
            List<Song> countedSongs = query.ToList();

            int songCount = countedSongs.Count();

            return songCount;

        }
    }
}
