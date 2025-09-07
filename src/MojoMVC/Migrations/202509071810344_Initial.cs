namespace MojoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFeedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Guid = c.String(),
                        PublishedDate = c.String(),
                        DbFeedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbFeeds", t => t.DbFeedId, cascadeDelete: true)
                .Index(t => t.DbFeedId);
            
            CreateTable(
                "dbo.DbFeeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbFeedItems", "DbFeedId", "dbo.DbFeeds");
            DropIndex("dbo.DbFeedItems", new[] { "DbFeedId" });
            DropTable("dbo.DbFeeds");
            DropTable("dbo.DbFeedItems");
        }
    }
}
