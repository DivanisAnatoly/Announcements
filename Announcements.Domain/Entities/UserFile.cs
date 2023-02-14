using Announcements.Domain.Entities.Shared;

namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Файл пользователя
    /// </summary>
    public sealed class UserFile : MutableEntity<int>
    {
        /// <summary>
        /// id пользователя к которому принадлежит файл
        /// </summary>
        public string UserID { get; set; }


        /// <summary>
        /// Имя файла в облаке
        /// </summary>
        public string Name { get; set; }


        /// <inheritdoc cref="FileStatus"/>
        public FileStatus Status { get; set; }
    }
}
