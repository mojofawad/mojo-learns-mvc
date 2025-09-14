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

        public async Task<Feed> GetFeedById(int feedId)
        {
            return await _context.Feeds
                .Include(f => f.FeedItems)
                .FirstOrDefaultAsync(f => f.Id == feedId);
        }

        public async Task AddLatestFeedItems(int feedId, List<FeedItem> feedItems)
        {
            var feed = _context.Feeds
                .Include(f => f.FeedItems)
                .FirstOrDefault(f => f.Id == feedId);

            if (feed == null)
            {
                return;
            }
            
            var existingItemGuids = feed.FeedItems
                .Select(fi => fi.Guid)
                .ToHashSet();
            
            var newItems = feedItems
                .Where(fi => !existingItemGuids.Contains(fi.Guid))
                .ToList();

            if (newItems.Any())
            {
                feed.FeedItems.AddRange(newItems);
                
                await _context.SaveChangesAsync();
            }
        }
    }
}