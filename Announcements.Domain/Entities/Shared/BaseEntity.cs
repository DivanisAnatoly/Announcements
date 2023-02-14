namespace Announcements.Domain.Entities.Shared
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class BaseEntity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TId ID { get; set; }
    }
}
