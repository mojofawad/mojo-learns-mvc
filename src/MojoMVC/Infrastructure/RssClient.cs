using System.Net.Http;
using System.Threading.Tasks;
using MojoMVC.Models;

namespace MojoMVC.Infrastructure
{
    public class RssClient
    {
        private static readonly HttpClient httpClient = new HttpClient();
        
        public async Task<WebFeed> FetchRssFromUrl(string url)
        {
            using (var response = await httpClient.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        $"Failed to fetch feed from URL '{url}'. Status code: {(int)response.StatusCode} {response.StatusCode}.");
                }

                var someData = await response.Content.ReadAsStreamAsync();

                var parser = new RssParser();
                return parser.DeserializeFeedFromStream(someData);
            }
        }
    }
}