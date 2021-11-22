using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class final4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Shared");

            migrationBuilder.RenameIndex(
                name: "IX_shared_user_id",
                table: "Shared",
                newName: "IX_Shared_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_shared_image_id",
                table: "Shared",
                newName: "IX_Shared_image_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "Shared",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "image_id",
                table: "Shared",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shared",
                table: "Shared",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_Images_image_id",
                table: "Shared",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "Image_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_People_user_id",
                table: "Shared",
                column: "user_id",
                principalTable: "People",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shared_Images_image_id",
                table: "Shared");

            migrationBuilder.DropForeignKey(
                name: "FK_Shared_People_user_id",
                table: "Shared");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shared",
                table: "Shared");

            migrationBuilder.RenameTable(
                name: "Shared",
                newName: "shared");

            migrationBuilder.RenameIndex(
                name: "IX_Shared_user_id",
                table: "shared",
                newName: "IX_shared_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shared_image_id",
                table: "shared",
                newName: "IX_shared_image_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "shared",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "image_id",
                table: "shared",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
