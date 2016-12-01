namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hecker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Starcount", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Comment");
            DropColumn("dbo.Ratings", "Stars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Stars", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "Comment", c => c.String());
            DropColumn("dbo.Ratings", "Starcount");
        }
    }
}
