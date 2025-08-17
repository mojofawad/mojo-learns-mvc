using System.Threading.Tasks;
using System.Web.Mvc;
using MojoMVC.Infrastructure;
using MojoMVC.Models;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var model = await RssService.RetrieveRssFeed();
            
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