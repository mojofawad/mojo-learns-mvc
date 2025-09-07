using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Models.ViewModels.Feeds;
using MojoMVC.Models.ViewModels.Forms;
using MojoMVC.Models.ViewModels.Interfaces;

namespace MojoMVC.Controllers
{
    public class PreviewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PreviewInput());
        }

        [HttpPost]
        public async Task<ActionResult> PreviewFeed(PreviewInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", input);
            }

            try
            {
                var feed = await RssService.RetrieveRssFeed(input.FeedUrl);
                var feedViewModels = new List<IFeedViewModel> { new WebFeedViewModel(feed) };

                return PartialView("~/Views/_Partials/_Feeds.cshtml", feedViewModels);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FeedUrl", $"Unable to retrieve RSS feed");

                return View("Index", input);
            }
        }
    }
}