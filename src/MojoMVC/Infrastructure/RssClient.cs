using System.Net.Http;
using System.Threading.Tasks;
using MojoMVC.Models;

namespace MojoMVC.Infrastructure
{
    public class RssClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly RssParser _parser = new RssParser();
        
        public async Task<WebFeed> FetchRssFromUrl(string url = "https://feeds.megaphone.fm/FSI1483080183")
        {
            using (var response = await _httpClient.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        $"Failed to fetch feed from URL '{url}'. Status code: {(int)response.StatusCode} {response.StatusCode}.");
                }

                var someData = await response.Content.ReadAsStreamAsync();
                
                return _parser.DeserializeFeedFromStream(someData);
            }
        }
    }
}