using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class chetotam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId1",
                table: "AcademicAssignments");

            migrationBuilder.DropIndex(
                name: "IX_AcademicAssignments_ChairId1",
                table: "AcademicAssignments");

            migrationBuilder.DropColumn(
                name: "ChairId1",
                table: "AcademicAssignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairId1",
                table: "AcademicAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicAssignments_ChairId1",
                table: "AcademicAssignments",
                column: "ChairId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId1",
                table: "AcademicAssignments",
                column: "ChairId1",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
