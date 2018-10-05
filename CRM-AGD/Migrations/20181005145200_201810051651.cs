using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class _201810051651 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "Sendbox",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "Inbox",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sendbox_clientId",
                table: "Sendbox",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inbox_clientId",
                table: "Inbox",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inbox_Client_clientId",
                table: "Inbox",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sendbox_Client_clientId",
                table: "Sendbox",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inbox_Client_clientId",
                table: "Inbox");

            migrationBuilder.DropForeignKey(
                name: "FK_Sendbox_Client_clientId",
                table: "Sendbox");

            migrationBuilder.DropIndex(
                name: "IX_Sendbox_clientId",
                table: "Sendbox");

            migrationBuilder.DropIndex(
                name: "IX_Inbox_clientId",
                table: "Inbox");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "Sendbox");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "Inbox");
        }
    }
}
