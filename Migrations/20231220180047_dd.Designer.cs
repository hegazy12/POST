﻿// <auto-generated />
using System;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProjectEweis.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231220180047_dd")]
    partial class dd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", "Login");
                });

            modelBuilder.Entity("ProjectEweis.Models.commercial", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("city_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("investment_cost")
                        .HasColumnType("int");

                    b.Property<int>("other_contribution")
                        .HasColumnType("int");

                    b.Property<int>("partner_type")
                        .HasColumnType("int");

                    b.Property<int>("partners_count")
                        .HasColumnType("int");

                    b.Property<int>("project_status")
                        .HasColumnType("int");

                    b.Property<int>("user_contribution")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.ToTable("commercial", "Post");
                });

            modelBuilder.Entity("ProjectEweis.Models.LOVE_ON_Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("ReactorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("commercialID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("real_estate_noID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("real_estate_yesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ReactorId");

                    b.HasIndex("commercialID");

                    b.HasIndex("real_estate_noID");

                    b.HasIndex("real_estate_yesID");

                    b.ToTable("LOVE_ON_Post");
                });

            modelBuilder.Entity("ProjectEweis.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ProjectEweis.Models.Partnership_proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<bool>("Islocation_suitable")
                        .HasColumnType("bit");

                    b.Property<bool>("Ispartnership_amount_appropriate")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Partnership_Proposals");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_no", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("city_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("investment_cost")
                        .HasColumnType("int");

                    b.Property<int>("needs_money")
                        .HasColumnType("int");

                    b.Property<int>("negotiable")
                        .HasColumnType("int");

                    b.Property<string>("partnerNeighborhoods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("partner_type")
                        .HasColumnType("int");

                    b.Property<int>("partners_count")
                        .HasColumnType("int");

                    b.Property<int>("property_area")
                        .HasColumnType("int");

                    b.Property<int>("property_type")
                        .HasColumnType("int");

                    b.Property<int>("purpose")
                        .HasColumnType("int");

                    b.Property<int>("street_width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.ToTable("real_estate_no", "Post");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_yes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("city_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("investment_cost")
                        .HasColumnType("int");

                    b.Property<int>("needs_money")
                        .HasColumnType("int");

                    b.Property<int>("negotiable")
                        .HasColumnType("int");

                    b.Property<string>("partnerNeighborhoods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("partner_type")
                        .HasColumnType("int");

                    b.Property<int>("partners_count")
                        .HasColumnType("int");

                    b.Property<string>("plan_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("property_age")
                        .HasColumnType("int");

                    b.Property<int>("property_area")
                        .HasColumnType("int");

                    b.Property<string>("property_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("property_type")
                        .HasColumnType("int");

                    b.Property<int>("purpose")
                        .HasColumnType("int");

                    b.Property<int>("street_width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.ToTable("real_estate_yes", "Post");
                });

            modelBuilder.Entity("ProjectEweis.Models.UserRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<int>("ISAmountofMoneyOK")
                        .HasColumnType("int");

                    b.Property<int>("ISpecificationsOK")
                        .HasColumnType("int");

                    b.Property<string>("RequesterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SuggestedAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("commercialID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("real_estate_noID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("real_estate_yesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.HasIndex("commercialID");

                    b.HasIndex("real_estate_noID");

                    b.HasIndex("real_estate_yesID");

                    b.ToTable("Requests", "Request");
                });

            modelBuilder.Entity("TestApiJWT.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("users", "Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApiJWT.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectEweis.Models.commercial", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectEweis.Models.LOVE_ON_Post", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "Reactor")
                        .WithMany()
                        .HasForeignKey("ReactorId");

                    b.HasOne("ProjectEweis.Models.commercial", "commercial")
                        .WithMany()
                        .HasForeignKey("commercialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectEweis.Models.real_estate_no", "real_estate_no")
                        .WithMany()
                        .HasForeignKey("real_estate_noID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectEweis.Models.real_estate_yes", "real_estate_yes")
                        .WithMany()
                        .HasForeignKey("real_estate_yesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reactor");

                    b.Navigation("commercial");

                    b.Navigation("real_estate_no");

                    b.Navigation("real_estate_yes");
                });

            modelBuilder.Entity("ProjectEweis.Models.Message", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "AppUser")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ProjectEweis.Models.Partnership_proposal", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_no", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_yes", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectEweis.Models.UserRequest", b =>
                {
                    b.HasOne("TestApiJWT.Models.ApplicationUser", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId");

                    b.HasOne("ProjectEweis.Models.commercial", "commercial")
                        .WithMany("requests")
                        .HasForeignKey("commercialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectEweis.Models.real_estate_no", "real_estate_no")
                        .WithMany("requests")
                        .HasForeignKey("real_estate_noID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectEweis.Models.real_estate_yes", "real_estate_yes")
                        .WithMany("requests")
                        .HasForeignKey("real_estate_yesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requester");

                    b.Navigation("commercial");

                    b.Navigation("real_estate_no");

                    b.Navigation("real_estate_yes");
                });

            modelBuilder.Entity("ProjectEweis.Models.commercial", b =>
                {
                    b.Navigation("requests");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_no", b =>
                {
                    b.Navigation("requests");
                });

            modelBuilder.Entity("ProjectEweis.Models.real_estate_yes", b =>
                {
                    b.Navigation("requests");
                });

            modelBuilder.Entity("TestApiJWT.Models.ApplicationUser", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
