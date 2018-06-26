using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60331_Glotov.DAL;

namespace _60331_Glotov.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository<Book> repository;

        public AdminController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Book book = new Book();
            return View(book);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    int count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            else return View(book);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    int count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            else return View(book);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
