using Announcements.Application.Common;
using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Announcements;
using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Application.RequestModels.Announcement;
using Announcements.Application.RequestModels.Comment;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Implementations.Services.Announcements
{

    /// <summary>
    /// Сервис объявлений
    /// </summary>
    /// <inheritdoc cref="IAnnouncementService"/>
    public sealed class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IFileService _fileService;


        /// <summary>
        /// Конструктор
        /// </summary>
        public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper,
            IIdentityService identityService, ICommentRepository commentRepository, IFileService fileService)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
            _identityService = identityService;
            _commentRepository = commentRepository;
            _fileService = fileService;
        }


        /// <inheritdoc/>
        public async Task<CreateAnnouncementDTO.Response> CreateAnnouncement(CreateAnnouncementDTO.Request request, CancellationToken cancellationToken)
        {
            Announcement announcement = _mapper.Map<Announcement>(request);

            announcement.OwnerID = await _identityService.GetCurrentUserId(cancellationToken);
            announcement.PublishDate = DateTime.UtcNow.Date;

            await _announcementRepository.Add(announcement, cancellationToken);

            if (request.AnnouncementImages?.Count > 0)
            {
                await _fileService.UploadAnnouncementImages(announcement.ID, request.AnnouncementImages, cancellationToken);
            }

            return new CreateAnnouncementDTO.Response
            {
                ID = announcement.ID
            };
        }


        /// <inheritdoc/>
        public async Task DeleteAnnouncement(int id, CancellationToken cancellationToken)
        {
            Announcement announcement = await _announcementRepository.FindById(id, cancellationToken);
            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);

            bool isAdmin = await _identityService.IsInRole(currentUserID, RoleConstants.AdminRole, cancellationToken);

            if (announcement.OwnerID != currentUserID && !isAdmin)
            {
                throw new AnnouncementsNoRightsToDeleteException("Нет прав на удаление чужого объявления");
            }

            await _announcementRepository.DeleteAnnouncement(id, cancellationToken);
            await _fileService.DeleteAnnouncementImages(id, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<GetAnnouncementDTO.Response> GetAnnouncement(int id, CancellationToken cancellationToken)
        {
            Announcement announcement = await _announcementRepository.FindById(id, cancellationToken);

            if (announcement == null || announcement.Status != AnnouncementStatus.Normal)
            {
                throw new AnnouncementNotFoundException("Объявление не найдено");
            }

            var response = _mapper.Map<GetAnnouncementDTO.Response>(announcement);

            response.AnnouncementImagesUri = await _fileService.GetAnnouncementImages(announcement.ID, cancellationToken);

            return response;
        }


        /// <inheritdoc/>
        public async Task<EditAnnouncementDTO.Response> EditAnnouncement(int announcementID, EditAnnouncementDTO.Request request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.FindById(announcementID, cancellationToken);

            if (announcement == null || announcement.Status != AnnouncementStatus.Normal)
            {
                throw new AnnouncementNotFoundException("Объявление не найдено");
            }

            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);

            if (announcement.OwnerID != currentUserID)
            {
                throw new AnnouncementsNoRightsToEditException("Нет прав на редактирование чужого объявления");
            }

            announcement = _mapper.Map(request, announcement);
            await _announcementRepository.Update(announcement, cancellationToken);

            if (request.DeletedAnnouncementFiles?.Count > 0)
            {
                await _fileService.DeleteAnnouncementImages(announcement.ID, request.DeletedAnnouncementFiles, cancellationToken);
            }
            if (request.NewAnnouncementFiles?.Count > 0)
            {
                await _fileService.UploadAnnouncementImages(announcement.ID, request.NewAnnouncementFiles, cancellationToken);
            }

            return new EditAnnouncementDTO.Response { ID = announcement.ID };
        }


        /// <inheritdoc/>
        public async Task<PagedList<AnnouncementPageItem>> GetAnnouncementsPaged(GetPagedAnnouncementsRequest request, CancellationToken cancellationToken)
        {
            var announcementsPage = await _announcementRepository.GetPaged(request, cancellationToken);
            announcementsPage.ForEach(u => u = _announcementRepository.FindById(u.ID, cancellationToken).Result);

            List<AnnouncementPageItem> announcementsItemsList = _mapper.Map<List<AnnouncementPageItem>>(announcementsPage);

            PagedList<AnnouncementPageItem> announcementsDTOsPage = new(announcementsItemsList, announcementsPage.Count, announcementsPage.CurrentPage, announcementsPage.PageSize);
            announcementsDTOsPage.ForEach(i => i.AnnouncementFaceImageUri = _fileService.GetAnnouncementFaceImage(i.ID, cancellationToken).Result);

            return announcementsDTOsPage;
        }


        /// <inheritdoc/>
        public async Task<PagedList<CommentPageItem>> GetAnnouncementCommentsPaged(int announcementID, GetPagedCommentsRequest request, CancellationToken cancellationToken)
        {
            var announcementsComments = await _commentRepository.GetAnnouncementComments(announcementID, request, cancellationToken);

            List<CommentPageItem> commentsItemsList = _mapper.Map<List<CommentPageItem>>(announcementsComments);

            PagedList<CommentPageItem> commentsDTOsPage = new(commentsItemsList, announcementsComments.Count, announcementsComments.CurrentPage, announcementsComments.PageSize);
            commentsDTOsPage.ForEach(i => i.UserAvatarUri = _fileService.GetUserAvatar(i.AuthorID, cancellationToken).Result);

            return commentsDTOsPage;
        }

    }
}
