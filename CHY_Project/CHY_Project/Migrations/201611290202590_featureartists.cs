namespace CHY_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featureartists : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "Featured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "Featured", c => c.Boolean());
        }
    }
}
