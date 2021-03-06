﻿// <auto-generated />
using CRM_AGD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CRM_AGD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181005135235_201810051552")]
    partial class _201810051552
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM_AGD.Areas.Address.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Address.Models.Street", b =>
                {
                    b.Property<int>("StreetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<int>("StreetPrefixId");

                    b.HasKey("StreetId");

                    b.HasIndex("CityId");

                    b.HasIndex("StreetPrefixId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Address.Models.StreetPrefix", b =>
                {
                    b.Property<int>("StreetPrefixId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Prefix")
                        .HasMaxLength(5);

                    b.HasKey("StreetPrefixId");

                    b.ToTable("StreetPrefixes");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("HomeNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(9);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("StreetId");

                    b.HasKey("ClientId");

                    b.HasIndex("StreetId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Description");

                    b.Property<int>("MachineModelId");

                    b.Property<DateTime>("Term");

                    b.HasKey("IssueId");

                    b.HasIndex("ClientId");

                    b.HasIndex("MachineModelId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.IssueFromPortal", b =>
                {
                    b.Property<int>("IssueFromPortalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("HomeNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("MachineModelId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(9);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("StreetId");

                    b.Property<DateTime>("SuggestedDate");

                    b.HasKey("IssueFromPortalId");

                    b.HasIndex("MachineModelId");

                    b.HasIndex("StreetId");

                    b.ToTable("IssueFromPortal");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Equipment.Models.MachineModel", b =>
                {
                    b.Property<int>("MachineModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MachineTypeId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("MachineModelId");

                    b.HasIndex("MachineTypeId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("MachineModel");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Equipment.Models.MachineType", b =>
                {
                    b.Property<int>("MachineTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("MachineTypeId");

                    b.ToTable("MachineType");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Equipment.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Mail.Models.Inbox", b =>
                {
                    b.Property<int>("InboxId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("MailFrom")
                        .HasMaxLength(50);

                    b.Property<string>("MailTo")
                        .HasMaxLength(50);

                    b.Property<string>("Message");

                    b.Property<string>("MessageHtml");

                    b.Property<string>("Tittle")
                        .HasMaxLength(255);

                    b.HasKey("InboxId");

                    b.ToTable("Inbox");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Mail.Models.Sendbox", b =>
                {
                    b.Property<int>("SendboxId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("MailFrom")
                        .HasMaxLength(50);

                    b.Property<string>("MailTo")
                        .HasMaxLength(50);

                    b.Property<string>("Message");

                    b.Property<string>("MessageHtml");

                    b.Property<string>("Tittle")
                        .HasMaxLength(255);

                    b.HasKey("SendboxId");

                    b.ToTable("Sendbox");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Settlements.Models.Facture", b =>
                {
                    b.Property<int>("FactureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<double>("SumBrutto");

                    b.Property<double>("SumNetto");

                    b.HasKey("FactureId");

                    b.HasIndex("ClientId");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Settlements.Models.FacturePosition", b =>
                {
                    b.Property<int>("FacturePositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Brutto");

                    b.Property<string>("Description");

                    b.Property<int>("FactureId");

                    b.Property<double>("Netto");

                    b.Property<int>("VatRatesId");

                    b.HasKey("FacturePositionId");

                    b.HasIndex("FactureId");

                    b.HasIndex("VatRatesId");

                    b.ToTable("FacturePosition");
                });

            modelBuilder.Entity("CRM_AGD.Areas.Settlements.Models.VatRates", b =>
                {
                    b.Property<int>("VatRatesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Value");

                    b.HasKey("VatRatesId");

                    b.ToTable("VatRates");
                });

            modelBuilder.Entity("CRM_AGD.Models.ApplicationUser", b =>
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
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("CRM_AGD.Areas.Address.Models.Street", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Address.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_AGD.Areas.Address.Models.StreetPrefix", "streetPrefix")
                        .WithMany()
                        .HasForeignKey("StreetPrefixId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.Client", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Address.Models.Street", "street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.Issue", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Client.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_AGD.Areas.Equipment.Models.MachineModel", "machineModel")
                        .WithMany()
                        .HasForeignKey("MachineModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Client.Models.IssueFromPortal", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Equipment.Models.MachineModel", "machineModel")
                        .WithMany()
                        .HasForeignKey("MachineModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_AGD.Areas.Address.Models.Street", "street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Equipment.Models.MachineModel", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Equipment.Models.MachineType", "machineType")
                        .WithMany()
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_AGD.Areas.Equipment.Models.Manufacturer", "manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Settlements.Models.Facture", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Client.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM_AGD.Areas.Settlements.Models.FacturePosition", b =>
                {
                    b.HasOne("CRM_AGD.Areas.Settlements.Models.Facture", "facture")
                        .WithMany()
                        .HasForeignKey("FactureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_AGD.Areas.Settlements.Models.VatRates", "vatRates")
                        .WithMany()
                        .HasForeignKey("VatRatesId")
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
                    b.HasOne("CRM_AGD.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CRM_AGD.Models.ApplicationUser")
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

                    b.HasOne("CRM_AGD.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CRM_AGD.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
