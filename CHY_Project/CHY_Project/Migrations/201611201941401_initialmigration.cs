namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        RegularPrice = c.Decimal(precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(precision: 18, scale: 2),
                        Featured = c.Boolean(),
                        AlbumID = c.Int(),
                        AlbumName = c.String(),
                        AlbumArt = c.String(),
                        ArtistID = c.Int(),
                        ArtistName = c.String(),
                        SongID = c.Int(),
                        SongName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Album_ContentID = c.Int(),
                        Cart_CartID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Contents", t => t.Album_ContentID)
                .ForeignKey("dbo.Carts", t => t.Cart_CartID)
                .Index(t => t.Album_ContentID)
                .Index(t => t.Cart_CartID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Starcount = c.Int(nullable: false),
                        Content_ContentID = c.Int(nullable: false),
                        Customer_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Contents", t => t.Content_ContentID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Content_ContentID)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(),
                        Gift = c.Boolean(),
                        Date = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Customer_Id = c.String(nullable: false, maxLength: 128),
                        CreditCard_CreditCardID = c.Int(),
                        Recipient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_CreditCardID)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.CreditCard_CreditCardID)
                .Index(t => t.Recipient_Id);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        Cardtype = c.Int(nullable: false),
                        Customer_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        ExtendedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_ContentID = c.Int(nullable: false),
                        Purchase_CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Contents", t => t.Product_ContentID, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Purchase_CartID, cascadeDelete: true)
                .Index(t => t.Product_ContentID)
                .Index(t => t.Purchase_CartID);
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_ContentID = c.Int(nullable: false),
                        Album_ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ContentID, t.Album_ContentID })
                .ForeignKey("dbo.Contents", t => t.Artist_ContentID)
                .ForeignKey("dbo.Contents", t => t.Album_ContentID)
                .Index(t => t.Artist_ContentID)
                .Index(t => t.Album_ContentID);
            
            CreateTable(
                "dbo.ContentGenres",
                c => new
                    {
                        Content_ContentID = c.Int(nullable: false),
                        Genre_GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Content_ContentID, t.Genre_GenreID })
                .ForeignKey("dbo.Contents", t => t.Content_ContentID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .Index(t => t.Content_ContentID)
                .Index(t => t.Genre_GenreID);
            
            CreateTable(
                "dbo.SongArtists",
                c => new
                    {
                        Song_ContentID = c.Int(nullable: false),
                        Artist_ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_ContentID, t.Artist_ContentID })
                .ForeignKey("dbo.Contents", t => t.Song_ContentID)
                .ForeignKey("dbo.Contents", t => t.Artist_ContentID)
                .Index(t => t.Song_ContentID)
                .Index(t => t.Artist_ContentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Carts", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "Purchase_CartID", "dbo.Carts");
            DropForeignKey("dbo.OrderDetails", "Product_ContentID", "dbo.Contents");
            DropForeignKey("dbo.Carts", "CreditCard_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.CreditCards", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contents", "Cart_CartID", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SongArtists", "Artist_ContentID", "dbo.Contents");
            DropForeignKey("dbo.SongArtists", "Song_ContentID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Album_ContentID", "dbo.Contents");
            DropForeignKey("dbo.Ratings", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "Content_ContentID", "dbo.Contents");
            DropForeignKey("dbo.ContentGenres", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.ContentGenres", "Content_ContentID", "dbo.Contents");
            DropForeignKey("dbo.ArtistAlbums", "Album_ContentID", "dbo.Contents");
            DropForeignKey("dbo.ArtistAlbums", "Artist_ContentID", "dbo.Contents");
            DropIndex("dbo.SongArtists", new[] { "Artist_ContentID" });
            DropIndex("dbo.SongArtists", new[] { "Song_ContentID" });
            DropIndex("dbo.ContentGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.ContentGenres", new[] { "Content_ContentID" });
            DropIndex("dbo.ArtistAlbums", new[] { "Album_ContentID" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_ContentID" });
            DropIndex("dbo.OrderDetails", new[] { "Purchase_CartID" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ContentID" });
            DropIndex("dbo.CreditCards", new[] { "Customer_Id" });
            DropIndex("dbo.Carts", new[] { "Recipient_Id" });
            DropIndex("dbo.Carts", new[] { "CreditCard_CreditCardID" });
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Ratings", new[] { "Customer_Id" });
            DropIndex("dbo.Ratings", new[] { "Content_ContentID" });
            DropIndex("dbo.Contents", new[] { "Cart_CartID" });
            DropIndex("dbo.Contents", new[] { "Album_ContentID" });
            DropTable("dbo.SongArtists");
            DropTable("dbo.ContentGenres");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Carts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genres");
            DropTable("dbo.Contents");
        }
    }
}
