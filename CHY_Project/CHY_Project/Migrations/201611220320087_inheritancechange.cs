namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritancechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContentGenres", "Content_ContentID", "dbo.Contents");
            DropForeignKey("dbo.ContentGenres", "Genre_GenreID", "dbo.Genres");
            DropIndex("dbo.ContentGenres", new[] { "Content_ContentID" });
            DropIndex("dbo.ContentGenres", new[] { "Genre_GenreID" });
            AddColumn("dbo.Contents", "Genre_GenreID", c => c.Int());
            AddColumn("dbo.Genres", "Content_ContentID", c => c.Int());
            CreateIndex("dbo.Contents", "Genre_GenreID");
            CreateIndex("dbo.Genres", "Content_ContentID");
            AddForeignKey("dbo.Genres", "Content_ContentID", "dbo.Contents", "ContentID");
            AddForeignKey("dbo.Contents", "Genre_GenreID", "dbo.Genres", "GenreID");
            DropTable("dbo.ContentGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContentGenres",
                c => new
                    {
                        Content_ContentID = c.Int(nullable: false),
                        Genre_GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Content_ContentID, t.Genre_GenreID });
            
            DropForeignKey("dbo.Contents", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.Genres", "Content_ContentID", "dbo.Contents");
            DropIndex("dbo.Genres", new[] { "Content_ContentID" });
            DropIndex("dbo.Contents", new[] { "Genre_GenreID" });
            DropColumn("dbo.Genres", "Content_ContentID");
            DropColumn("dbo.Contents", "Genre_GenreID");
            CreateIndex("dbo.ContentGenres", "Genre_GenreID");
            CreateIndex("dbo.ContentGenres", "Content_ContentID");
            AddForeignKey("dbo.ContentGenres", "Genre_GenreID", "dbo.Genres", "GenreID", cascadeDelete: true);
            AddForeignKey("dbo.ContentGenres", "Content_ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
        }
    }
}
