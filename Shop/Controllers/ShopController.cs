using Dapper;
using Shop.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        static Repository _repository = new Repository();
        public ActionResult Index()
        {
            return View();
        }

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

            return View("AddItem");
        }

        public ActionResult AddItem(Item item)
        {
            ViewBag.Title = "Add Item | Details";

            _repository.AddItem(item);
            return View("ViewDetails", item);
        }

        //public ActionResult ViewDetails(Item item)
        //{
        //    return View();
        //}

        public ActionResult EditItem(int id)
        {
            ViewBag.Title = "Edit Item";

            return View("EditItem", _repository.GetItem(id));
        }

        public ActionResult ChangeItem(Item item)
        {
            ViewBag.Title = "Edit Item | Details";

            _repository.EditItem(item);

            return View("ViewDetails", _repository.GetItem(item.ID));
        }

        public ActionResult DeleteItem(int id)
        {
            ViewBag.Title = "Delete Item | Confirm";

            return View("DeleteItem", _repository.GetItem(id));
        }

        public ActionResult ConfirmDelete(int id)
        {
            ViewBag.Title = "List of Products";

            _repository.DeleteItem(id);

            return View("Shop", _repository.Items);
        }

        public ActionResult Shop()
        {
            ViewBag.Title = "List of Products";

            return View("Shop", _repository.Items);
        }
    }

    public class Repository
    {
        public void AddItem(Item item)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute("INSERT INTO Items (Title, Category, \"Description\", Price, NumberAvailable) VALUES (@Title, @Category, @Description, @Price, @NumberAvailable)", new { Title = item.Title, Category = item.Category, Description = item.Description, Price = item.Price, NumberAvailable = item.NumberAvailable });
            }
        }

        public void EditItem(Item item)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute("UPDATE Items SET Title = @Title, Category = @Category, \"Description\" = @Description, Price = @Price, NumberAvailable = @NumberAvailable WHERE ID = @Id", new { Title = item.Title, Category = item.Category, Description = item.Description, Price = item.Price, NumberAvailable = item.NumberAvailable, Id = item.ID });
            }
        }

        public void DeleteItem(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute("DELETE FROM Items WHERE ID = @ContactId", new { ContactId = id });
            }
        }

        public Item GetItem(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Item>("SELECT * FROM Items WHERE ID = @ContactId", new { ContactId = id });
            }
        }

        public List<Item> Items
        {
            get
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<Item>("SELECT * FROM Items").ToList();
                }
            }
        }

        private DbConnection CreateConnection()
        {
            return new SqlConnection("Server=(localDb)\\MsSqlLocalDb;Database=ShopDatabase;Trusted_Connection=true");
        }
    }
}