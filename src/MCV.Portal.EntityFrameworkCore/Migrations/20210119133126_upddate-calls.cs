using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Portal.Migrations
{
    public partial class upddatecalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "BudgetCC",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "BudgetStatus",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "CallStatus",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "CatID",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "ExtentionNo",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "ITPurchasingID",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "ITRequestID",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "LastActionTime",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "ProblemByAdmin",
                table: "Calls");

            migrationBuilder.RenameColumn(
                name: "TicketNum",
                table: "Calls",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "SDEntryDate",
                table: "Calls",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "PurchasingApprovalStatus",
                table: "Calls",
                newName: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "Problem",
                table: "Calls",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Calls",
                newName: "TicketNum");

            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Calls",
                newName: "PurchasingApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Calls",
                newName: "SDEntryDate");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Calls",
                newName: "Problem");

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetCC",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BudgetStatus",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CallStatus",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtentionNo",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ITPurchasingID",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ITRequestID",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActionTime",
                table: "Calls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProblemByAdmin",
                table: "Calls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
