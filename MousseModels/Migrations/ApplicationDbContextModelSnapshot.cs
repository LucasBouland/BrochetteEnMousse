﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MousseModels.Data;

namespace MousseModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("MousseModels.Models.Campaign", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Visibility");

                    b.HasKey("ID");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("MousseModels.Models.CampaignUser", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CampaignID");

                    b.Property<string>("CharacterID");

                    b.Property<bool>("IsGameMaster");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CampaignID");

                    b.HasIndex("CharacterID");

                    b.HasIndex("UserID");

                    b.ToTable("CampaignUser");
                });

            modelBuilder.Entity("MousseModels.Models.Character", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsPlayerCharacter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("MousseModels.Models.CharacterCampaign", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CampaignID");

                    b.Property<string>("CharacterID");

                    b.HasKey("ID");

                    b.HasIndex("CampaignID");

                    b.HasIndex("CharacterID");

                    b.ToTable("CharacterCampaign");
                });

            modelBuilder.Entity("MousseModels.Models.Map", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ScenarioID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ScenarioID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("MousseModels.Models.Monster", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("MousseModels.Models.Scenario", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("Visibility");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("MousseModels.Models.ScenarioMonster", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MonsterID");

                    b.Property<string>("ScenarioID");

                    b.HasKey("ID");

                    b.HasIndex("MonsterID");

                    b.HasIndex("ScenarioID");

                    b.ToTable("ScenarioMonster");
                });

            modelBuilder.Entity("MousseModels.Models.ScenarioSession", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ScenarioID");

                    b.Property<string>("SessionID");

                    b.HasKey("ID");

                    b.HasIndex("ScenarioID");

                    b.HasIndex("SessionID");

                    b.ToTable("ScenarioSession");
                });

            modelBuilder.Entity("MousseModels.Models.Session", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CampaignID");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Visibility");

                    b.HasKey("ID");

                    b.HasIndex("CampaignID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("MousseModels.Models.SessionUser", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SessionID");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("SessionID");

                    b.ToTable("SessionUser");
                });

            modelBuilder.Entity("MousseModels.Models.User", b =>
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

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MousseModels.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MousseModels.Models.User")
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

                    b.HasOne("MousseModels.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MousseModels.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MousseModels.Models.CampaignUser", b =>
                {
                    b.HasOne("MousseModels.Models.Campaign", "Campaign")
                        .WithMany("CampaignUsers")
                        .HasForeignKey("CampaignID");

                    b.HasOne("MousseModels.Models.Character")
                        .WithMany("CampaignUsers")
                        .HasForeignKey("CharacterID");

                    b.HasOne("MousseModels.Models.User", "User")
                        .WithMany("CampaignUsers")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("MousseModels.Models.Character", b =>
                {
                    b.HasOne("MousseModels.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MousseModels.Models.CharacterCampaign", b =>
                {
                    b.HasOne("MousseModels.Models.Campaign", "Campaign")
                        .WithMany("CharacterCampaigns")
                        .HasForeignKey("CampaignID");

                    b.HasOne("MousseModels.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterID");
                });

            modelBuilder.Entity("MousseModels.Models.Map", b =>
                {
                    b.HasOne("MousseModels.Models.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MousseModels.Models.Scenario", b =>
                {
                    b.HasOne("MousseModels.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MousseModels.Models.ScenarioMonster", b =>
                {
                    b.HasOne("MousseModels.Models.Monster", "Monster")
                        .WithMany("ScenarioMonsters")
                        .HasForeignKey("MonsterID");

                    b.HasOne("MousseModels.Models.Scenario", "Scenario")
                        .WithMany("ScenarioMonsters")
                        .HasForeignKey("ScenarioID");
                });

            modelBuilder.Entity("MousseModels.Models.ScenarioSession", b =>
                {
                    b.HasOne("MousseModels.Models.Scenario", "Scenario")
                        .WithMany("ScenarioSessions")
                        .HasForeignKey("ScenarioID");

                    b.HasOne("MousseModels.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID");
                });

            modelBuilder.Entity("MousseModels.Models.Session", b =>
                {
                    b.HasOne("MousseModels.Models.User", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignID");
                });

            modelBuilder.Entity("MousseModels.Models.SessionUser", b =>
                {
                    b.HasOne("MousseModels.Models.Session", "Session")
                        .WithMany("SessionUsers")
                        .HasForeignKey("SessionID");

                    b.HasOne("MousseModels.Models.User", "User")
                        .WithMany("SessionUsers")
                        .HasForeignKey("SessionID");
                });
#pragma warning restore 612, 618
        }
    }
}
