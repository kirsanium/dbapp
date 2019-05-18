using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class ChangeGroupYearColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_AcademicDisciplines_DisciplineId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_Groups_GroupId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicDisciplines_Faculties_FacultyId",
                table: "AcademicDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicDisciplines_DisciplineId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_FinalTypes_FinalTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_LessonTypes_LessonTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineFinals_AcademicDisciplines_DisciplineId",
                table: "DisciplineFinals");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineFinals_FinalTypes_FinalTypeId",
                table: "DisciplineFinals");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_DissertationTypes_DissertationTypeId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalResults_DisciplineFinals_DisciplineFinalId",
                table: "FinalResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalResults_Students_StudentId",
                table: "FinalResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalTeachers_DisciplineFinals_FinalId",
                table: "FinalTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalTeachers_Teachers_TeacherId",
                table: "FinalTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Curricula_CurriculumId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Chairs_ChairId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Genders_GenderId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherCategories_TeacherCategoryId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Teachers_TeacherId",
                table: "Theses");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Groups",
                newName: "StartYear");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeacherCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LessonTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FinalTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "FinalResults",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DissertationTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chairs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicDisciplines",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId",
                table: "AcademicAssignments",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_AcademicDisciplines_DisciplineId",
                table: "AcademicAssignments",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_Groups_GroupId",
                table: "AcademicAssignments",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicDisciplines_Faculties_FacultyId",
                table: "AcademicDisciplines",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicDisciplines_DisciplineId",
                table: "Curricula",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_FinalTypes_FinalTypeId",
                table: "Curricula",
                column: "FinalTypeId",
                principalTable: "FinalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_LessonTypes_LessonTypeId",
                table: "Curricula",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineFinals_AcademicDisciplines_DisciplineId",
                table: "DisciplineFinals",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineFinals_FinalTypes_FinalTypeId",
                table: "DisciplineFinals",
                column: "FinalTypeId",
                principalTable: "FinalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_DissertationTypes_DissertationTypeId",
                table: "Dissertations",
                column: "DissertationTypeId",
                principalTable: "DissertationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalResults_DisciplineFinals_DisciplineFinalId",
                table: "FinalResults",
                column: "DisciplineFinalId",
                principalTable: "DisciplineFinals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalResults_Students_StudentId",
                table: "FinalResults",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalTeachers_DisciplineFinals_FinalId",
                table: "FinalTeachers",
                column: "FinalId",
                principalTable: "DisciplineFinals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalTeachers_Teachers_TeacherId",
                table: "FinalTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Curricula_CurriculumId",
                table: "Lessons",
                column: "CurriculumId",
                principalTable: "Curricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Chairs_ChairId",
                table: "Teachers",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Genders_GenderId",
                table: "Teachers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherCategories_TeacherCategoryId",
                table: "Teachers",
                column: "TeacherCategoryId",
                principalTable: "TeacherCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Teachers_TeacherId",
                table: "Theses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_AcademicDisciplines_DisciplineId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicAssignments_Groups_GroupId",
                table: "AcademicAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicDisciplines_Faculties_FacultyId",
                table: "AcademicDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicDisciplines_DisciplineId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_FinalTypes_FinalTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_LessonTypes_LessonTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineFinals_AcademicDisciplines_DisciplineId",
                table: "DisciplineFinals");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineFinals_FinalTypes_FinalTypeId",
                table: "DisciplineFinals");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_DissertationTypes_DissertationTypeId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalResults_DisciplineFinals_DisciplineFinalId",
                table: "FinalResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalResults_Students_StudentId",
                table: "FinalResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalTeachers_DisciplineFinals_FinalId",
                table: "FinalTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalTeachers_Teachers_TeacherId",
                table: "FinalTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Curricula_CurriculumId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Chairs_ChairId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Genders_GenderId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherCategories_TeacherCategoryId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Teachers_TeacherId",
                table: "Theses");

            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "StartYear",
                table: "Groups",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeacherCategories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LessonTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FinalTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "FinalResults",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DissertationTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chairs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicDisciplines",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_Chairs_ChairId",
                table: "AcademicAssignments",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_AcademicDisciplines_DisciplineId",
                table: "AcademicAssignments",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicAssignments_Groups_GroupId",
                table: "AcademicAssignments",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicDisciplines_Faculties_FacultyId",
                table: "AcademicDisciplines",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicDisciplines_DisciplineId",
                table: "Curricula",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_FinalTypes_FinalTypeId",
                table: "Curricula",
                column: "FinalTypeId",
                principalTable: "FinalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_LessonTypes_LessonTypeId",
                table: "Curricula",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineFinals_AcademicDisciplines_DisciplineId",
                table: "DisciplineFinals",
                column: "DisciplineId",
                principalTable: "AcademicDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineFinals_FinalTypes_FinalTypeId",
                table: "DisciplineFinals",
                column: "FinalTypeId",
                principalTable: "FinalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_DissertationTypes_DissertationTypeId",
                table: "Dissertations",
                column: "DissertationTypeId",
                principalTable: "DissertationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalResults_DisciplineFinals_DisciplineFinalId",
                table: "FinalResults",
                column: "DisciplineFinalId",
                principalTable: "DisciplineFinals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalResults_Students_StudentId",
                table: "FinalResults",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalTeachers_DisciplineFinals_FinalId",
                table: "FinalTeachers",
                column: "FinalId",
                principalTable: "DisciplineFinals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalTeachers_Teachers_TeacherId",
                table: "FinalTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Curricula_CurriculumId",
                table: "Lessons",
                column: "CurriculumId",
                principalTable: "Curricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Chairs_ChairId",
                table: "Teachers",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Genders_GenderId",
                table: "Teachers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherCategories_TeacherCategoryId",
                table: "Teachers",
                column: "TeacherCategoryId",
                principalTable: "TeacherCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Teachers_TeacherId",
                table: "Theses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
