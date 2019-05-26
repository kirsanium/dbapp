using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class finalteachersgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "FinalTeachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FinalTeachers_GroupId",
                table: "FinalTeachers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalTeachers_Groups_GroupId",
                table: "FinalTeachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalTeachers_Groups_GroupId",
                table: "FinalTeachers");

            migrationBuilder.DropIndex(
                name: "IX_FinalTeachers_GroupId",
                table: "FinalTeachers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "FinalTeachers");
        }
    }
}
