namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryStringGuid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ProductID", c => c.String());
            AlterColumn("dbo.Contents", "AlbumID", c => c.String());
            AlterColumn("dbo.Contents", "ArtistID", c => c.String());
            AlterColumn("dbo.Contents", "SongID", c => c.String());
            AlterColumn("dbo.Carts", "PurchaseID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "PurchaseID", c => c.Int());
            AlterColumn("dbo.Contents", "SongID", c => c.Int());
            AlterColumn("dbo.Contents", "ArtistID", c => c.Int());
            AlterColumn("dbo.Contents", "AlbumID", c => c.Int());
            AlterColumn("dbo.Contents", "ProductID", c => c.Int());
        }
    }
}
