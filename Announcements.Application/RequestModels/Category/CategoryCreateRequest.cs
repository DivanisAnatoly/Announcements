namespace Announcements.Application.RequestModels
{

    /// <summary>
    /// Модель создания категории
    /// </summary>
    public sealed class CategoryCreateRequest
    {
        ///<inheritdoc cref="Domain.Entities.Category.Name"/> 
        public string Name { get; set; }


        ///<inheritdoc cref="Domain.Entities.Category.ParentCategoryID"/>
        public int? ParentCategoryID { get; set; }

    }
}
