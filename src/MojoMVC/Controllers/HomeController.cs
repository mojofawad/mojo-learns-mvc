using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.Models.Entities;
using MojoMVC.ViewModels;
using MojoMVC.ViewModels.Forms;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeedsRepository _repository = new FeedsRepository();
        private readonly RssClient _rssClient = new RssClient();
        
        public async Task<ActionResult> Index()
        {
            var feedFromWeb = _rssClient.GetFeedFromUrl();
            var feedsFromDb = await _repository.GetFeeds();
            
            var model = new HomeIndexViewModel(feedFromWeb, feedsFromDb);

            return View(model);
        }

        [HttpGet]
        public ActionResult AddFeed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PreviewFeed(FeedUrlInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFeed", input);
            }

            try
            {
                var feed = _rssClient.GetFeedFromUrl(input.FeedUrl);
                
                var feeds = new List<Feed>{ feed };
                
                return PartialView("~/Views/_Partials/_Feeds.cshtml", feeds);
            }
            catch
            {
                ModelState.AddModelError("FeedUrl", @"Unable to retrieve RSS feed");

                return View("AddFeed", input);
            }
        }

        public async Task<ActionResult> GetFeedById(int feedId)
        {
            var feed = await _repository.GetFeedById(feedId);
            var feeds = new List<Feed>{ feed };
            
            return PartialView("~/Views/_Partials/_Feeds.cshtml", feeds);
        }

        public async Task<ActionResult> RefreshFeedContent(int feedId)
        {
            var feed = await _repository.GetFeedById(feedId);
            
            var updatedFeed = _rssClient.GetFeedFromUrl(feed.Link);
            
            await _repository.AddLatestFeedItems(feedId, updatedFeed.FeedItems);
            
            var latestFeed = await _repository.GetFeedById(feedId);
            
            return PartialView("~/Views/_Partials/_FeedItems.cshtml", latestFeed.FeedItems);
        }
    }
}