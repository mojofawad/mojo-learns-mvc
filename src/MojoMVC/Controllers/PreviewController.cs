using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.ViewModels.Feeds;
using MojoMVC.ViewModels.Forms;
using MojoMVC.ViewModels.Interfaces;

namespace MojoMVC.Controllers
{
    public class PreviewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PreviewFeed(FeedUrlInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", input);
            }

            try
            {
                var rssClient = new RssClient();
                var feed = await rssClient.FetchRssFromUrl(input.FeedUrl);
                
                var feedViewModels = new List<IFeedViewModel> { new WebFeedViewModel(feed) };

                return PartialView("~/Views/_Partials/_Feeds.cshtml", feedViewModels);
            }
            catch
            {
                ModelState.AddModelError("FeedUrl", @"Unable to retrieve RSS feed");

                return View("Index", input);
            }
        }
    }
}