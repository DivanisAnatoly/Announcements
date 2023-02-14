using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Announcements.API.Modules
{
    /// <summary>
    /// Модуль автомаппера
    /// </summary>
    public static class AutomapperModule
    {
        public static IServiceCollection AddAutomapperModule(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(new API.Mappings.UserMappingProfile());
                config.AddProfile(new Application.Mappings.UserMappingProfile());
                config.AddProfile(new API.Mappings.AnnouncementMappingProfile());
                config.AddProfile(new Application.Mappings.AnnouncementMappingProfile());
                config.AddProfile(new API.Mappings.CommentMappingProfile());
                config.AddProfile(new Application.Mappings.CommentMappingProfile());
            });

            //configuration.AssertConfigurationIsValid();

            return configuration;
        }

    }
}
