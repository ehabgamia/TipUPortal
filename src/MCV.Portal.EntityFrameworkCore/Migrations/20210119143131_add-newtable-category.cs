using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Portal.Migrations
{
    public partial class addnewtablecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Calls");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Calls");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
