using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Models.ViewModels.Forms;

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

                return View(feed);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FeedUrl", $"Unable to retrieve RSS feed");

                return View("Index", input);
            }
        }
    }
}