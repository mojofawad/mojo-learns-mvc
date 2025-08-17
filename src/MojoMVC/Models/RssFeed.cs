using System.Xml.Serialization;

namespace MojoMVC.Models
{
    [XmlRoot("rss")]
    public class RssFeed
    {
        [XmlElement("channel")]
        public Feed Channel { get; set; }
    }
}