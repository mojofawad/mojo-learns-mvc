using MojoMVC.Models.Entities;
using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Models.ViewModels.Feeds
{
    public class DbFeedItemViewModel : IFeedItemViewModel
    {
        public DbFeedItemViewModel(DbFeedItem item)
        {
            Title = item.Title;
            Description = item.Description;
            Link = item.Link;
            Guid = item.Guid;
            PublishedDate = item.PublishedDate;
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string PublishedDate { get; set; }
    }
}