using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60331_Glotov.Models
{
    public class PageListViewModel<T> : List<T>
    {
        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; private set; }

        private PageListViewModel(List<T> items, int totalPage, int currentPage)
        {
            AddRange(items);
            TotalPages = totalPage;
            CurrentPage = currentPage;
        }

        public static PageListViewModel<T> CreatePage(IEnumerable<T> items, int currentPage, int pageSize)
        {
            int totalCount = items.Count();
            int pagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            IEnumerable<T> list = items.Skip(pageSize * (currentPage - 1)).Take(pageSize);
            return new PageListViewModel<T>(list.ToList(), pagesCount, currentPage);
        }
    }
}