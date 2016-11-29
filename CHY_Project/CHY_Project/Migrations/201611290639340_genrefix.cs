namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genrefix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Content_ContentID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Genre_GenreID", "dbo.Genres");
            DropIndex("dbo.Contents", new[] { "Genre_GenreID" });
            DropIndex("dbo.Genres", new[] { "Content_ContentID" });
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
            
            DropColumn("dbo.Contents", "Genre_GenreID");
            DropColumn("dbo.Genres", "Content_ContentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Content_ContentID", c => c.Int());
            AddColumn("dbo.Contents", "Genre_GenreID", c => c.Int());
            DropForeignKey("dbo.ContentGenres", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.ContentGenres", "Content_ContentID", "dbo.Contents");
            DropIndex("dbo.ContentGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.ContentGenres", new[] { "Content_ContentID" });
            DropTable("dbo.ContentGenres");
            CreateIndex("dbo.Genres", "Content_ContentID");
            CreateIndex("dbo.Contents", "Genre_GenreID");
            AddForeignKey("dbo.Contents", "Genre_GenreID", "dbo.Genres", "GenreID");
            AddForeignKey("dbo.Genres", "Content_ContentID", "dbo.Contents", "ContentID");
        }
    }
}
