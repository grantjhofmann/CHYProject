using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CHY_Project.Models
{
    public partial class ShoppingCart
    {
        AppDbContext storeDB = new AppDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "stringCartID";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Product product)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.stringCartID == ShoppingCartId
                && c.Products.Contains(product));

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {

                    stringCartID = ShoppingCartId
                };
                cartItem.Products.Add(product);
            }
            else
            {
                //add an error
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public void RemoveFromCart(int id, Product product)
        {
            // Get the cart
            var cart = storeDB.Carts.Find(id);

            if (cart != null)
            {
                if (cart.Products.Contains(product))
                {
                    cart.Products.Remove(product);
                }
                else
                {
                    //TODO: make error for null cart removal
                }
                // Save changes
                storeDB.SaveChanges();
            }
            //return itemCount;
        }
        public void EmptyCart()
        {
            Cart cartItems = storeDB.Carts.FirstOrDefault(
                cart => cart.stringCartID == ShoppingCartId);

            if (cartItems != null)
            {
                cartItems.Products.Clear();
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public List<Product> GetCartItems()
        {
            Cart cartItems = storeDB.Carts.FirstOrDefault(
                 cart => cart.stringCartID == ShoppingCartId);
            return cartItems.Products.ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.stringCartID == ShoppingCartId
                          select (int?)cartItems.Products.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            /*decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CartID == ShoppingCartId
                              select (int?)cartItems.Products *
                              cartItems.Album.Price).Sum();*/
            Cart cartItems = storeDB.Carts.FirstOrDefault(
            cart => cart.stringCartID == ShoppingCartId);
            decimal? total;
            total = 0;

            foreach(Product product in cartItems.Products)
            {
                if (product.DiscountPrice != product.RegularPrice)
                {
                    total += product.DiscountPrice;
                }
                else
                {
                    total += product.RegularPrice;
                }
            }
            return total ?? decimal.Zero;
        }
        /*
        public int CreatePurchase(Purchase purchase)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (Product product in cartItems)
            {

                var orderDetail = new OrderDetail
                {
                    contentID = product.ContentID,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Album.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            
            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }*/
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            Cart shoppingCart = storeDB.Carts.FirstOrDefault(
                c => c.stringCartID == ShoppingCartId);
            shoppingCart.Customer = storeDB.Users.Find(HttpContext.Current.User.Identity.GetUserId());

            storeDB.SaveChanges();
        }
    }
}