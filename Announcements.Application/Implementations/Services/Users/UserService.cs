using Announcements.Application.Common;
using Announcements.Application.Identity.Contracts;
using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Application.Interfaces.Services.Users;
using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions;
using Announcements.Application.RequestModels;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Implementations.Services.Users
{

    /// <summary>
    /// Сервис пользователей
    /// </summary>
    /// <inheritdoc cref="IUserService"/>
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper,
            IFileService fileService, IIdentityService identityService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
            _mapper = mapper;
            _identityService = identityService;
        }


        /// <inheritdoc/>
        public async Task DeleteUser(string id, CancellationToken cancellationToken)
        {
            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);

            bool isAdmin = await _identityService.IsInRole(currentUserID, RoleConstants.AdminRole, cancellationToken);
            if (id != currentUserID && !isAdmin)
            {
                throw new UserNoRightsToDeleteException("Нет прав на удаление другого пользователя");
            }

            await _userRepository.Delete(id, cancellationToken);
            await _fileService.DeleteUserAvatar(id, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<GetUserDTO.Response> GetUser(string id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindById(id, cancellationToken);

            if (user == null || user.Status == UserStatus.Deleted)
            {
                throw new UserNotFoundException("Пользователь не найден");
            }

            var response = _mapper.Map<GetUserDTO.Response>(user);
            response.UserAvatarUri = await _fileService.GetUserAvatar(user.ID, cancellationToken);

            return response;
        }


        /// <inheritdoc/>
        public async Task<PagedList<UserPageItem>> GetUsersPaged(GetPagedUsersRequest request, CancellationToken cancellationToken)
        {
            var usersPage = await _userRepository.GetPaged(request, cancellationToken);
            usersPage.ForEach(u => u = _userRepository.FindById(u.ID, cancellationToken).Result);

            List<UserPageItem> usersItemsList = _mapper.Map<List<UserPageItem>>(usersPage);

            PagedList<UserPageItem> usersDTOsPage = new(usersItemsList, usersPage.Count, usersPage.CurrentPage, usersPage.PageSize);

            return usersDTOsPage;
        }


        /// <inheritdoc/>
        public async Task<RegisterUserDTO.Response> Register(RegisterUserDTO.Request request, CancellationToken cancellationToken)
        {
            CreateIdentityUserDTO.Request identityCreateRequest = _mapper.Map<CreateIdentityUserDTO.Request>(request);
            var createResponse = await _identityService.CreateUser(identityCreateRequest, cancellationToken);

            if (!createResponse.IsSuccess)
            {
                throw new IdentityUserNotFoundException("Ошибка при регистрации");
            }

            //User user = _mapper.Map<User>(request);
            User user = new();
            user.ID = createResponse.ID;
            user.Status = UserStatus.Normal;
            await _userRepository.Add(user, cancellationToken);

            if (request.UserAvatar?.Length > 0)
            {
                await _fileService.UploadUserAvatar(createResponse.ID, request.UserAvatar, cancellationToken);
            }

            return new RegisterUserDTO.Response { ID = createResponse.ID, UserName = request.UserName };
        }


        /// <inheritdoc/>
        public async Task<EditUserDTO.Response> Update(EditUserDTO.Request request, CancellationToken cancellationToken)
        {
            var currentUserID = await _identityService.GetCurrentUserId(cancellationToken);
            User user = await _userRepository.FindById(currentUserID, cancellationToken);

            if (user == null || user.Status == UserStatus.Deleted)
            {
                throw new UserNotFoundException("Пользователь не найден");
            }

            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;

            await _userRepository.Update(user, cancellationToken);

            if (request.UserAvatar?.Length > 0)
            {
                var userFile = await _fileService.GetUserAvatar(user.ID, cancellationToken);
                if (userFile == null)
                {
                    await _fileService.UploadUserAvatar(user.ID, request.UserAvatar, cancellationToken);
                }
                else
                {
                    await _fileService.UpdateUserAvatar(user.ID, request.UserAvatar, cancellationToken);
                }
            }

            return new EditUserDTO.Response { ID = user.ID };
        }

    }
}
