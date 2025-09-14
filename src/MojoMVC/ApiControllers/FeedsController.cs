using System;
using System.Web.Http;
using MojoMVC.Infrastructure;
using MojoMVC.ViewModels.Forms;

namespace MojoMVC.ApiControllers
{
    [RoutePrefix("api/feeds")]
    public class FeedsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(FeedUrlInput input)
        {
            var rssClient = new RssClient();
            var feed = rssClient.GetFeedSourceFromUrl(input.FeedUrl);

            var repository = new FeedsRepository();
            
            repository.AddFeedSource(feed);
            
            return Ok();
        }
    }
}