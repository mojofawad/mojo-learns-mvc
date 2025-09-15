namespace MojoMVC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedItemContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedItems", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedItems", "Content");
        }
    }
}
