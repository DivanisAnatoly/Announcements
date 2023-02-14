using Announcements.Application.Interfaces.Services.Comments;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.RequestModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;


namespace Announcements.API.Controllers.Comments
{
    /// <summary>
    /// Контроллер коментариев
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;


        /// <summary>
        /// Конструктор
        /// </summary>
        public CommentsController(ICommentService commentsService, IMapper mapper)
        {
            _commentService = commentsService;
            _mapper = mapper;
        }


        /// <summary>
        /// Создает коментарий
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> CreateComment([FromForm] CommentCreateRequest AddCommentRequest, CancellationToken cancellationToken)
        {
            CreateCommentDTO.Request request = _mapper.Map<CreateCommentDTO.Request>(AddCommentRequest);
            var response = await _commentService.CreateComment(request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Возвращает комментарий по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetComment(int id, CancellationToken cancellationToken)
        {
            var comment = await _commentService.GetComment(id, cancellationToken);
            return Ok(comment);
        }


        /// <summary>
        /// Редактировать коментарий
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> EditComment([FromForm] CommentEditRequest editRequest, CancellationToken cancellationToken)
        {
            EditCommentDTO.Request request = _mapper.Map<EditCommentDTO.Request>(editRequest);
            var response = await _commentService.EditComment(editRequest.ID, request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Удаляет комментарий
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteComment(int id, CancellationToken cancellationToken)
        {
            await _commentService.DeleteComment(id, cancellationToken);
            return Ok($"Comment was successfully deleted");
        }

    }
}
