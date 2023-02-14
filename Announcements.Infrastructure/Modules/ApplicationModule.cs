using Announcements.Application.Implementations.Services.Announcements;
using Announcements.Application.Implementations.Services.CloudStorage;
using Announcements.Application.Implementations.Services.Comments;
using Announcements.Application.Implementations.Services.Files;
using Announcements.Application.Implementations.Services.Users;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Announcements;
using Announcements.Application.Interfaces.Services.CloudStorage;
using Announcements.Application.Interfaces.Services.Comments;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Application.Interfaces.Services.Mail;
using Announcements.Application.Interfaces.Services.Users;
using Announcements.Infrastructure.DataAccess.Repositories;
using Announcements.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Announcements.Infrastructure.Modules
{
    /// <summary>
    /// Модуль сервисов и репозиторие приложения
    /// </summary>
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            services.AddTransient<IUserFileRepository, UserFileRepository>();
            services.AddTransient<IAnnouncementFileRepository, AnnouncementFileRepository>();
            services.AddTransient<IFileService, FileService>();

            services.AddScoped<ICloudStorageClient, CloudStorageClient>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddScoped<IMailService, MailService>();

            return services;
        }

    }
}
