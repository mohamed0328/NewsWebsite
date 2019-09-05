namespace SomaliaNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                        NewsContext = c.String(nullable: false),
                        NewsDate = c.DateTime(nullable: false),
                        Image = c.Byte(nullable: false),
                        Side = c.String(nullable: false, maxLength: 10),
                        NewsReporter = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
        }
    }
}
