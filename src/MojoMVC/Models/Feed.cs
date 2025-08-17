using System.Collections.Generic;
using System.Xml.Serialization;

namespace MojoMVC.Models
{
    [XmlRoot("channel")]
    public class Feed
    {
        [XmlElement("title")]
        public string Title { get; set; }
        
        [XmlElement("description")]
        public string Description { get; set; }
        
        [XmlElement("link")]
        public string Link { get; set; }
        
        [XmlElement("item")]
        public List<FeedItem> Items { get; set; }
    }
}