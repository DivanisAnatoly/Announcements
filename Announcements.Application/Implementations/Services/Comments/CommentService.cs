using Announcements.Application.Common;
using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions;
using Announcements.Application.Interfaces.Services.Comments;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Domain.Entities;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Implementations.Services.Comments
{

    /// <summary>
    /// Сервис комментариев
    /// </summary>
    /// <inheritdoc cref="ICommentService"/>
    public sealed class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IFileService _fileService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CommentService(ICommentRepository commentRepository, IMapper mapper,
            IIdentityService identityService, IFileService fileService)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _identityService = identityService;
            _fileService = fileService;
        }


        /// <inheritdoc/>
        public async Task<CreateCommentDTO.Response> CreateComment(CreateCommentDTO.Request request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            comment.AuthorID = await _identityService.GetCurrentUserId(cancellationToken);

            await _commentRepository.Add(comment, cancellationToken);

            return new CreateCommentDTO.Response
            {
                ID = comment.ID
            };
        }


        /// <inheritdoc/>
        public async Task DeleteComment(int id, CancellationToken cancellationToken)
        {
            Comment comment = await _commentRepository.FindById(id, cancellationToken);

            if (comment == null || comment.Status != CommentStatus.Normal)
            {
                throw new CommentNotFoundException("Comment not found");
            }

            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);

            bool isAdmin = await _identityService.IsInRole(currentUserID, RoleConstants.AdminRole, cancellationToken);

            if (comment.AuthorID != currentUserID && !isAdmin)
            {
                throw new CommentNoRightsToEditException("Нет прав на удаление чужого комментария");
            }

            await _commentRepository.DeleteComment(id, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<GetCommentDTO.Response> GetComment(int id, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.FindById(id, cancellationToken);
            if (comment == null || comment.Status != CommentStatus.Normal)
            {
                throw new CommentNotFoundException("Комментарий не найден");
            }

            var response = _mapper.Map<GetCommentDTO.Response>(comment);
            response.AuthorAvatarUri = await _fileService.GetUserAvatar(response.AuthorID, cancellationToken);

            return response;
        }


        /// <inheritdoc/>
        public async Task<EditCommentDTO.Response> EditComment(int commentID, EditCommentDTO.Request request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.FindById(commentID, cancellationToken);

            if (comment == null || comment.Status != CommentStatus.Normal)
            {
                throw new CommentNotFoundException("Комментарий не найден");
            }

            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);
            if (comment.AuthorID != currentUserID)
            {
                throw new CommentNoRightsToEditException("Нет прав редактирования чужого комментария");
            }

            comment = _mapper.Map(request, comment);

            await _commentRepository.Update(comment, cancellationToken);

            return new EditCommentDTO.Response { ID = comment.ID };
        }

    }
}
