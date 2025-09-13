namespace MojoMVC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeFeedLinksUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbFeeds", "Link", c => c.String(maxLength: 450));
            CreateIndex("dbo.DbFeeds", "Link", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.DbFeeds", new[] { "Link" });
            AlterColumn("dbo.DbFeeds", "Link", c => c.String());
        }
    }
}
