﻿// <auto-generated />
using System;
using Announcements.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Announcements.Infrastructure.Migrations
{
    [DbContext(typeof(AnnouncementDBContext))]
    [Migration("20210903125615_Added-FileStatus")]
    partial class AddedFileStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Announcements.Domain.Entities.Announcement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RegionID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("RegionID");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.AnnouncementFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnouncementID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("AnnouncementID");

                    b.ToTable("AnnouncementFiles");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ParentCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnouncementID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("ID");

                    b.HasIndex("AnnouncementID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "anatolydivanis@gmail.com",
                            Name = "Anatoly Divanis",
                            Password = "123456",
                            Phone = "+79999999999",
                            Role = 0,
                            Status = 0
                        },
                        new
                        {
                            ID = 2,
                            Email = "petrov@gmail.com",
                            Name = "Petr Petrov",
                            Password = "password",
                            Phone = "+79780452647",
                            Role = 0,
                            Status = 0
                        },
                        new
                        {
                            ID = 3,
                            Email = "ivanov@gmail.com",
                            Name = "Ivan Ivanov",
                            Password = "password",
                            Phone = "+79780947386",
                            Role = 0,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Announcements.Domain.Entities.UserFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFiles");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Announcement", b =>
                {
                    b.HasOne("Announcements.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Announcements.Domain.Entities.User", "Owner")
                        .WithMany("Announcements")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Announcements.Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("Owner");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.AnnouncementFile", b =>
                {
                    b.HasOne("Announcements.Domain.Entities.Announcement", null)
                        .WithMany("AnnouncementFiles")
                        .HasForeignKey("AnnouncementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Category", b =>
                {
                    b.HasOne("Announcements.Domain.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Announcements.Domain.Entities.Announcement", "Announcement")
                        .WithMany("Comments")
                        .HasForeignKey("AnnouncementID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Announcements.Domain.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Announcement");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.UserFile", b =>
                {
                    b.HasOne("Announcements.Domain.Entities.User", null)
                        .WithMany("UserFiles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Announcement", b =>
                {
                    b.Navigation("AnnouncementFiles");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("Announcements.Domain.Entities.User", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Comments");

                    b.Navigation("UserFiles");
                });
#pragma warning restore 612, 618
        }
    }
}