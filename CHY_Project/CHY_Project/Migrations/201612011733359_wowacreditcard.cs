namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wowacreditcard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CreditCard1_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.AspNetUsers", "CreditCard2_CreditCardID", "dbo.CreditCards");
            DropIndex("dbo.AspNetUsers", new[] { "CreditCard1_CreditCardID" });
            DropIndex("dbo.AspNetUsers", new[] { "CreditCard2_CreditCardID" });
            DropColumn("dbo.AspNetUsers", "CreditCard1_CreditCardID");
            DropColumn("dbo.AspNetUsers", "CreditCard2_CreditCardID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CreditCard2_CreditCardID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CreditCard1_CreditCardID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CreditCard2_CreditCardID");
            CreateIndex("dbo.AspNetUsers", "CreditCard1_CreditCardID");
            AddForeignKey("dbo.AspNetUsers", "CreditCard2_CreditCardID", "dbo.CreditCards", "CreditCardID");
            AddForeignKey("dbo.AspNetUsers", "CreditCard1_CreditCardID", "dbo.CreditCards", "CreditCardID");
        }
    }
}
