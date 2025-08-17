using System.Web.Mvc;
using MojoMVC.Infrastructure;

namespace MojoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilePathProvider _filePathProvider;

        public HomeController() : this(new FilePathProvider())
        {
            
        }

        public HomeController(IFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }
        
        public ActionResult Index()
        {
            var filePath = _filePathProvider.MapPath("~/App_Data/wiki-rss-example.xml");
            
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