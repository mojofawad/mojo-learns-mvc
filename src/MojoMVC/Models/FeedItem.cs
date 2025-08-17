using System.Xml.Serialization;

namespace MojoMVC.Models
{
    public class FeedItem
    {
        [XmlElement("title")]
        public string Title { get; set; }
        
        [XmlElement("description")]
        public string Description { get; set; }
        
        [XmlElement("link")]
        public string Link { get; set; }
        
        [XmlElement("guid")]
        public string Guid { get; set; }
        
        [XmlElement("pubDate")]
        public string PublishedDate { get; set; }
    }
}