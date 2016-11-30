namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creditcardfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CreditCards", new[] { "Customer_Id" });
            AddColumn("dbo.AspNetUsers", "CreditCard1_CreditCardID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CreditCard2_CreditCardID", c => c.Int());
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.String(nullable: false));
            AlterColumn("dbo.CreditCards", "Customer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "CreditCard1_CreditCardID");
            CreateIndex("dbo.AspNetUsers", "CreditCard2_CreditCardID");
            CreateIndex("dbo.CreditCards", "Customer_Id");
            AddForeignKey("dbo.AspNetUsers", "CreditCard1_CreditCardID", "dbo.CreditCards", "CreditCardID");
            AddForeignKey("dbo.AspNetUsers", "CreditCard2_CreditCardID", "dbo.CreditCards", "CreditCardID");
            AddForeignKey("dbo.CreditCards", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CreditCard2_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.AspNetUsers", "CreditCard1_CreditCardID", "dbo.CreditCards");
            DropIndex("dbo.CreditCards", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "CreditCard2_CreditCardID" });
            DropIndex("dbo.AspNetUsers", new[] { "CreditCard1_CreditCardID" });
            AlterColumn("dbo.CreditCards", "Customer_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "CreditCard2_CreditCardID");
            DropColumn("dbo.AspNetUsers", "CreditCard1_CreditCardID");
            CreateIndex("dbo.CreditCards", "Customer_Id");
            AddForeignKey("dbo.CreditCards", "Customer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
