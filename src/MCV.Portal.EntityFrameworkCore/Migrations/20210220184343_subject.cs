using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Portal.Migrations
{
    public partial class subject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbpSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinsToWatch = table.Column<TimeSpan>(type: "time", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchesSite",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallsProblems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYID = table.Column<long>(type: "bigint", nullable: false),
                    ProblemCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATEGORYDESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemSubCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallsProblems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATEGORYDESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesService", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_SubjectId",
                table: "AbpUsers",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpSubject_SubjectId",
                table: "AbpUsers",
                column: "SubjectId",
                principalTable: "AbpSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpSubject_SubjectId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AbpSubject");

            migrationBuilder.DropTable(
                name: "BranchesSite");

            migrationBuilder.DropTable(
                name: "CallsProblems");

            migrationBuilder.DropTable(
                name: "CategoriesService");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_SubjectId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "AbpUsers");
        }
    }
}
