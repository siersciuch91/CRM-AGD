using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class _201810042206 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineType",
                columns: table => new
                {
                    MachineTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineType", x => x.MachineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MachineModel",
                columns: table => new
                {
                    MachineModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineTypeId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_MachineModel_MachineTypeId",
                table: "MachineModel",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineModel_ManufacturerId",
                table: "MachineModel",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineModel");

            migrationBuilder.DropTable(
                name: "MachineType");
        }
    }
}
