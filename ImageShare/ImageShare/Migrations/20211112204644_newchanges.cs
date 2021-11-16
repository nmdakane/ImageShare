using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_DOB",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Image_height",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Image_width",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "User_Contact",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_Password",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Contact",
                table: "People");

            migrationBuilder.DropColumn(
                name: "User_Password",
                table: "People");

            migrationBuilder.AddColumn<DateTime>(
                name: "User_DOB",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Image_height",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Image_width",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
