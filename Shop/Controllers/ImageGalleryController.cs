using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ImageGalleryController : Controller
    {
        // GET: ImageGallery
        public ActionResult Index()
        {
            ViewBag.Title = "Brian Sachleben | Art";
            ViewBag.Navigation = "_MainNavigation";
            ViewBag.ShopSection = false;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Brian Sachleben | About";
            ViewBag.Navigation = "_MainNavigation";
            ViewBag.ShopSection = false;

            return View();
        }
    }
}