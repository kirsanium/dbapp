﻿// <auto-generated />
using System;
using DatabaseApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DatabaseApp.Models.AcademicAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChairId");

                    b.Property<int>("DisciplineId");

                    b.Property<int>("GroupId");

                    b.HasKey("Id");

                    b.HasIndex("ChairId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("GroupId");

                    b.ToTable("AcademicAssignments");
                });

            modelBuilder.Entity("DatabaseApp.Models.AcademicDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacultyId");

                    b.Property<string>("Name");

                    b.Property<int>("Semester");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("AcademicDisciplines");
                });

            modelBuilder.Entity("DatabaseApp.Models.Chair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacultyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Chairs");
                });

            modelBuilder.Entity("DatabaseApp.Models.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisciplineFinalId");

                    b.Property<int>("HoursAmount");

                    b.Property<int>("LessonTypeId");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineFinalId");

                    b.HasIndex("LessonTypeId");

                    b.ToTable("Curricula");
                });

            modelBuilder.Entity("DatabaseApp.Models.DisciplineFinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisciplineId");

                    b.Property<int>("FinalTypeId");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("FinalTypeId");

                    b.ToTable("DisciplineFinals");
                });

            modelBuilder.Entity("DatabaseApp.Models.Dissertation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePresented");

                    b.Property<int>("DissertationTypeId");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.HasIndex("DissertationTypeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Dissertations");
                });

            modelBuilder.Entity("DatabaseApp.Models.DissertationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DissertationTypes");
                });

            modelBuilder.Entity("DatabaseApp.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("DatabaseApp.Models.FinalResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisciplineFinalId");

                    b.Property<string>("Grade");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineFinalId");

                    b.HasIndex("StudentId");

                    b.ToTable("FinalResults");
                });

            modelBuilder.Entity("DatabaseApp.Models.FinalTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FinalId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("FinalId");

                    b.HasIndex("TeacherId");

                    b.ToTable("FinalTeachers");
                });

            modelBuilder.Entity("DatabaseApp.Models.FinalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FinalTypes");
                });

            modelBuilder.Entity("DatabaseApp.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("DatabaseApp.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("FacultyId");

                    b.Property<string>("GroupName");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DatabaseApp.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurriculumId");

                    b.Property<int>("GroupId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("DatabaseApp.Models.LessonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LessonTypes");
                });

            modelBuilder.Entity("DatabaseApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("ChildrenAmount");

                    b.Property<int>("FacultyId");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<int>("GroupId");

                    b.Property<string>("MiddleName");

                    b.Property<float>("Scholarship");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("GenderId");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DatabaseApp.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("ChairId");

                    b.Property<int>("ChildrenAmount");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<bool>("GraduateStudent");

                    b.Property<string>("MiddleName");

                    b.Property<float>("Salary");

                    b.Property<string>("SecondName");

                    b.Property<int>("TeacherCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ChairId");

                    b.HasIndex("GenderId");

                    b.HasIndex("TeacherCategoryId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DatabaseApp.Models.TeacherCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TeacherCategories");
                });

            modelBuilder.Entity("DatabaseApp.Models.Thesis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StudentId");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Theses");
                });

            modelBuilder.Entity("DatabaseApp.Models.AcademicAssignment", b =>
                {
                    b.HasOne("DatabaseApp.Models.Chair", "Chair")
                        .WithMany("AcademicAssignments")
                        .HasForeignKey("ChairId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.AcademicDiscipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.AcademicDiscipline", b =>
                {
                    b.HasOne("DatabaseApp.Models.Faculty", "Faculty")
                        .WithMany("AcademicDisciplines")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Chair", b =>
                {
                    b.HasOne("DatabaseApp.Models.Faculty", "Faculty")
                        .WithMany("Chairs")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Curriculum", b =>
                {
                    b.HasOne("DatabaseApp.Models.DisciplineFinal", "DisciplineFinal")
                        .WithMany()
                        .HasForeignKey("DisciplineFinalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.LessonType", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.DisciplineFinal", b =>
                {
                    b.HasOne("DatabaseApp.Models.AcademicDiscipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.FinalType", "FinalType")
                        .WithMany()
                        .HasForeignKey("FinalTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Dissertation", b =>
                {
                    b.HasOne("DatabaseApp.Models.DissertationType", "DissertationType")
                        .WithMany()
                        .HasForeignKey("DissertationTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Teacher", "Teacher")
                        .WithMany("Dissertations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.FinalResult", b =>
                {
                    b.HasOne("DatabaseApp.Models.DisciplineFinal", "Final")
                        .WithMany()
                        .HasForeignKey("DisciplineFinalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Student", "Student")
                        .WithMany("FinalResults")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.FinalTeacher", b =>
                {
                    b.HasOne("DatabaseApp.Models.DisciplineFinal", "Final")
                        .WithMany()
                        .HasForeignKey("FinalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Group", b =>
                {
                    b.HasOne("DatabaseApp.Models.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Lesson", b =>
                {
                    b.HasOne("DatabaseApp.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Student", b =>
                {
                    b.HasOne("DatabaseApp.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Teacher", b =>
                {
                    b.HasOne("DatabaseApp.Models.Chair", "Chair")
                        .WithMany("Teachers")
                        .HasForeignKey("ChairId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.TeacherCategory", "TeacherCategory")
                        .WithMany()
                        .HasForeignKey("TeacherCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseApp.Models.Thesis", b =>
                {
                    b.HasOne("DatabaseApp.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DatabaseApp.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
