using Announcements.Application.Interfaces.Services.Comments.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Comments
{
    /// <summary>
    /// Интерфейс сервиса объявлений
    /// </summary>
    public interface ICommentService
    {

        /// <summary>
        /// Создать комментарий
        /// </summary>
        Task<CreateCommentDTO.Response> CreateComment(CreateCommentDTO.Request createComments, CancellationToken cancellationToken);


        /// <summary>
        /// Получить информацию о объявлении по id
        /// </summary>
        Task<GetCommentDTO.Response> GetComment(int id, CancellationToken cancellationToken);


        /// <summary>
        /// Редактировать информацию об объявлении
        /// </summary>
        Task<EditCommentDTO.Response> EditComment(int commentID, EditCommentDTO.Request request, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить объявление
        /// </summary>
        Task DeleteComment(int id, CancellationToken cancellationToken);

    }
}
