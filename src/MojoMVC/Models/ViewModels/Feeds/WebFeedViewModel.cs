using System;
using System.Collections;
using System.Collections.Generic;
using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Models.ViewModels.Feeds
{
    public class WebFeedViewModel : IFeedViewModel
    {
        public WebFeedViewModel(WebFeed feed)
        {
            Title = feed.Title;
            Description = feed.Description;
            Link = feed.Link;
            FeedItems = new List<IFeedItemViewModel>();
            foreach (var item in feed.Items)
            {
                FeedItems.Add(new WebFeedItemViewModel(item));
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<IFeedItemViewModel> FeedItems { get; set; }
    }
}