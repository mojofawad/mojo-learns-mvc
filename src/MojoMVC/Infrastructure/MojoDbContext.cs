using System.Data.Entity;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class MojoDbContext : DbContext
    {
        public MojoDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<DbFeed> Feeds { get; set; }
        public DbSet<DbFeedItem> FeedItems { get; set; }
    }
}