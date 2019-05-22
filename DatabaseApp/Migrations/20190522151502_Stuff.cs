using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class Stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GraduateStudent",
                table: "Teachers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePresented",
                table: "Dissertations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraduateStudent",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DatePresented",
                table: "Dissertations");
        }
    }
}
