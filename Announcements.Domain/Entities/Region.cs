using Announcements.Domain.Entities.Shared;

namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Регион
    /// </summary>
    public sealed class Region : BaseEntity<int>
    {
        /// <summary>
        /// Название региона
        /// </summary>
        public string Name { get; set; }
    }
}
