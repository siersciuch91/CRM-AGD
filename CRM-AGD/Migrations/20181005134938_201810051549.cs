using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class _201810051549 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Inbox",
                columns: table => new
                {
                    InboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    MailFrom = table.Column<string>(maxLength: 50, nullable: true),
                    MailTo = table.Column<string>(maxLength: 50, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    MessageHtml = table.Column<string>(nullable: true),
                    Tittle = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbox", x => x.InboxId);
                });

            migrationBuilder.CreateTable(
                name: "MachineType",
                columns: table => new
                {
                    MachineTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineType", x => x.MachineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Sendbox",
                columns: table => new
                {
                    SendboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    MailFrom = table.Column<string>(maxLength: 50, nullable: true),
                    MailTo = table.Column<string>(maxLength: 50, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    MessageHtml = table.Column<string>(nullable: true),
                    Tittle = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sendbox", x => x.SendboxId);
                });

            migrationBuilder.CreateTable(
                name: "StreetPrefixes",
                columns: table => new
                {
                    StreetPrefixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Prefix = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetPrefixes", x => x.StreetPrefixId);
                });

            migrationBuilder.CreateTable(
                name: "VatRates",
                columns: table => new
                {
                    VatRatesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatRates", x => x.VatRatesId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineModel",
                columns: table => new
                {
                    MachineModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineTypeId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineModel", x => x.MachineModelId);
                    table.ForeignKey(
                        name: "FK_MachineModel_MachineType_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineType",
                        principalColumn: "MachineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineModel_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    StreetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(maxLength: 6, nullable: false),
                    StreetPrefixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_StreetPrefixes_StreetPrefixId",
                        column: x => x.StreetPrefixId,
                        principalTable: "StreetPrefixes",
                        principalColumn: "StreetPrefixId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HomeNumber = table.Column<string>(maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 9, nullable: true),
                    SecondName = table.Column<string>(maxLength: 100, nullable: false),
                    StreetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueFromPortal",
                columns: table => new
                {
                    IssueFromPortalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HomeNumber = table.Column<string>(maxLength: 10, nullable: false),
                    MachineModelId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 9, nullable: true),
                    SecondName = table.Column<string>(maxLength: 100, nullable: false),
                    StreetId = table.Column<int>(nullable: false),
                    SuggestedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueFromPortal", x => x.IssueFromPortalId);
                    table.ForeignKey(
                        name: "FK_IssueFromPortal_MachineModel_MachineModelId",
                        column: x => x.MachineModelId,
                        principalTable: "MachineModel",
                        principalColumn: "MachineModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueFromPortal_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    FactureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    SumBrutto = table.Column<double>(nullable: false),
                    SumNetto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.FactureId);
                    table.ForeignKey(
                        name: "FK_Facture_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MachineModelId = table.Column<int>(nullable: false),
                    Term = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issue_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_MachineModel_MachineModelId",
                        column: x => x.MachineModelId,
                        principalTable: "MachineModel",
                        principalColumn: "MachineModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturePosition",
                columns: table => new
                {
                    FacturePositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brutto = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FactureId = table.Column<int>(nullable: false),
                    Netto = table.Column<double>(nullable: false),
                    VatRatesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturePosition", x => x.FacturePositionId);
                    table.ForeignKey(
                        name: "FK_FacturePosition_Facture_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Facture",
                        principalColumn: "FactureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturePosition_VatRates_VatRatesId",
                        column: x => x.VatRatesId,
                        principalTable: "VatRates",
                        principalColumn: "VatRatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_StreetId",
                table: "Client",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ClientId",
                table: "Facture",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturePosition_FactureId",
                table: "FacturePosition",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturePosition_VatRatesId",
                table: "FacturePosition",
                column: "VatRatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_ClientId",
                table: "Issue",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_MachineModelId",
                table: "Issue",
                column: "MachineModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFromPortal_MachineModelId",
                table: "IssueFromPortal",
                column: "MachineModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFromPortal_StreetId",
                table: "IssueFromPortal",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineModel_MachineTypeId",
                table: "MachineModel",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineModel_ManufacturerId",
                table: "MachineModel",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetPrefixId",
                table: "Streets",
                column: "StreetPrefixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FacturePosition");

            migrationBuilder.DropTable(
                name: "Inbox");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "IssueFromPortal");

            migrationBuilder.DropTable(
                name: "Sendbox");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "VatRates");

            migrationBuilder.DropTable(
                name: "MachineModel");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "MachineType");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "StreetPrefixes");
        }
    }
}
