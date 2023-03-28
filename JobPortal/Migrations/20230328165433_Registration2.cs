using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class Registration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Jobs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "JobStatus",
                table: "Jobs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "Jobs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryIcon",
                table: "Categories",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Budget",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyDetail",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CompanyDetail",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Jobs",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "JobStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Jobs",
                newName: "JobDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Categories",
                newName: "CategoryIcon");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "CategoryDescription");
        }
    }
}
