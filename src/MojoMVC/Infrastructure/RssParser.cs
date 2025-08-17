using System;
using System.IO;
using System.Xml.Serialization;
using MojoMVC.Models;

namespace MojoMVC.Infrastructure
{
    public class RssParser
    {
        public Feed DeserializeFeedFromStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "Stream parameter cannot be null.");
            }
            using (var fileStream = stream)
            {
                var serializer = new XmlSerializer(typeof(RssFeed));
    
                var myFeed = (RssFeed)serializer.Deserialize(fileStream);
    
                return myFeed.Channel;                       
            }
        }
    }
}