using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_People_Person",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "Person",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_People_Person",
                table: "Images",
                column: "Person",
                principalTable: "People",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_People_Person",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "Person",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_People_Person",
                table: "Images",
                column: "Person",
                principalTable: "People",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
