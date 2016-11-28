using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Models;

namespace CHY_Project.Controllers
{
    namespace MvcMusicStore.Controllers
    {
        public class ShoppingCartController : Controller
        {
            private AppDbContext db = new AppDbContext();
            //
            // GET: /ShoppingCart/
            public ActionResult Index()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);

                // Set up our ViewModel
                var viewModel = new ShoppingCartViewModel
                {
                    CartItems = cart.GetCartItems(),
                    CartTotal = cart.GetTotal()
                };
                // Return the view
                return View(viewModel);
            }
            //
            // GET: /Store/AddToCart/5
            public ActionResult AddToCart(int id)
            {
                // Retrieve the product from the database
                var addedProduct = db.Products
                    .Single(product => product.ContentID == id);

                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);

                cart.AddToCart(addedProduct.ContentID);

                // Go back to the main store page for more shopping
                return RedirectToAction("Index");
            }
            //
            // AJAX: /ShoppingCart/RemoveFromCart/5
            [HttpPost]
            public ActionResult RemoveFromCart(int id)
            {
                // Remove the item from the cart
                var cart = ShoppingCart.GetCart(this.HttpContext);

                // Get the name of the album to display confirmation
                //TODO: make this show names
                string productName = db.Products
                    .Single(item => item.ContentID == id).ProductID;

                // Remove from cart
                cart.RemoveFromCart(id);

                // Display the confirmation message
                var results = new ShoppingCartRemoveViewModel
                {
                    Message = Server.HtmlEncode(productName) +
                        " has been removed from your shopping cart.",
                    CartTotal = cart.GetTotal(),
                    DeleteId = id
                };
                return Json(results);
            }
            //
            // GET: /ShoppingCart/CartSummary
            [ChildActionOnly]
            public ActionResult CartSummary()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);

                ViewData["CartCount"] = cart.GetCount();
                return PartialView("CartSummary");
            }
        }
    }
}