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
                .HasForeignKey(s => s.GroupId);    

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Gender)
                .WithMany()
                .HasForeignKey(s => s.GenderId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.FinalResults)
                .WithOne(fr => fr.Student)
                .HasForeignKey(fr => fr.StudentId);
            
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Faculty)
                .WithMany()
                .HasForeignKey(s => s.FacultyId);
        }

        public static void ConfigureGroupsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Faculty)
                .WithMany(f => f.Groups)
                .HasForeignKey(g => g.FacultyId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Lessons)
                .WithOne(l => l.Group)
                .HasForeignKey(l => l.GroupId);

            modelBuilder.Entity<Group>()
                .Property(g => g.GroupName);
            
            modelBuilder.Entity<Group>()
                .Property(g => g.StartDate);
            
            modelBuilder.Entity<Group>()
                .Property(g => g.EndDate);
        }

        public static void ConfigureTeachersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Chair)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.ChairId);
            
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.Gender)
                .WithMany()
                .HasForeignKey(s => s.GenderId);
            
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.TeacherCategory)
                .WithMany()
                .HasForeignKey(s => s.TeacherCategoryId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Dissertations)
                .WithOne(d => d.Teacher)
                .HasForeignKey(d => d.TeacherId);
        }

        public static void ConfigureChairsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chair>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.Chairs)
                .HasForeignKey(c => c.FacultyId);
            
            modelBuilder.Entity<Chair>()
                .Property(c => c.Name);
        }

        public static void ConfigureAcademicAssignmentsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Chair)
                .WithMany()
                .HasForeignKey(aa => aa.ChairId);
            
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Discipline)
                .WithMany()
                .HasForeignKey(aa => aa.DisciplineId);
            
            modelBuilder.Entity<AcademicAssignment>()
                .HasOne(aa => aa.Group)
                .WithMany()
                .HasForeignKey(aa => aa.GroupId);
        }

        public static void ConfigureAcademicDisciplinesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicDiscipline>()
                .HasOne(ad => ad.Faculty)
                .WithMany(f => f.AcademicDisciplines)
                .HasForeignKey(ad => ad.FacultyId);

            modelBuilder.Entity<AcademicDiscipline>()
                .Property(ad => ad.Semester);
            
            modelBuilder.Entity<AcademicDiscipline>()
                .Property(ad => ad.Name);
        }

        public static void ConfigureCurriculaTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curriculum>()
                .HasOne(c => c.DisciplineFinal)
                .WithMany()
                .HasForeignKey(c => c.DisciplineFinalId);
            
            modelBuilder.Entity<Curriculum>()
                .HasOne(c => c.LessonType)
                .WithMany()
                .HasForeignKey(c => c.LessonTypeId);
            
            modelBuilder.Entity<Curriculum>()
                .Property(c => c.HoursAmount);
        }

        public static void ConfigureDisciplineFinalsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineFinal>()
                .HasOne(c => c.Discipline)
                .WithMany()
                .HasForeignKey(c => c.DisciplineId);
            
            modelBuilder.Entity<DisciplineFinal>()
                .HasOne(c => c.FinalType)
                .WithMany()
                .HasForeignKey(c => c.FinalTypeId);
        }

        public static void ConfigureDissertationsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dissertation>()
                .HasOne(d => d.DissertationType)
                .WithMany()
                .HasForeignKey(d => d.DissertationTypeId);
        }

        public static void ConfigureFinalResultsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalResult>()
                .HasOne(fr => fr.Final)
                .WithMany()
                .HasForeignKey(fr => fr.DisciplineFinalId);
            
            modelBuilder.Entity<FinalResult>()
                .Property(fr => fr.Grade);
        }

        public static void ConfigureFinalTeachersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalTeacher>()
                .HasOne(ft => ft.Final)
                .WithMany()
                .HasForeignKey(ft => ft.FinalId);
            
            modelBuilder.Entity<FinalTeacher>()
                .HasOne(ft => ft.Teacher)
                .WithMany()
                .HasForeignKey(ft => ft.TeacherId);
        }

        public static void ConfigureLessonsTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Curriculum)
                .WithMany()
                .HasForeignKey(l => l.CurriculumId);
            
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Teacher)
                .WithMany()
                .HasForeignKey(l => l.TeacherId);
        }
        
        public static void ConfigureThesesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId);
            
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Teacher)
                .WithMany()
                .HasForeignKey(t => t.TeacherId);
        }
        
        public static void ConfigureDissertationTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId);
            
            modelBuilder.Entity<DissertationType>()
                .Property(dt => dt.Name);
        }
        
        public static void ConfigureFacultiesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(f => f.Name);
        }
        
        public static void ConfigureFinalTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinalType>()
                .Property(f => f.Name);
        }
        
        public static void ConfigureGendersTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .Property(f => f.Name);
        }
        
        public static void ConfigureLessonTypesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonType>()
                .Property(f => f.Name);
        }
        
        public static void ConfigureTeacherCategoriesTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCategory>()
                .Property(f => f.Name);
        }
    }
}