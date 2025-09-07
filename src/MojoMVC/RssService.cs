using System.Threading.Tasks;
using MojoMVC.Infrastructure;
using MojoMVC.Models;

namespace MojoMVC
{
    public class RssService
    {
        public static async Task<WebFeed> RetrieveRssFeed(string feedUrl = "https://feeds.megaphone.fm/FSI1483080183")
        {
            var rssClient = new RssClient();

            var feed = await rssClient.FetchRssFromUrl(feedUrl);

            return feed;
        }
    }
}