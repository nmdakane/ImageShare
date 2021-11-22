using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sharedmages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    image_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    share_with = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sharedmages", x => x.id);
                    table.ForeignKey(
                        name: "FK_sharedmages_Images_image_id",
                        column: x => x.image_id,
                        principalTable: "Images",
                        principalColumn: "Image_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sharedmages_People_user_id",
                        column: x => x.user_id,
                        principalTable: "People",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sharedmages_image_id",
                table: "sharedmages",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_sharedmages_user_id",
                table: "sharedmages",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sharedmages");
        }
    }
}
