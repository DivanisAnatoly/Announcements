namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель запроса на постраничный вывод пользователей
    /// </summary>
    public class GetPagedUsersRequest
    {
        const int maxPageSize = 50;

        private int _pageSize = 10;


        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; } = 1;


        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
