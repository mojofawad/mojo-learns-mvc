using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MojoMVC.Models;

namespace MojoMVC
{
    public class RssParser
    {
        public string GetFeedTitle(string filePath)
        {
            var feed = GetRssFeed(filePath);

            return feed.Title;
        }

        public List<FeedItem> GetFeedItems(string filePath)
        {
            var feed = GetRssFeed(filePath);
            return feed.Items;
        }

        public Feed GetRssFeed(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(RssFeed));
    
                var myFeed = (RssFeed)serializer.Deserialize(fileStream);
    
                return myFeed.Channel;                       
            }
        }
    }
}