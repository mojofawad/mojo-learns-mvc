using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class FeedsRepository
    {
        public static async Task<List<DbFeed>> GetFeeds()
        {
            using (var context = new MojoDbContext())
            {
                return await context.Feeds
                    .Include(f => f.FeedItems)
                    .ToListAsync();
            }
        }

        public void AddFeed(DbFeed feed)
        {
            using (var context = new MojoDbContext())
            {
                context.Feeds.Add(feed);
                
                context.SaveChanges();
            }
        }
    }
}