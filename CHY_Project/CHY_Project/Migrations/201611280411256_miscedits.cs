namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miscedits : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "Purchase_CartID", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Purchase_CartID" });
            AddColumn("dbo.Carts", "stringCartID", c => c.String());
            AlterColumn("dbo.Carts", "Customer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "Purchase_CartID", c => c.Int());
            CreateIndex("dbo.Carts", "Customer_Id");
            CreateIndex("dbo.OrderDetails", "Purchase_CartID");
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OrderDetails", "Purchase_CartID", "dbo.Carts", "CartID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Purchase_CartID", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderDetails", new[] { "Purchase_CartID" });
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            AlterColumn("dbo.OrderDetails", "Purchase_CartID", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "Customer_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Carts", "stringCartID");
            CreateIndex("dbo.OrderDetails", "Purchase_CartID");
            CreateIndex("dbo.Carts", "Customer_Id");
            AddForeignKey("dbo.OrderDetails", "Purchase_CartID", "dbo.Carts", "CartID", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
