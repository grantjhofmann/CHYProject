namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartlistsforproducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Cart_CartID", "dbo.Carts");
            DropIndex("dbo.Contents", new[] { "Cart_CartID" });
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Cart_CartID = c.Int(nullable: false),
                        Product_ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cart_CartID, t.Product_ContentID })
                .ForeignKey("dbo.Carts", s => s.Cart_CartID, cascadeDelete: true)
                .ForeignKey("dbo.Contents", r => r.Product_ContentID, cascadeDelete: true)
                .Index(y => y.Cart_CartID)
                .Index(x => x.Product_ContentID);
            
            DropColumn("dbo.Contents", "Cart_CartID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "Cart_CartID", c => c.Int());
            DropForeignKey("dbo.CartProducts", "Product_ContentID", "dbo.Contents");
            DropForeignKey("dbo.CartProducts", "Cart_CartID", "dbo.Carts");
            DropIndex("dbo.CartProducts", new[] { "Product_ContentID" });
            DropIndex("dbo.CartProducts", new[] { "Cart_CartID" });
            DropTable("dbo.CartProducts");
            CreateIndex("dbo.Contents", "Cart_CartID");
            AddForeignKey("dbo.Contents", "Cart_CartID", "dbo.Carts", "CartID");
        }
    }
}
