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
                        FeedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.FeedId, cascadeDelete: true)
                .Index(t => t.FeedId);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(maxLength: 450),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Link, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedItems", "FeedId", "dbo.Feeds");
            DropIndex("dbo.Feeds", new[] { "Link" });
            DropIndex("dbo.FeedItems", new[] { "FeedId" });
            DropTable("dbo.Feeds");
            DropTable("dbo.FeedItems");
        }
    }
}
