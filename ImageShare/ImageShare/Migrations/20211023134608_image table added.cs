using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class imagetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "User_id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Person = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_width = table.Column<int>(type: "int", nullable: false),
                    Image_height = table.Column<int>(type: "int", nullable: false),
                    imageid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image_id);
                    table.ForeignKey(
                        name: "FK_Images_Images_imageid",
                        column: x => x.imageid,
                        principalTable: "Images",
                        principalColumn: "Image_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_People_Person",
                        column: x => x.Person,
                        principalTable: "People",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_imageid",
                table: "Images",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Person",
                table: "Images",
                column: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "User_id");
        }
    }
}
