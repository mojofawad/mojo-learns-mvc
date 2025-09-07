using System.Collections.Generic;
using MojoMVC.Models.ViewModels.Feeds;
using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(WebFeedViewModel webFeed, List<DbFeedViewModel> dbFeeds)
        {
            WebFeeds = new List<IFeedViewModel> { webFeed };
            DbFeeds = new List<IFeedViewModel>(dbFeeds);
        }

        public List<IFeedViewModel> WebFeeds { get; set; }
        public List<IFeedViewModel> DbFeeds { get; set; }
    }
}