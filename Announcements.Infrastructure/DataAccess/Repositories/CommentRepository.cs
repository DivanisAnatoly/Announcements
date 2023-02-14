using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions;
using Announcements.Application.RequestModels.Comment;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{
    /// <summary>Репозиторий коментариев</summary>
    /// <inheritdoc cref="ICommentRepository"/>
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CommentRepository(AnnouncementDBContext DBContext, IUserRepository userRepository) : base(DBContext)
        {
            _userRepository = userRepository;
        }



        ///<inheritdoc/>
        public async Task DeleteComment(int id, CancellationToken cancellationToken)
        {
            var comment = await FindById(id, cancellationToken);

            if (comment == null || comment.Status != CommentStatus.Normal)
            {
                throw new CommentNotFoundException("Comment not found");
            }

            comment.Status = CommentStatus.Deleted;
            _DBContext.Comments.Update(comment);

            await Save(cancellationToken);
        }


        ///<inheritdoc/>
        public async Task<IEnumerable<Comment>> GetAllComments(CancellationToken cancellationToken)
        {
            return await FindAll().Where(c => c.Status == CommentStatus.Normal).ToListAsync(cancellationToken);
        }


        ///<inheritdoc/>
        public async Task<PagedList<Comment>> GetAnnouncementComments(int announcementID, GetPagedCommentsRequest request, CancellationToken cancellationToken)
        {
            var announcementComments = FindAll().Where(a => a.AnnouncementID == announcementID);
            await announcementComments.ForEachAsync(c => c.Author = _userRepository.FindById(c.AuthorID, cancellationToken).Result, cancellationToken);
            return await Task.FromResult(PagedList<Comment>.ToPagedList(announcementComments,
                request.PageNumber,
                request.PageSize));
        }


        public new async Task<Comment> FindById(int id, CancellationToken cancellationToken)
        {
            Comment comment = await base.FindById(id, cancellationToken);
            if (comment == null) return null;

            comment.Author = await _userRepository.FindById(comment.AuthorID, cancellationToken);
            return comment;
        }

    }

}
