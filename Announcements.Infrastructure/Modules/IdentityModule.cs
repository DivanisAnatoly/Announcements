using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Services.Users;
using Announcements.Infrastructure.DataAccess;
using Announcements.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Announcements.Infrastructure.Modules
{
    /// <summary>
    /// Модуль Identity
    /// </summary>
    public static class IdentityModule
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();

            services.AddIdentity<AppIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AnnouncementDBContext>()
                .AddDefaultTokenProviders();

            // Не удаляйте пожалуйста !
            /*
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            */

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {

                    opt.SaveToken = true;
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    };
                });

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
