using Dapper;
using Shop.Models;
using Shop.Repositories;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult CreateItem()
        {
            ViewBag.Title = "Add Item";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            return View("AddItem");
        }

        public ActionResult AddItem(Item item)
        {
            ViewBag.Title = "Add Item | Details";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.AddItem(item);
                return View("ViewDetails", item);
            }
        }

        //public ActionResult ViewDetails(Item item)
        //{
        //    return View();
        //}

        public ActionResult EditItem(int id)
        {
            ViewBag.Title = "Edit Item";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            { 
                return View("EditItem", repo.GetItem(id));
            }
        }

        public ActionResult ChangeItem(Item item)
        {
            ViewBag.Title = "Edit Item | Details";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.EditItem(item);
                return View("ViewDetails", repo.GetItem(item.ID));
            }
        }

        public ActionResult DeleteItem(int id)
        {
            ViewBag.Title = "Delete Item | Confirm";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                return View("DeleteItem", repo.GetItem(id));
            }
        }

        public ActionResult ConfirmDelete(Item item)
        {
            ViewBag.Title = "List of Products";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.DeleteItem(item);
                return View("Shop", repo.Items.ToList());
            }
        }

        public ActionResult Shop()
        {
            ViewBag.Title = "List of Products";
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            { 
                return View("Shop", repo.Items.ToList());
            }
        }
    }
}