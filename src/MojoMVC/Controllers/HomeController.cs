using System;
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
        public async Task<ActionResult> Index()
        {
            var rssClient = new RssClient();
            var rssFeed = await rssClient.FetchRssFromUrl();
            
            var dbFeedItems = await FeedRepository.GetFeedsFromDb();

            var webFeedViewModel = new WebFeedViewModel(rssFeed);
            var dbFeedViewModels = dbFeedItems.Select(f => new DbFeedViewModel(f)).ToList();

            var model = new HomeIndexViewModel(webFeedViewModel, dbFeedViewModels);

            return View(model);
        }

        [HttpGet]
        public ActionResult AddFeed()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PreviewFeed(FeedUrlInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFeed", input);
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

                return View("AddFeed", input);
            }
        }
    }
}