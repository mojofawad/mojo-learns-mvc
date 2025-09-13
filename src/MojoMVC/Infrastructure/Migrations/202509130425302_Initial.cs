namespace MojoMVC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Guid = c.String(),
                        PublishedDate = c.String(),
                        DbFeedId = c.Int(nullable: false),
                        Feed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .Index(t => t.Feed_Id);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Link, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedItems", "Feed_Id", "dbo.Feeds");
            DropIndex("dbo.Feeds", new[] { "Link" });
            DropIndex("dbo.FeedItems", new[] { "Feed_Id" });
            DropTable("dbo.Feeds");
            DropTable("dbo.FeedItems");
        }
    }
}
