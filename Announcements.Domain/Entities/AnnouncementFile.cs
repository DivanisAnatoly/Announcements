using Announcements.Domain.Entities.Shared;

namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Файл объявлений
    /// </summary>
    public sealed class AnnouncementFile : MutableEntity<int>
    {
        /// <summary>
        /// id объявления к которому принадлежит файл
        /// </summary>
        public int AnnouncementID { get; set; }

        /// <summary>
        /// имя файла
        /// </summary>
        public string Name { get; set; }


        /// <inheritdoc cref="FileStatus"/>
        public FileStatus Status { get; set; }

    }
}
