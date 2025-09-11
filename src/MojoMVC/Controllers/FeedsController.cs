using System;
using System.Web.Mvc;
using MojoMVC.ViewModels.Forms;

namespace MojoMVC.Controllers
{
    public class FeedsController : Controller
    {
        [HttpPost]
        public ActionResult AddFeed(FeedUrlInput input)
        {
            Console.WriteLine($"AddFeed action called: { input.FeedUrl }");
            return new HttpStatusCodeResult(200);
        }
    }
}