using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class FeedRepository
    {
        public static async Task<List<DbFeedItem>> GetFeedItemsFromDb()
        {
            using (var context = new MojoDbContext())
            {
                return await context.FeedItems
                    .Include(fi => fi.DbFeed)
                    .ToListAsync();
            }
        }
    }
}