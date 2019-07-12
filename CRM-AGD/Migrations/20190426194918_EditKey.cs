using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class EditKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inbox_Client_clientId",
                table: "Inbox");

            migrationBuilder.DropForeignKey(
                name: "FK_Sendbox_Client_clientId",
                table: "Sendbox");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Sendbox",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Sendbox_clientId",
                table: "Sendbox",
                newName: "IX_Sendbox_ClientId");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Inbox",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Inbox_clientId",
                table: "Inbox",
                newName: "IX_Inbox_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Sendbox",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Inbox",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Inbox_Client_ClientId",
                table: "Inbox",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sendbox_Client_ClientId",
                table: "Sendbox",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inbox_Client_ClientId",
                table: "Inbox");

            migrationBuilder.DropForeignKey(
                name: "FK_Sendbox_Client_ClientId",
                table: "Sendbox");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Sendbox",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Sendbox_ClientId",
                table: "Sendbox",
                newName: "IX_Sendbox_clientId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Inbox",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Inbox_ClientId",
                table: "Inbox",
                newName: "IX_Inbox_clientId");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Sendbox",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Inbox",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
