﻿// <auto-generated />
using System;
using CbMobile.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CbMobile.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191015135708_delete_detailMemory")]
    partial class delete_detailMemory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CbMobile.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<bool>("Published");

                    b.Property<string>("Role");

                    b.Property<string>("Token");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BannerCategory");

                    b.Property<string>("BannerUrl");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<int>("ParentId");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.CategoryProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("CategoryProducts");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.DetailSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("IdProduct");

                    b.Property<int>("IdSpecification");

                    b.Property<int?>("ProductsId");

                    b.Property<bool>("Published");

                    b.Property<int?>("SpecificationId");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("DetailSpecifications");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.MainMemory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("MainMemorys");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("OrderRef");

                    b.Property<string>("PostCode");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.OrderManuFacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryProductId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("ManufacturerID");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.HasIndex("CategoryProductId");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("OrderManuFacturers");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("BannerUrl");

                    b.Property<int>("CategoriesId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("FullDescription");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl");

                    b.Property<int>("CategoryProductId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("FullDescription");

                    b.Property<bool>("Hot");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription");

                    b.Property<bool>("Status");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.Property<decimal?>("Value");

                    b.Property<decimal?>("ValuePromotion");

                    b.HasKey("Id");

                    b.HasIndex("CategoryProductId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("ProductId");

                    b.Property<bool>("Published");

                    b.Property<int>("ReviewStar");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Subscribe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Email");

                    b.Property<bool>("Published");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<DateTime>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.DetailSpecification", b =>
                {
                    b.HasOne("CbMobile.Domain.Models.Product", "Products")
                        .WithMany("DetailSpecifications")
                        .HasForeignKey("ProductsId");

                    b.HasOne("CbMobile.Domain.Models.Specification", "Specification")
                        .WithMany("DetailSpecifications")
                        .HasForeignKey("SpecificationId");
                });

            modelBuilder.Entity("CbMobile.Domain.Models.OrderManuFacturer", b =>
                {
                    b.HasOne("CbMobile.Domain.Models.CategoryProduct", "CategoryProducts")
                        .WithMany("OrderManuFacturers")
                        .HasForeignKey("CategoryProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CbMobile.Domain.Models.Manufacturer", "Manufacturers")
                        .WithMany("OrderManuFacturers")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Post", b =>
                {
                    b.HasOne("CbMobile.Domain.Models.Categories", "Categories")
                        .WithMany("Posts")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Product", b =>
                {
                    b.HasOne("CbMobile.Domain.Models.CategoryProduct", "CategoryProduct")
                        .WithMany("Products")
                        .HasForeignKey("CategoryProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CbMobile.Domain.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CbMobile.Domain.Models.Review", b =>
                {
                    b.HasOne("CbMobile.Domain.Models.Product", "Product")
                        .WithMany("Reivews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
