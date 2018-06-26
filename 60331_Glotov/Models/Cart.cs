using _60331_Glotov.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60331_Glotov.Models
{
    public class Cart
    {
        private Dictionary<int, CartItem> cartItems;

        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="book">объект добавления в корзину</param>
        public void AddItem(Book book)
        {
            if (cartItems.ContainsKey(book.BookId))
            {
                cartItems[book.BookId].Quantity += 1;
            }
            else
            {
                cartItems.Add(book.BookId, new CartItem { Book = book, Quantity = 1 });
            }
        }

        /// <summary>
        /// Удаление из корзины
        /// </summary>
        /// <param name="book">объект для удаления</param>
        public void RemoveItem(Book book)
        {
            if (cartItems[book.BookId].Quantity == 1)
            {
                cartItems.Remove(book.BookId);
            }
            else
            {
                cartItems[book.BookId].Quantity -= 1;
            }
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }

        /// <summary>
        /// Получение общей стоимости
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return cartItems.Values.Sum(x => x.Book.Price * x.Quantity);
        }

        /// <summary>
        /// Получение содержимого корзины
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }
    }
}