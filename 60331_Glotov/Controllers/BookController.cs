using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60331_Glotov.DAL;
using _60331_Glotov.Models;
using System.Threading.Tasks;

namespace _60331_Glotov.Controllers
{
    public class BookController : Controller
    {
        IRepository<Book> repository;
        int pageSize = 3;

        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        // GET: Book
        public ActionResult List(string category, int page = 1)
        {
            IEnumerable<Book> list = repository.GetAll().
                                                Where(x => category == null || x.CategoryName.Equals(category)).
                                                OrderBy(x => x.Price);

            PageListViewModel<Book> model = PageListViewModel<Book>.CreatePage(list, page, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }

            return View(model);
        }

        public async Task<FileContentResult> GetImage(int id)
        {
            Book book = await repository.GetAsync(id);
            if (book != null)
            {
                return new FileContentResult(book.Image, book.MimeType);
            }
            else return null;
        }
    }
}