using System.Data.Entity.Migrations;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MojoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MojoDbContext context)
        {
            var googleFeed = new DbFeed()
            {
                Id = 1,
                Title = "Google Feed",
                Description = "This is Google",
                Link = "https://google.com"
            };

            var microsoftFeed = new DbFeed()
            {
                Id = 2,
                Title = "Microsoft Feed",
                Description = "This is Microsoft",
                Link = "https://microsoft.com"
            };

            context.Feeds.AddOrUpdate(x => x.Id, googleFeed, microsoftFeed);
            context.SaveChanges();

            context.FeedItems.AddOrUpdate(x => x.Id,
                new DbFeedItem()
                {
                    Id = 1,
                    Title = "Google's First Feed Item",
                    Description = "First Feed Item by Google",
                    Link = "https://www.google.com/search?q=guid+generator",
                    Guid = "57c4df7e-410b-4180-84d6-812dfbeda869",
                    PublishedDate = "2025-01-01",
                    DbFeedId = 1
                },
                new DbFeedItem()
                {
                    Id = 2,
                    Title = "Microsoft's First Feed Item",
                    Description = "First Feed Item by Microsoft",
                    Link = "https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-3",
                    Guid = "205ebf5a-38c3-4d65-b904-046e9ed8e0e6",
                    PublishedDate = "2025-01-01",
                    DbFeedId = 2
                },
                new DbFeedItem()
                {
                    Id = 3,
                    Title = "Microsoft's Second Feed Item",
                    Description = "Second Feed Item by Microsoft",
                    Link = "https://dotnet.microsoft.com/en-us/apps/aspnet/mvc",
                    Guid = "83f03a70-3664-40ac-a69d-9cf5f508a8cc",
                    PublishedDate = "2025-01-02",
                    DbFeedId = 2
                },
                new DbFeedItem()
                {
                    Id = 4,
                    Title = "Google's Second Feed Item",
                    Description = "Second Feed Item by Google",
                    Link = "https://www.google.com/search?q=asp+net+mvc",
                    Guid = "60ebcf5e-9ce8-4bf4-ac5b-72532853c189",
                    PublishedDate = "2025-01-03",
                    DbFeedId = 1
                }
            );

            context.SaveChanges();
        }
    }
}