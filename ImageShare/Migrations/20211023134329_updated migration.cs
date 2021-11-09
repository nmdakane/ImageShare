using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageShare.Migrations
{
    public partial class updatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Person",
                newName: "User_Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "User_Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Person",
                newName: "User_Email");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "Person",
                newName: "User_DOB");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Person",
                newName: "User_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "User_Surname",
                table: "People",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "People",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "User_Email",
                table: "People",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "User_DOB",
                table: "People",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "People",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "id");
        }
    }
}
