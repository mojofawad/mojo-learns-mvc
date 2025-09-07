using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Models.ViewModels.Feeds
{
    public class WebFeedItemViewModel : IFeedItemViewModel
    {
        public WebFeedItemViewModel(FeedItem feedItems)
        {
            Title = feedItems.Title;
            Description = feedItems.Description;
            Link = feedItems.Link;
            Guid = feedItems.Guid;
            PublishedDate = feedItems.PublishedDate;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string PublishedDate { get; set; }
    }
}