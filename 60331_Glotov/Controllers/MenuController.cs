using _60331_Glotov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60331_Glotov.DAL;

namespace _60331_Glotov.Controllers
{
    public class MenuController : Controller
    {
        IRepository<Book> repository;

        List<MenuItem> items;

        public MenuController(IRepository<Book> repository)
        {
            this.repository = repository;

            items = new List<MenuItem>
            {
                new MenuItem { Name = "Домой", Controller = "Home", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Каталог", Controller = "Book", Action = "List", Active = string.Empty },
                new MenuItem { Name = "Администратор", Controller = "Admin", Action = "Index", Active = string.Empty }
            };
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            MenuItem item = items.FirstOrDefault(x => x.Controller == c);
            if (item != null)
            {
                item.Active = "active";
            }
            //items.First(x => x.Controller == c).Active = "active";
            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            IEnumerable<string> categories = repository.GetAll().Select(d => d.CategoryName).Distinct();
            return PartialView(categories);
        }

        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}