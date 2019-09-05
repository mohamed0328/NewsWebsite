namespace SomaliaNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bytes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Image", c => c.Byte(nullable: false));
        }
    }
}
