using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MojoMVC.ViewModels.Forms;

namespace MojoMVC.ApiControllers
{
    [RoutePrefix("api/feeds")]
    public class FeedsController : ApiController
    {
        [Route("")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        
        [Route("")]
        public HttpResponseMessage Post(FeedUrlInput input)
        {
            Console.WriteLine($"AddFeed action called: { input.FeedUrl }");
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}