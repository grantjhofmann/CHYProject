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
using CHY_Project.Messaging;

namespace CHY_Project.Controllers
{
    public class CartsController : Controller
    {
        //TODO: Restrict by Role
        private AppDbContext db = new AppDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        public ActionResult UserDetails()
        {

            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);

            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);

            if (cart == null)
            {
                cart = new Cart();
                cart.Products = new List<Product>();
                db.Carts.Add(cart);
                db.SaveChanges();
            }

            //differentiate between songs and albums
            List<AlbumViewModel> AlbumViewModels = new List<AlbumViewModel>();
            List<SongViewModel> SongViewModels = new List<SongViewModel>();

            foreach (Product modelproduct in cart.Products)
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
            ViewBag.Subtotal = subtotal();
            ViewBag.SongViewModel = SongViewModels;
            ViewBag.AlbumViewModel = AlbumViewModels;
            return View(cart);
        }

        //TODO: Change this so carts cannot be manually created
        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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

        //Add to cart
        public ActionResult AddtoCart(int id)
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            Product product = db.Products.Find(id);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);
            if (cart == null)
            {
                cart = new Cart();
                cart.Customer = currentuser;
                cart.Products = new List<Product>();
                cart.Products.Add(product);
                db.Carts.Add(cart);
            }
            else
            {
                if (cart.Products.Contains(product))
                {
                    ViewBag.Error = "Product is already in your cart";
                }
                else
                {
                    cart.Products.Add(product);
                }
            }
            db.SaveChanges();

            return RedirectToAction("UserDetails");
        }

        public ActionResult RemoveFromCart(int id)
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            Product product = db.Products.Find(id);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);

            if (cart == null)
            {
                return View("Error");
            }

            else
            {
                cart.Products.Remove(product);
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserDetails");
            }
        }

        public ActionResult ClearCart()
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);

            if (cart == null)
            {
                return View("Error");
            }

            else
            {
                cart.Products.Clear();
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("USerDetails");
            }

        }
        //GET
        public ActionResult Checkout()
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);

            List<AlbumViewModel> AlbumViewModels = new List<AlbumViewModel>();
            List<SongViewModel> SongViewModels = new List<SongViewModel>();

            foreach (Product modelproduct in cart.Products)
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
            ViewBag.SongViewModel = SongViewModels;
            ViewBag.AlbumViewModel = AlbumViewModels;
            CheckoutViewModel checkout = new CheckoutViewModel();

            List <CreditCard> CreditCards = new List<CreditCard>();

            CreditCards.Add(currentuser.CreditCards[1]);
            CreditCards.Add(currentuser.CreditCards[2]);

            ViewBag.CreditCards = CreditCards;

            checkout.Products = cart.Products;

            ViewBag.tax = tax();
            ViewBag.total = total();
            ViewBag.subtotal = subtotal();
            return View(checkout);

            //TODO: make this not suck
        }

        [HttpPost]
        public ActionResult Checkout ([Bind(Include = "CreditCard,Gift")] Purchase purchase, String recipientemail)
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.UserName == currentuser.UserName);

            purchase.Customer = cart.Customer;
            purchase.Date = DateTime.Today.Date;
            purchase.Products = cart.Products;

            if(purchase.Gift == false)
            {
                purchase.Recipient = currentuser;
            }

            else
            {
                AppUser recipient = db.Users.FirstOrDefault(x => x.Email == recipientemail);
                purchase.Recipient = recipient;
            }

            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
            }

            foreach(Product product in cart.Products)
            {
                OrderDetail orderdetail = new OrderDetail();

                orderdetail.Product = product;
                orderdetail.ExtendedPrice = product.DiscountPrice;
                orderdetail.Purchase = purchase;
            }


            EmailMessaging.SendEmail(currentuser.Email, "Welcome to Longhorn Music - Group 13!", "Thank you for signing up with Longhorn Music. You are now a registered user.");
            return View();
            
        }

        public Decimal subtotal ()
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.Id == currentuser.Id);
            decimal subtotal;
            subtotal = 0;
            foreach (Product product in cart.Products)
            {
                subtotal += product.DiscountPrice; ;
            }

            return subtotal;
        }

        public Decimal tax()
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.Id == currentuser.Id);
            decimal subtotal;
            subtotal = 0;
            foreach (Product product in cart.Products)
            {
                subtotal += product.DiscountPrice; ;
            }
            decimal taxrate = .0825m;

            decimal tax = subtotal * taxrate;

            return tax;
        }

        public Decimal total()
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer.Id == currentuser.Id);
            decimal subtotal;
            subtotal = 0;
            foreach (Product product in cart.Products)
            {
                subtotal += product.DiscountPrice; ;
            }

            decimal total;
            decimal taxrate = 1.0825m;
            total = subtotal * taxrate;

            return total;
        }
    }
}
