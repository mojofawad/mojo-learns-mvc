using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.Models.ViewModels;
using MojoMVC.Models.ViewModels.Feeds;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var rssFeed = await RssService.RetrieveRssFeed();
            var dbFeedItems = await FeedRepository.GetFeedsFromDb();

            var webFeedViewModel = new WebFeedViewModel(rssFeed);
            var dbFeedViewModels = dbFeedItems.Select(f => new DbFeedViewModel(f)).ToList();

            var model = new HomeIndexViewModel(webFeedViewModel, dbFeedViewModels);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}