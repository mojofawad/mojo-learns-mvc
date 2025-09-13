using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class FeedsRepository
    {
        private readonly MojoDbContext _context = new MojoDbContext();

        public async Task<List<Feed>> GetFeeds()
        {
            return await _context.Feeds
                .Include(f => f.FeedItems)
                .ToListAsync();
        }

        public void AddFeed(Feed feed)
        {
            _context.Feeds.Add(feed);
            
            _context.SaveChanges();
        }
    }
}