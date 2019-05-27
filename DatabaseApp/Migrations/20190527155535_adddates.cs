using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class adddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Curricula",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Curricula",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "AcademicAssignments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "AcademicAssignments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Curricula");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Curricula");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "AcademicAssignments");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "AcademicAssignments");
        }
    }
}
