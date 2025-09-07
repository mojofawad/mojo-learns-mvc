using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Models.ViewModels.Forms;

namespace MojoMVC.Controllers
{
    public class PreviewController : Controller
    {
        [HttpGet]
        public ActionResult Index(PreviewInput previewInput)
        {
            return View(previewInput);
        }

        [HttpPost]
        public async Task<ActionResult> PreviewFeed(PreviewInput input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var feed = await RssService.RetrieveRssFeed(input.FeedUrl);

            return View(feed);
        }
    }
}