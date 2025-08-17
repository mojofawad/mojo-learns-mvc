using System.IO;
using System.Xml.Serialization;
using MojoMVC.Models;

namespace MojoMVC.Infrastructure
{
    public class RssParser
    {
        public Feed DeserializeFeedFromStream(Stream stream)
        {
            using (var fileStream = stream)
            {
                var serializer = new XmlSerializer(typeof(RssFeed));
    
                var myFeed = (RssFeed)serializer.Deserialize(fileStream);
    
                return myFeed.Channel;                       
            }
        }

        public Feed ConvertStreamToRssFeed(Stream someData)
        {
            return DeserializeFeedFromStream(someData);
        }
    }
}