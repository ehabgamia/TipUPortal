using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Portal.Migrations
{
    public partial class updtlocttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationType",
                table: "LocationType");

            migrationBuilder.RenameTable(
                name: "LocationType",
                newName: "BranchsView");

            migrationBuilder.RenameColumn(
                name: "LocationTypeID",
                table: "BranchsView",
                newName: "SITEID");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "BranchsView",
                newName: "NAME");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchsView",
                table: "BranchsView",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchsView",
                table: "BranchsView");

            migrationBuilder.RenameTable(
                name: "BranchsView",
                newName: "LocationType");

            migrationBuilder.RenameColumn(
                name: "SITEID",
                table: "LocationType",
                newName: "LocationTypeID");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "LocationType",
                newName: "LocationName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationType",
                table: "LocationType",
                column: "Id");
        }
    }
}
