using Announcements.API.Modules;
using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Application.RequestModels;
using Announcements.Application.RequestModels.User.Validators;
using Announcements.Domain.Entities;
using Announcements.Infrastructure.DataAccess;
using Announcements.Infrastructure.Modules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Announcements.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpContextAccessor();

            services.AddIdentity(Configuration);

            services.AddSwaggerModule();

            services.AddApplicationModule(Configuration);

            services.AddAutomapperModule();

            services.AddMvc().AddFluentValidation();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
            });

            //services.AddTransient<IValidator<Announcement>, AnnouncementValidator>();

            //services.AddTransient<IValidator<Comment>, CommentValidator>();

            services.AddTransient<IValidator<UserRegisterRequest>, UserRegisterRequestValidator>();

            //Добавлена БД
            services.AddDbContext<AnnouncementDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AnnouncementDBContext")));

            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Announcements.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
