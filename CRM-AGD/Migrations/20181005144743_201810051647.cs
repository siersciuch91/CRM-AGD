using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM_AGD.Migrations
{
    public partial class _201810051647 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentsInbox",
                columns: table => new
                {
                    AttachmentsInboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentData = table.Column<byte[]>(type: "image", nullable: true),
                    InboxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsInbox", x => x.AttachmentsInboxId);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsSendbox",
                columns: table => new
                {
                    AttachmentsSendboxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentData = table.Column<byte[]>(type: "image", nullable: true),
                    SendboxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsSendbox", x => x.AttachmentsSendboxId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentsInbox");

            migrationBuilder.DropTable(
                name: "AttachmentsSendbox");
        }
    }
}
