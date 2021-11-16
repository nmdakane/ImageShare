using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Images_imageid",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_imageid",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "imageid",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "imageid",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_imageid",
                table: "Images",
                column: "imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Images_imageid",
                table: "Images",
                column: "imageid",
                principalTable: "Images",
                principalColumn: "Image_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
