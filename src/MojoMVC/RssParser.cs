using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Ajax.Utilities;
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
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("filePath cannot be null, empty, or whitespace.", nameof(filePath));
            }
            
            var feed = GetRssFeed(filePath);
            return feed.Items;
        }

        public Feed GetRssFeed(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path must not be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' does not exist.", filePath);
            }
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(RssFeed));
    
                var myFeed = (RssFeed)serializer.Deserialize(fileStream);
    
                return myFeed.Channel;                       
            }
        }
    }
}