using System.Threading.Tasks;
using MojoMVC.Infrastructure;
using MojoMVC.Models;

namespace MojoMVC
{
    public class RssService
    {
        public static async Task<Feed> RetrieveRssFeed()
        {
            var rssClient = new RssClient();
            
            var feed = await rssClient.FetchRssFromUrl("https://feeds.megaphone.fm/FSI1483080183");
            
            return feed;
        }
    }
}