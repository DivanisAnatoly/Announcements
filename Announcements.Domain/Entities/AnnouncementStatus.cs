namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Статус объявления
    /// </summary>
    public enum AnnouncementStatus
    {
        /// <summary>
        /// Статус по умолчанию
        /// </summary>
        Normal,
        /// <summary>
        /// Объявление удалено
        /// </summary>
        Deleted,
        /// <summary>
        /// Объявление забанено
        /// </summary>
        Banned
    }
}
