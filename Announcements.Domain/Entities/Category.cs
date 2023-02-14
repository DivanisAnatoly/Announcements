using Announcements.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Категория
    /// </summary>
    public sealed class Category : MutableEntity<int>
    {
        /// <summary>
        /// id родительского объявления
        /// </summary>
        public int? ParentCategoryID { get; set; }
        public Category ParentCategory { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дочерние категории
        /// </summary>
        public ICollection<Category> ChildCategories { get; set; }

    }
}
