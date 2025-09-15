using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class RssClient
    {
        public Feed GetFeedSourceFromUrl(string url = "https://feeds.megaphone.fm/FSI1483080183")
        {
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            var dbFeed = new Feed
            {
                Title = feed.Title.Text,
                Description = feed.Description.Text,
                Link = url
            };

            return dbFeed;
        }

        public Feed GetFeedFromUrl(string url = "https://feeds.megaphone.fm/FSI1483080183")
        {
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            
            var dbFeed = new Feed
            {
                Title = feed.Title.Text,
                Description = feed.Description.Text,
                Link = url,
                FeedItems = new List<FeedItem>()
            };

            foreach (var item in feed.Items)
            {
                var extensions = item.ElementExtensions.ToList();

                foreach (var extension in extensions)
                {
                    var extensionReader = extension.GetReader();
                    while (extensionReader.Read())
                    {
                        if (extensionReader.IsStartElement("content:encoded"))
                        {
                            var contentString = extensionReader.ReadElementContentAsString();
                            item.Content = SyndicationContent.CreateHtmlContent(contentString);
                        }
                    }
                }
                dbFeed.FeedItems.Add(new FeedItem
                {
                    Title = item.Title.Text,
                    Description = item.Summary?.Text ?? string.Empty,
                    Link = item.Links.FirstOrDefault()?.Uri.ToString() ?? string.Empty,
                    Guid = item.Id,
                    PublishedDate = item.PublishDate.UtcDateTime.ToString("u"),
                    Content = item.Content != null ? (item.Content as TextSyndicationContent)?.Text : string.Empty
                });
                
            }

            return dbFeed;
        }
    }
}