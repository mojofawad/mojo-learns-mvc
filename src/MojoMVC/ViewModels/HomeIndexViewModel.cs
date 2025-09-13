using System.Collections.Generic;
using MojoMVC.ViewModels.Feeds;
using MojoMVC.ViewModels.Interfaces;

namespace MojoMVC.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(DbFeedViewModel webFeed, List<DbFeedViewModel> dbFeeds)
        {
            WebFeeds = new List<IFeedViewModel> { webFeed };
            DbFeeds = new List<IFeedViewModel>(dbFeeds);
        }

        public List<IFeedViewModel> WebFeeds { get; set; }
        public List<IFeedViewModel> DbFeeds { get; set; }
    }
}