namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongModelFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Comment", c => c.String());
            AddColumn("dbo.Ratings", "Stars", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Starcount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Starcount", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Stars");
            DropColumn("dbo.Ratings", "Comment");
        }
    }
}
