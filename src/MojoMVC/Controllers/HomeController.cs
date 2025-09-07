using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.Models.ViewModels;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var rssFeed = await RssService.RetrieveRssFeed();
            var dbFeedItems = await FeedRepository.GetFeedItemsFromDb();
            
            var model = new IndexViewModel(rssFeed, dbFeedItems);
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