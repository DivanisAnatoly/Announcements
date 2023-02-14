using Announcements.Application.Interfaces.Services.CloudStorage;
using Announcements.Domain.Entities;
using CG.Web.MegaApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Announcements.Application.Implementations.Services.CloudStorage
{
    /// <summary>
    /// Клиент облачного хранилища
    /// </summary>
    /// <inheritdoc cref="ICloudStorageClient"/>
    public class CloudStorageClient : ICloudStorageClient
    {
        private readonly IConfiguration _configuration;

        MegaApiClient client;
        readonly string megaUserAvatarFolderName = "Profile Images";
        readonly string megaAnnounImagesFolderName = "Announcements Images";

        public CloudStorageClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <inheritdoc/>
        public async Task<List<Uri>> GetAnnouncementImagesURIs(IEnumerable<AnnouncementFile> announcementFiles)
        {
            List<Uri> result = new();
            IEnumerable<INode> nodes = await client.GetNodesAsync();
            INode myFile;

            foreach (var file in announcementFiles)
            {
                myFile = nodes.FirstOrDefault(i => i.Name == file.Name);
                result.Add(await client.GetDownloadLinkAsync(myFile));
            }

            return result;
        }


        /// <inheritdoc/>
        public async Task<Uri> GetAnnouncementImageURI(AnnouncementFile announcementFile)
        {
            IEnumerable<INode> nodes = await client.GetNodesAsync();
            INode myFile = nodes.FirstOrDefault(i => i.Name == announcementFile.Name);

            return await client.GetDownloadLinkAsync(myFile);
        }


        /// <inheritdoc/>
        public async Task<Uri> GetUserAvatarUri(UserFile userFile)
        {
            IEnumerable<INode> nodes = await client.GetNodesAsync();
            INode myFile = nodes.FirstOrDefault(i => i.Name == userFile.Name);
            return await client.GetDownloadLinkAsync(myFile);
        }


        /// <inheritdoc/>
        public async Task Login()
        {
            client = new MegaApiClient();
            await client.LoginAsync(_configuration["MegaCSClient:Email"], _configuration["MegaCSClient:Password"]);
        }


        /// <inheritdoc/>
        public async Task Logout()
        {
            await client.LogoutAsync();
        }


        /// <inheritdoc/>
        public async Task<List<string>> UploadAnnouncementImages(List<IFormFile> announcementFiles)
        {
            List<string> fileNames = new();
            string fileName;
            IEnumerable<INode> nodes;
            List<INode> MFolders;
            INode announImagesMFolder;

            foreach (IFormFile file in announcementFiles)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                nodes = await client.GetNodesAsync();

                MFolders = nodes.Where(n => n.Type == NodeType.Directory).ToList();
                announImagesMFolder = MFolders.Where(folder => folder.Name == megaAnnounImagesFolderName).FirstOrDefault();

                MemoryStream ms = new();
                file.CopyTo(ms);
                ms.Position = 0;

                await client.UploadAsync(ms, fileName, announImagesMFolder);

                fileNames.Add(fileName);
            }

            return fileNames;
        }


        /// <inheritdoc/>
        public async Task<string> UploadUserAvatar(IFormFile userFile)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userFile.FileName);

            IEnumerable<INode> nodes = await client.GetNodesAsync();

            List<INode> MFolders = nodes.Where(n => n.Type == NodeType.Directory).ToList();
            INode profileImagesMFolder = MFolders.Where(folder => folder.Name == megaUserAvatarFolderName).FirstOrDefault();

            MemoryStream ms = new();
            userFile.CopyTo(ms);
            ms.Position = 0;

            await client.UploadAsync(ms, fileName, profileImagesMFolder);

            return fileName;
        }


        /// <inheritdoc/>
        public async Task<string> GetFileName(Uri fileUri)
        {
            var file = await client.GetNodeFromLinkAsync(fileUri);

            return file.Name;
        }

    }
}
