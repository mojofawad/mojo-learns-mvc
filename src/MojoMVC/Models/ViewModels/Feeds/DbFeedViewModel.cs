using System.Collections.Generic;
using MojoMVC.Models.Entities;
using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Models.ViewModels.Feeds
{
    public class DbFeedViewModel : IFeedViewModel
    {
        public DbFeedViewModel(DbFeed feed)
        {
            Title = feed.Title;
            Description = feed.Description;
            Link = feed.Link;
            FeedItems = new List<IFeedItemViewModel>();
            foreach (var item in feed.FeedItems)
            {
                FeedItems.Add(new DbFeedItemViewModel(item));
            }
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<IFeedItemViewModel> FeedItems { get; set; }
    }
}