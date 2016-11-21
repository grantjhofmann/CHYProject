using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace CHY_Project.Models
{
    // You can add profile data for the user by adding more properties to your AppUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser
    {
        //TODO: Put any additional fields that you need for your users here
        //For example:
        public String FName { get; set; }
        public String LName { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public Int32 ZipCode { get; set; }
        //public Int32 CreditCard1 { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    //NOTE: Here is your dbContext for the entire project.  There should only be ONE DbContext per project
    //Your dbContext (AppDbContext) inherits from IdentityDbContext, which inherits from the "regular" DbContext
    //TODO: If you have an existing dbContext (it may be in your DAL folder), DELETE THE EXISTING dbContext

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //TODO: Add your dbSets here.  As an example, I've included one for products
        //Remember - the IdentityDbContext already contains a db set for Users.  If you add another one, your code will break
        //public DbSet<Product> Products { get; set; }

        public AppDbContext()
            : base("MyDbConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        //Add dbSet for roles
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        //public DbSet<Content> Contents { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
