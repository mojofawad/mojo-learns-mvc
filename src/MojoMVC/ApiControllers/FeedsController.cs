using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MojoMVC.Infrastructure;
using MojoMVC.Models.Entities;
using MojoMVC.ViewModels.Forms;

namespace MojoMVC.ApiControllers
{
    [RoutePrefix("api/feeds")]
    public class FeedsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
        
        // QUESTION: Difference between IHttpActionResult and HttpResponseMessage
        // QUESTION: is Task<IHttpActionResult> a double Task? 
        [Route("")]
        public async Task<IHttpActionResult> Post(FeedUrlInput input)
        {
            var rssClient = new RssClient();
            var rssFeed = await rssClient.GetRssFeed(input.FeedUrl);

            var feed = new DbFeed
            {
                Title = rssFeed.Title,
                Description = rssFeed.Description,
                Link = input.FeedUrl
            };

            var repository = new FeedsRepository();
            repository.AddFeed(feed);
            
            return Ok();
        }
    }
}