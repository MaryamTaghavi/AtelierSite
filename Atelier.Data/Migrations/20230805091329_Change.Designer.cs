﻿// <auto-generated />
using System;
using Atelier.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atelier.Data.Migrations
{
    [DbContext(typeof(AtelierContext))]
    [Migration("20230805091329_Change")]
    partial class Change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Ateliers");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Ateliers.AtelierGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtelierId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("GroupId");

                    b.ToTable("AtelierGroups");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Cities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Favorites.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtelierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Groupings.Grouping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Groupings");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Photographers.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtelierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeUser")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 8, 1, 15, 21, 32, 968, DateTimeKind.Local).AddTicks(1379),
                            FullName = "فاطمه جعفری",
                            Password = "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E",
                            PhoneNumber = "09130023409",
                            TypeUser = 1,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.WorkSamples.WorkSample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtelierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("WorkSamplePic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.HasIndex("GroupId");

                    b.ToTable("WorkSamples");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", b =>
                {
                    b.HasOne("Atelier.Domain.Models.BaseInfo.Cities.City", "City")
                        .WithMany("Atelier")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Atelier.Domain.Models.BaseInfo.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Ateliers.AtelierGroup", b =>
                {
                    b.HasOne("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", "Atelier")
                        .WithMany("AtelierGroups")
                        .HasForeignKey("AtelierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Atelier.Domain.Models.BaseInfo.Groupings.Grouping", "Grouping")
                        .WithMany("AtelierGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Atelier");

                    b.Navigation("Grouping");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Favorites.Favorite", b =>
                {
                    b.HasOne("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", "Atelier")
                        .WithMany()
                        .HasForeignKey("AtelierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Atelier.Domain.Models.BaseInfo.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Atelier");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Photographers.Photographer", b =>
                {
                    b.HasOne("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", "Atelier")
                        .WithMany("Photographers")
                        .HasForeignKey("AtelierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Atelier");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.WorkSamples.WorkSample", b =>
                {
                    b.HasOne("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", "Atelier")
                        .WithMany("WorkSamples")
                        .HasForeignKey("AtelierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Atelier.Domain.Models.BaseInfo.Groupings.Grouping", "Grouping")
                        .WithMany("WorkSamples")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Atelier");

                    b.Navigation("Grouping");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Ateliers.Atelier", b =>
                {
                    b.Navigation("AtelierGroups");

                    b.Navigation("Photographers");

                    b.Navigation("WorkSamples");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Cities.City", b =>
                {
                    b.Navigation("Atelier");
                });

            modelBuilder.Entity("Atelier.Domain.Models.BaseInfo.Groupings.Grouping", b =>
                {
                    b.Navigation("AtelierGroups");

                    b.Navigation("WorkSamples");
                });
#pragma warning restore 612, 618
        }
    }
}
