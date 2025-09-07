using System.Collections.Generic;
using MojoMVC.Models.Entities;

namespace MojoMVC.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel(WebFeed rssWebFeed, List<DbFeedItem> feedItems)
        {
            RssWebFeed = rssWebFeed;
            FeedItems = feedItems;
        }

        public WebFeed RssWebFeed { get; set; }
        public List<DbFeedItem> FeedItems { get; set; }
    }
}