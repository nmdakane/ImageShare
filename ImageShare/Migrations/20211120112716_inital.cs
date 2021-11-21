using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_uploaded",
                table: "Images",
                newName: "Date_captured");

            migrationBuilder.AddColumn<string>(
                name: "image_capturedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_geolocation",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_tag",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_capturedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "image_geolocation",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "image_tag",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Date_captured",
                table: "Images",
                newName: "Date_uploaded");
        }
    }
}
