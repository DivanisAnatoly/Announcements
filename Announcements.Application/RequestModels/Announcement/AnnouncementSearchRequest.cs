namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель поиска объявления
    /// </summary>
    public sealed class AnnouncementSearchRequest
    {
        /// <summary>
        /// Текст запроса
        /// </summary>
        public string RequestText { get; set; }

        ///<inheritdoc cref="Domain.Entities.Announcement.RegionID"/>
        public int? RegionID { get; set; }

        ///<inheritdoc cref="Domain.Entities.Announcement.CategoryID"/>
        public int? CategoryID { get; set; }


        //public decimal? Price { get; set; } //Цена услуги или товара
        //public DateTime PublishDate { get; set; }//Дата публикации объявления
    }
}
