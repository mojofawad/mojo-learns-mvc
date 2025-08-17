using System;
using System.Net.Http;
using System.Threading.Tasks;
using MojoMVC.Models;

namespace MojoMVC.Infrastructure
{
    public class RssClient
    {
        public async Task<Feed> FetchRssFromUrl(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }

            var someData = await response.Content.ReadAsStreamAsync();
                
            var parser = new RssParser();
            return parser.ConvertStreamToRssFeed(someData);
        }
    }
}