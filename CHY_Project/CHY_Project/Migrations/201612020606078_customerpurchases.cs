namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerpurchases : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ContentID", "dbo.Contents");
            DropIndex("dbo.OrderDetails", new[] { "Product_ContentID" });
            AlterColumn("dbo.OrderDetails", "Product_ContentID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Product_ContentID");
            AddForeignKey("dbo.OrderDetails", "Product_ContentID", "dbo.Contents", "ContentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ContentID", "dbo.Contents");
            DropIndex("dbo.OrderDetails", new[] { "Product_ContentID" });
            AlterColumn("dbo.OrderDetails", "Product_ContentID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "Product_ContentID");
            AddForeignKey("dbo.OrderDetails", "Product_ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
        }
    }
}
