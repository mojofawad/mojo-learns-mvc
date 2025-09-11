using System;
using System.Web.Mvc;

namespace MojoMVC.Controllers
{
    public class FeedsController : Controller
    {
        [HttpPost]
        public ActionResult AddFeed()
        {
            Console.WriteLine("AddFeed action called");
            return new HttpStatusCodeResult(200);
        }
    }
}