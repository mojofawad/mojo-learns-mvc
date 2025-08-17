using System.Web.Mvc;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            const string filePath = @"D:\self\mojo-learns-mvc\xml-samples\wiki-rss-example.xml";
            
            var model = new RssParser().GetRssFeed(filePath);
            
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