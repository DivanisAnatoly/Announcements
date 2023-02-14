using Announcements.Application.Common;
using Announcements.Domain.Entities;
using Announcements.Infrastructure.DataAccess.EntitiesConfiguration;
using Announcements.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Announcements.Infrastructure.DataAccess
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class AnnouncementDBContext : IdentityDbContext<AppIdentityUser>
    {
        //Добавлены таблицы в бд
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementFile> AnnouncementFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<User> DomainUsers { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }


        public AnnouncementDBContext(DbContextOptions<AnnouncementDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        /// <summary>
        /// Конфигурация БД при ее создании/пересоздании
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementFilesConfiguration());
            modelBuilder.ApplyConfiguration(new UserFilesConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            SeedIdentity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// 
        /// </summary>
        private void SeedIdentity(ModelBuilder modelBuilder)
        {
            var ADMIN_ROLE_ID = "1991ff6b-6a2f-46f1-a9ea-c5d53a50c285";
            var USER_ROLE_ID = "ff7db2c9-9505-4c6e-abc3-366ee2bbea18";
            var ADMIN_ID = "98b651ae-c9aa-4731-9996-57352d525f7e";

            modelBuilder.Entity<IdentityRole>(t =>
            {
                t.HasData(new[]
                {
                    new IdentityRole()
                    {
                        Id = ADMIN_ROLE_ID,
                        Name = RoleConstants.AdminRole,
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole(RoleConstants.UserRole)
                    {
                        Id = USER_ROLE_ID,
                        Name = RoleConstants.UserRole,
                        NormalizedName = "USER"
                    }
                }); ;

            });

            var passwordHasher = new PasswordHasher<AppIdentityUser>();

            string userName = "admin";
            string email = "anatolydivanis@gmail.com";
            var adminUser = new AppIdentityUser
            {
                Id = ADMIN_ID,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper()

            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

            modelBuilder.Entity<AppIdentityUser>(t =>
            {
                t.HasData(adminUser);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(x =>
            {
                x.HasData(new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });
            });

        }

    }
}
