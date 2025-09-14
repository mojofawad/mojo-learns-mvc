using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void AddFeedSource(Feed feed)
        {
            _context.Feeds.Add(feed);

            _context.SaveChanges();
        }

        public Feed GetFeedById(int feedId)
        {
            return _context.Feeds
                .Include(f => f.FeedItems)
                .FirstOrDefault(f => f.Id == feedId);
        }
    }
}