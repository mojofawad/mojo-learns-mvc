using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.ViewModels;
using MojoMVC.ViewModels.Feeds;
using MojoMVC.ViewModels.Forms;
using MojoMVC.ViewModels.Interfaces;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeedsRepository _repository = new FeedsRepository();
        private readonly RssClient _rssClient = new RssClient();
        
        public async Task<ActionResult> Index()
        {
            var rssFeed = _rssClient.GetFeedFromUrl();
            var dbFeeds = await _repository.GetFeeds();
            
            var feedFromWeb = new DbFeedViewModel(rssFeed);
            var feedFromDb = dbFeeds.Select(f => new DbFeedViewModel(f)).ToList();

            var model = new HomeIndexViewModel(feedFromWeb, feedFromDb);

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
                
                var feedViewModels = new List<IFeedViewModel> { new DbFeedViewModel(feed) };

                return PartialView("~/Views/_Partials/_Feeds.cshtml", feedViewModels);
            }
            catch
            {
                ModelState.AddModelError("FeedUrl", @"Unable to retrieve RSS feed");

                return View("AddFeed", input);
            }
        }
    }
}