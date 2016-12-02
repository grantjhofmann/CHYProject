using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;
using Microsoft.AspNet.Identity;

namespace CHY_Project.Controllers
{
    public class AppUsersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: AppUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: AppUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: AppUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,Email,StreetAddress,City,ZipCode,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(appUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AppUser appUser = db.Users.Find(id);
            db.Users.Remove(appUser);
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

        public ActionResult ViewMyLibrary ()
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            List<AlbumViewModel> AlbumViewModels = new List<AlbumViewModel>();
            List<SongViewModel> SongViewModels = new List<SongViewModel>();
            List<Purchase> UserReceived = new List<Purchase>();
            UserReceived = db.Purchases.Where(x => x.Recipient.UserName == currentuser.UserName).ToList();

            foreach (Purchase received in UserReceived)
            {

                foreach (Product modelproduct in received.Products)
                {
                    Album album = db.Albums.FirstOrDefault(x => x.ProductID == modelproduct.ProductID);

                    if (album == null)
                    {
                        Song song = db.Songs.FirstOrDefault(x => x.ProductID == modelproduct.ProductID);
                        SongViewModel songviewmodel = new SongViewModel();
                        songviewmodel.id = song.ContentID;
                        songviewmodel.Album = song.Album;
                        songviewmodel.RegularPrice = song.RegularPrice;
                        songviewmodel.DiscountPrice = song.DiscountPrice;
                        songviewmodel.SongName = song.SongName;
                        songviewmodel.Artists = song.Artists;
                        SongViewModels.Add(songviewmodel);

                    }

                    else
                    {
                        AlbumViewModel albumviewmodel = new AlbumViewModel();
                        albumviewmodel.id = album.ContentID;
                        albumviewmodel.AlbumName = album.AlbumName;
                        albumviewmodel.AlbumArt = album.AlbumArt;
                        albumviewmodel.Artists = album.Artists;
                        albumviewmodel.DiscountPrice = album.DiscountPrice;
                        albumviewmodel.RegularPrice = album.RegularPrice;
                        albumviewmodel.Songs = album.Songs;

                        AlbumViewModels.Add(albumviewmodel);
                    }
                }
            }
            ViewBag.SongViewModel = SongViewModels;
            ViewBag.AlbumViewModel = AlbumViewModels;

            return View();
        }
    }
}
