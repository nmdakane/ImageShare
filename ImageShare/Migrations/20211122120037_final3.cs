using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class final3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sharedmages_Images_image_id",
                table: "sharedmages");

            migrationBuilder.DropForeignKey(
                name: "FK_sharedmages_People_user_id",
                table: "sharedmages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sharedmages",
                table: "sharedmages");

            migrationBuilder.RenameTable(
                name: "sharedmages",
                newName: "shared");

            migrationBuilder.RenameIndex(
                name: "IX_sharedmages_user_id",
                table: "shared",
                newName: "IX_shared_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_sharedmages_image_id",
                table: "shared",
                newName: "IX_shared_image_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shared",
                table: "shared",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_shared_Images_image_id",
                table: "shared",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "Image_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shared_People_user_id",
                table: "shared",
                column: "user_id",
                principalTable: "People",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shared_Images_image_id",
                table: "shared");

            migrationBuilder.DropForeignKey(
                name: "FK_shared_People_user_id",
                table: "shared");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shared",
                table: "shared");

            migrationBuilder.RenameTable(
                name: "shared",
                newName: "sharedmages");

            migrationBuilder.RenameIndex(
                name: "IX_shared_user_id",
                table: "sharedmages",
                newName: "IX_sharedmages_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_shared_image_id",
                table: "sharedmages",
                newName: "IX_sharedmages_image_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sharedmages",
                table: "sharedmages",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_sharedmages_Images_image_id",
                table: "sharedmages",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "Image_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sharedmages_People_user_id",
                table: "sharedmages",
                column: "user_id",
                principalTable: "People",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
