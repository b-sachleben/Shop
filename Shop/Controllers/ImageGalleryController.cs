using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ImageGalleryController : Controller
    {
        // loads Image Gallery
        public ActionResult Index()
        {
            ViewBag.Title = "Brian Sachleben | Art";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_MainNavigation";
            ViewBag.ShopSection = false;

            return View();
        }

        // loads About Page
        public ActionResult About()
        {
            ViewBag.Title = "Brian Sachleben | About";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_MainNavigation";
            ViewBag.ShopSection = false;

            return View();
        }
    }
}