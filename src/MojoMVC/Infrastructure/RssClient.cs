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
                dbFeed.FeedItems.Add(new FeedItem
                {
                    Title = item.Title.Text,
                    Description = item.Summary?.Text ?? string.Empty,
                    Link = item.Links.FirstOrDefault()?.Uri.ToString() ?? string.Empty,
                    Guid = item.Id,
                    PublishedDate = item.PublishDate.UtcDateTime.ToString("u"),
                    Content =
                        item.Content is TextSyndicationContent textContent ? textContent.Text :
                        item.Content is XmlSyndicationContent xmlContent ? xmlContent.ToString() :
                        item.Content is UrlSyndicationContent urlContent ? urlContent.ToString() : string.Empty
                });
            }

            return dbFeed;
        }
    }
}