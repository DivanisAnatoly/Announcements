using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.CloudStorage;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Implementations.Services.Files
{
    /// <summary>
    /// Файловый сервис
    /// </summary>
    /// <inheritdoc cref="IFileService"/>
    public class FileService : IFileService
    {
        private readonly IUserFileRepository _userFileRepository;
        private readonly IAnnouncementFileRepository _announcementFileRepository;
        private readonly ICloudStorageClient _cloudStorageClient;

        /// <inheritdoc/>
        public FileService(IUserFileRepository fileRepository, ICloudStorageClient cloudStorageClient,
            IAnnouncementFileRepository announcementFileRepository)
        {
            _userFileRepository = fileRepository;
            _cloudStorageClient = cloudStorageClient;
            _announcementFileRepository = announcementFileRepository;

        }


        /// <inheritdoc/>
        public async Task DeleteUserAvatar(string userID, CancellationToken cancellationToken)
        {
            await _userFileRepository.DeleteUserAvatar(userID, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<List<Uri>> GetAnnouncementImages(int announcementID, CancellationToken cancellationToken)
        {
            await _cloudStorageClient.Login();

            var announcementFiles = await _announcementFileRepository.FindImagesByAnnouncementId(announcementID, cancellationToken);

            if (announcementFiles == null)
            {
                return null;
            }

            var downloadLinks = await _cloudStorageClient.GetAnnouncementImagesURIs(announcementFiles);

            await _cloudStorageClient.Logout();

            return downloadLinks;

        }


        /// <inheritdoc/>
        public async Task<Uri> GetAnnouncementFaceImage(int announcementID, CancellationToken cancellationToken)
        {
            await _cloudStorageClient.Login();

            var announcementFile = await _announcementFileRepository.FindAnnouncementFaceImage(announcementID, cancellationToken);

            if (announcementFile == null)
            {
                return null;
            }

            var downloadLink = await _cloudStorageClient.GetAnnouncementImageURI(announcementFile);

            await _cloudStorageClient.Logout();

            return downloadLink;
        }


        /// <inheritdoc/>
        public async Task<Uri> GetUserAvatar(string userID, CancellationToken cancellationToken)
        {
            await _cloudStorageClient.Login();

            UserFile userFile = await _userFileRepository.FindAvatarByUserId(userID, cancellationToken);

            if (userFile == null)
            {
                return null;
            }

            Uri downloadLink = await _cloudStorageClient.GetUserAvatarUri(userFile);

            await _cloudStorageClient.Logout();

            return downloadLink;
        }


        /// <inheritdoc/>
        public async Task UpdateUserAvatar(string userID, IFormFile userAvatar, CancellationToken cancellationToken)
        {
            await DeleteUserAvatar(userID, cancellationToken);
            await UploadUserAvatar(userID, userAvatar, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task DeleteAnnouncementImages(int announcementID, List<Uri> announcementFilesURI, CancellationToken cancellationToken)
        {
            string fileName;

            await _cloudStorageClient.Login();

            foreach (Uri fileURI in announcementFilesURI)
            {
                fileName = await _cloudStorageClient.GetFileName(fileURI);

                await _announcementFileRepository.DeleteAnnouncementImage(announcementID, fileName, cancellationToken);
            }
            await _cloudStorageClient.Logout();
        }


        /// <inheritdoc/>
        public async Task UploadAnnouncementImages(int announcementID, List<IFormFile> announcementFiles, CancellationToken cancellationToken)
        {
            await _cloudStorageClient.Login();

            var fileNames = await _cloudStorageClient.UploadAnnouncementImages(announcementFiles);

            await _cloudStorageClient.Logout();

            foreach (string fileName in fileNames)
            {
                AnnouncementFile file = new() { Name = fileName, AnnouncementID = announcementID, Status = FileStatus.Normal };
                await _announcementFileRepository.Add(file, cancellationToken);
            }

        }


        /// <inheritdoc/>
        public async Task UploadUserAvatar(string userID, IFormFile userFile, CancellationToken cancellationToken)
        {
            await _cloudStorageClient.Login();

            string fileName = await _cloudStorageClient.UploadUserAvatar(userFile);

            await _cloudStorageClient.Logout();

            UserFile file = new() { Name = fileName, UserID = userID, Status = FileStatus.Normal };

            await _userFileRepository.Add(file, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task DeleteAnnouncementImages(int announcementID, CancellationToken cancellationToken)
        {
            await _announcementFileRepository.DeleteAnnouncementImages(announcementID, cancellationToken);
        }

    }
}
