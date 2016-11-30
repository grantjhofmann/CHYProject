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


        public ActionResult AddtoCart(int id)
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Product product = db.Products.Find(id);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer == currentuser);
            if (cart == null)
            {
                cart = new Cart();
                cart.Customer = currentuser;
                cart.Products = new List<Product>();
                cart.Products.Add(product);
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
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Product product = db.Products.Find(id);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer == currentuser);

            if (cart == null)
            {
                return View("Error");
            }

            else
            {
                cart.Products.Remove(product);
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult ClearCart(int id)
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Product product = db.Products.Find(id);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer == currentuser);

            if (cart == null)
            {
                return View("Error");
            }

            else
            {
                cart.Products.Clear();
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        //GET
        public ActionResult Checkout(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout ([Bind(Include = "CreditCard,Gift,Recipient")] Purchase purchase)
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer == currentuser);
            
            purchase.Customer = cart.Customer;
            purchase.Date = DateTime.Today.Date;
            purchase.Products = cart.Products;
            if(purchase.Gift == false)
            {
                purchase.Recipient = currentuser;
            }

            return View();
            
        }

        public Decimal cartTotal ()
        {
            string userid = User.Identity.GetUserId();
            AppUser currentuser = db.Users.Find(userid);
            Cart cart = db.Carts.FirstOrDefault(c => c.Customer == currentuser);
            decimal total;
            total = 0;
            foreach (Product product in cart.Products)
            {
                total += product.DiscountPrice; ;
            }

            return total;
        }

    }
}
