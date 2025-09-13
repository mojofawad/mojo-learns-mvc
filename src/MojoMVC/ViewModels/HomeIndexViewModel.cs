using System.Collections.Generic;
using MojoMVC.Models.Entities;

namespace MojoMVC.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(Feed webFeed, List<Feed> dbFeeds)
        {
            WebFeeds = new List<Feed> { webFeed };
            DbFeeds = new List<Feed>(dbFeeds);
        }

        public IEnumerable<Feed> WebFeeds { get; set; }
        public IEnumerable<Feed> DbFeeds { get; set; }
    }
}