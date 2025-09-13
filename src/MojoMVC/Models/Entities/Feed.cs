using System.Collections.Generic;

namespace MojoMVC.Models.Entities
{
    public class Feed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public virtual List<FeedItem> FeedItems { get; set; }
    }
}