using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Portal.Migrations
{
    public partial class update_location_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Calls",
                newName: "LocationTypeID");

            migrationBuilder.AddColumn<int>(
                name: "LocationTypeID",
                table: "LocationType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationTypeID",
                table: "LocationType");

            migrationBuilder.RenameColumn(
                name: "LocationTypeID",
                table: "Calls",
                newName: "LocationID");
        }
    }
}
