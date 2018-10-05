using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class _201810051649 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsSendbox_SendboxId",
                table: "AttachmentsSendbox",
                column: "SendboxId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsInbox_InboxId",
                table: "AttachmentsInbox",
                column: "InboxId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentsInbox_Inbox_InboxId",
                table: "AttachmentsInbox",
                column: "InboxId",
                principalTable: "Inbox",
                principalColumn: "InboxId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentsSendbox_Sendbox_SendboxId",
                table: "AttachmentsSendbox",
                column: "SendboxId",
                principalTable: "Sendbox",
                principalColumn: "SendboxId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsInbox_Inbox_InboxId",
                table: "AttachmentsInbox");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsSendbox_Sendbox_SendboxId",
                table: "AttachmentsSendbox");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentsSendbox_SendboxId",
                table: "AttachmentsSendbox");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentsInbox_InboxId",
                table: "AttachmentsInbox");
        }
    }
}
