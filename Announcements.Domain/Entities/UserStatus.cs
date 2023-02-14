namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Статус пользователя
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Статус по умолчанию
        /// </summary>
        Normal,

        /// <summary>
        /// Пользователь удален
        /// </summary>
        Deleted,

        /// <summary>
        /// Пользователь забанен
        /// </summary>
        Banned
    }
}
