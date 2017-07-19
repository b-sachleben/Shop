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
        // Begin Add Item section
        // loads form to accept info
        public ActionResult CreateItem()
        {
            ViewBag.Title = "Add Item";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            return View("AddItem");
        }

        // POST to server
        public ActionResult AddItem(Item item)
        {
            ViewBag.Title = "Add Item | Details";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.AddItem(item);
                return View("ViewDetails", item);
            }
        }
        // End Add Item section

        // Begin Edit Item section
        // GET item to edit
        public ActionResult EditItem(int id)
        {
            ViewBag.Title = "Edit Item";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            { 
                return View("EditItem", repo.GetItem(id));
            }
        }

        // POST edit to server
        public ActionResult ChangeItem(Item item)
        {
            ViewBag.Title = "Edit Item | Details";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.EditItem(item);
                return View("ViewDetails", repo.GetItem(item.ID));
            }
        }
        // End Edit Item section

        // Begin Delete Item section
        // GET item to delete
        public ActionResult DeleteItem(int id)
        {
            ViewBag.Title = "Delete Item | Confirm";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                return View("DeleteItem", repo.GetItem(id));
            }
        }

        // confirm action and POST to server
        public ActionResult ConfirmDelete(Item item)
        {
            ViewBag.Title = "List of Products";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            {
                repo.DeleteItem(item);
                return View("Shop", repo.Items.ToList());
            }
        }

        // GET list of items in database and display them
        public ActionResult Shop()
        {
            ViewBag.Title = "List of Products";
            // variable to load appropriate navigation section
            ViewBag.Navigation = "_ShopNavigation";
            ViewBag.ShopSection = true;

            using (var repo = new Repository())
            { 
                return View("Shop", repo.Items.ToList());
            }
        }
    }
}