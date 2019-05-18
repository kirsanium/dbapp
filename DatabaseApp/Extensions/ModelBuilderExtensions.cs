using DatabaseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureStudentsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .IsRequired();    

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Gender)
                .WithMany()
                .HasForeignKey(s => s.GenderId)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(s => s.FinalResults)
                .WithOne(fr => fr.Student)
                .HasForeignKey(fr => fr.StudentId)
                .IsRequired();
            
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Faculty)
                .WithMany()
                .HasForeignKey(s => s.FacultyId)
                .IsRequired();
        }

        public static void ConfigureGroupsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Faculty)
                .WithMany(f => f.Groups)
                .HasForeignKey(g => g.FacultyId)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Lessons)
                .WithOne(l => l.Group)
                .HasForeignKey(l => l.GroupId)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .Property(g => g.GroupName)
                .IsRequired();
            
            modelBuilder.Entity<Group>()
                .Property(g => g.StartYear)
                .IsRequired();
            
            modelBuilder.Entity<Group>()
                .Property(g => g.EndYear)
                .IsRequired();
        }

        public static void ConfigureTeachersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Chair)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.ChairId)
                .IsRequired();
            
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.Gender)
                .WithMany()
                .HasForeignKey(s => s.GenderId)
                .IsRequired();
            
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.TeacherCategory)
                .WithMany()
                .HasForeignKey(s => s.TeacherCategoryId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Dissertations)
                .WithOne(d => d.Teacher)
                .HasForeignKey(d => d.TeacherId)
                .IsRequired();
        }

        public static void ConfigureChairsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chair>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.Chairs)
                .HasForeignKey(c => c.FacultyId)
                .IsRequired();
            
            modelBuilder.Entity<Chair>()
                .Property(c => c.Name)
                .IsRequired();
        }

        public static void ConfigureAcademicAssignmentsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Chair)
                .WithMany()
                .HasForeignKey(aa => aa.ChairId)
                .IsRequired();
            
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Discipline)
                .WithMany()
                .HasForeignKey(aa => aa.DisciplineId)
                .IsRequired();
            
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Group)
                .WithMany()
                .HasForeignKey(aa => aa.GroupId)
                .IsRequired();
        }

        public static void ConfigureAcademicDisciplinesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicDiscipline>()
                .HasOne(ad => ad.Faculty)
                .WithMany(f => f.AcademicDisciplines)
                .HasForeignKey(ad => ad.FacultyId)
                .IsRequired();

            modelBuilder.Entity<AcademicDiscipline>()
                .Property(ad => ad.Semester)
                .IsRequired();
            
            modelBuilder.Entity<AcademicDiscipline>()
                .Property(ad => ad.Name)
                .IsRequired();
        }

        public static void ConfigureCurriculaTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curriculum>()
                .HasOne(c => c.DisciplineFinal)
                .WithMany()
                .HasForeignKey(c => c.DisciplineFinalId)
                .IsRequired();
            
            modelBuilder.Entity<Curriculum>()
                .HasOne(c => c.LessonType)
                .WithMany()
                .HasForeignKey(c => c.LessonTypeId)
                .IsRequired();
            
            modelBuilder.Entity<Curriculum>()
                .Property(c => c.HoursAmount)
                .IsRequired();
        }

        public static void ConfigureDisciplineFinalsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineFinal>()
                .HasOne(c => c.Discipline)
                .WithMany()
                .HasForeignKey(c => c.DisciplineId)
                .IsRequired();
            
            modelBuilder.Entity<DisciplineFinal>()
                .HasOne(c => c.FinalType)
                .WithMany()
                .HasForeignKey(c => c.FinalTypeId)
                .IsRequired();
        }

        public static void ConfigureDissertationsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dissertation>()
                .HasOne(d => d.DissertationType)
                .WithMany()
                .HasForeignKey(d => d.DissertationTypeId)
                .IsRequired();
        }

        public static void ConfigureFinalResultsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalResult>()
                .HasOne(fr => fr.Final)
                .WithMany()
                .HasForeignKey(fr => fr.DisciplineFinalId)
                .IsRequired();
            
            modelBuilder.Entity<FinalResult>()
                .Property(fr => fr.Grade)
                .IsRequired();
        }

        public static void ConfigureFinalTeachersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalTeacher>()
                .HasOne(ft => ft.Final)
                .WithMany()
                .HasForeignKey(ft => ft.FinalId)
                .IsRequired();
            
            modelBuilder.Entity<FinalTeacher>()
                .HasOne(ft => ft.Teacher)
                .WithMany()
                .HasForeignKey(ft => ft.TeacherId)
                .IsRequired();
        }

        public static void ConfigureLessonsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Curriculum)
                .WithMany()
                .HasForeignKey(l => l.CurriculumId)
                .IsRequired();
            
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Teacher)
                .WithMany()
                .HasForeignKey(l => l.TeacherId)
                .IsRequired();
        }
        
        public static void ConfigureThesesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .IsRequired();
            
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Teacher)
                .WithMany()
                .HasForeignKey(t => t.TeacherId)
                .IsRequired();
        }
        
        public static void ConfigureDissertationTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .IsRequired();
            
            modelBuilder.Entity<DissertationType>()
                .Property(dt => dt.Name)
                .IsRequired();
        }
        
        public static void ConfigureFacultiesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(f => f.Name)
                .IsRequired();
        }
        
        public static void ConfigureFinalTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalType>()
                .Property(f => f.Name)
                .IsRequired();
        }
        
        public static void ConfigureGendersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .Property(f => f.Name)
                .IsRequired();
        }
        
        public static void ConfigureLessonTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonType>()
                .Property(f => f.Name)
                .IsRequired();
        }
        
        public static void ConfigureTeacherCategoriesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCategory>()
                .Property(f => f.Name)
                .IsRequired();
        }
    }
}