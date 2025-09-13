namespace MojoMVC.Models.Entities
{
    public class FeedItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string PublishedDate { get; set; }

        public int DbFeedId { get; set; }
        public virtual Feed Feed { get; set; }
    }
}