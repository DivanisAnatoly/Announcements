using System;
using System.Collections.Generic;
using System.Linq;

namespace Announcements.Domain.Helpers
{

    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// Текущая страница
        /// </summary>
        public int CurrentPage { get; private set; }


        /// <summary>
        /// Всего страниц
        /// </summary>
        public int TotalPages { get; private set; }


        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; private set; }


        /// <summary>
        /// Общее число объектов выводы
        /// </summary>
        public int TotalCount { get; private set; }


        /// <summary>
        /// Наличие предыдущей страницы
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;


        /// <summary>
        /// Наличие следующей страницы
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="items">Список объектов страницыы</param>
        /// <param name="count">Общее кол-во объектов</param>
        /// <param name="pageNumber">Номер текущей страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }


        /// <summary>
        /// Получить страницу объектов
        /// </summary>
        /// <param name="source">Источник перечня объектов</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns>Страницу с указанными номером и числом объектов</returns>
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

    }
}
