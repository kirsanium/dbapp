using System.Linq;
using DatabaseApp.Extensions;
using DatabaseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<AcademicAssignment> AcademicAssignments { get; set; }
        public DbSet<AcademicDiscipline> AcademicDisciplines { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<DisciplineFinal> DisciplineFinals { get; set; }
        public DbSet<Dissertation> Dissertations { get; set; }
        public DbSet<DissertationType> DissertationTypes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FinalResult> FinalResults { get; set; }
        public DbSet<FinalTeacher> FinalTeachers { get; set; }
        public DbSet<FinalType> FinalTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCategory> TeacherCategories { get; set; }
        public DbSet<Thesis> Theses { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureTables(modelBuilder);

            ChangeCascadeDeleteBehaviour(modelBuilder, DeleteBehavior.Restrict);
        }

        private static void ConfigureTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureAcademicAssignmentsTable();
            modelBuilder.ConfigureAcademicDisciplinesTable();
            modelBuilder.ConfigureChairsTable();
            modelBuilder.ConfigureCurriculaTable();
            modelBuilder.ConfigureDisciplineFinalsTable();
            modelBuilder.ConfigureDissertationsTable();
            modelBuilder.ConfigureDissertationTypesTable();
            modelBuilder.ConfigureFacultiesTable();
            modelBuilder.ConfigureFinalResultsTable();
            modelBuilder.ConfigureFinalTeachersTable();
            modelBuilder.ConfigureFinalTypesTable();
            modelBuilder.ConfigureGendersTable();
            modelBuilder.ConfigureGroupsTable();
            modelBuilder.ConfigureLessonsTable();
            modelBuilder.ConfigureLessonTypesTable();
            modelBuilder.ConfigureStudentsTable();
            modelBuilder.ConfigureTeachersTable();
            modelBuilder.ConfigureTeacherCategoriesTable();
            modelBuilder.ConfigureThesesTable();
        }

        private static void ChangeCascadeDeleteBehaviour(ModelBuilder modelBuilder, DeleteBehavior deleteBehavior)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = deleteBehavior;
        }
    }
}