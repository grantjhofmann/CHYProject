﻿using System;
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
        private AppDbContext db = new AppDbContext();

        // GET: Songs
        public ActionResult Index()
        {
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
        public ActionResult Create([Bind(Include = "ContentID,RegularPrice,DiscountPrice,Featured,SongName,Artists,Genres")] Song song, Int32[] Artists, Int32[] Genres)
        {
            
            if (Artists != null)
            {
                foreach (int Id in Artists)
                {
                    Artist artist = db.Artists.Find(Id);
                    song.Artists.Add(artist);
                }
            }

            if (Genres != null)
            {
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
                /*
                Song songtochange = db.Songs.Find(song.SongID);
                if (Artists != null)
                {
                    foreach (int Id in Artists)
                    {
                        Artist artist = db.Artists.Find(Id);
                        songtochange.Artists.Add(artist);
                    }
                }

                if (Genres != null)
                {
                    foreach (int Id in Genres)
                    {
                        Genre genre = db.Genres.Find(Id);
                        songtochange.Genres.Add(genre);
                    }
                }
                db.Entry(songtochange).State = EntityState.Modified;
                db.SaveChanges();
                */
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
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,ProductID,RegularPrice,DiscountPrice,Featured,SongID,SongName")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

            MultiSelectList AllArtistsList = new MultiSelectList(AllArtists, "ArtistID", "ArtistName");
            return AllArtistsList;
        }
        public MultiSelectList GetAllArtists(Album album)
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
    }
}
