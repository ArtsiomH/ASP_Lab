using _60331_Glotov.DAL;
using _60331_Glotov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60331_Glotov.Controllers
{
    public class CartController : Controller
    {
        IRepository<Book> repository;

        public CartController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(Cart cart, string returnUrl)
        {
            if (returnUrl != null)
            {
                TempData["returnUrl"] = returnUrl;
            }
            return View(cart);
        }

        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        //public Cart GetCart()
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        /// <summary>
        /// добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnurl">url страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Book book = repository.Get(id);
            if (book != null)
            {
                cart.AddItem(book);
                TempData["addedBook"] = book.BookName;
            }
            return Redirect(returnUrl);
        }

        ///// <summary>
        ///// Добавление товара в корзину
        ///// </summary>
        ///// <param name="id">id добавляемого элемента</param>
        ///// <returns></returns>
        //public ActionResult AddToCart(int id)
        //{
        //    Book book = repository.Get(id);
        //    if (book != null)
        //    {
        //        GetCart().AddItem(book);
        //        ViewBag.AddItem = book.BookName;
        //    }
        //    return PartialView(book);
        //}

        public ActionResult DeleteFromCart(Cart cart, int id, string returnUrl)
        {
            Book book = repository.Get(id);
            if (book != null)
            {
                cart.RemoveItem(book);
            }
            if (returnUrl != null)
            {
                TempData["returnUrl"] = returnUrl;
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult CartSummary(Cart cart, string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(cart);
        }
    }
}