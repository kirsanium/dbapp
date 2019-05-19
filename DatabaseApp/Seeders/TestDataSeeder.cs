using System;
using DatabaseApp.Models;

namespace DatabaseApp.Seeders
{
    public class TestDataSeeder : IDataSeeder
    {
        public void Seed(AppDbContext dbContext)
        {
            SeedGenders(dbContext);
            SeedFinalTypes(dbContext);
            SeedLessonTypes(dbContext);
            SeedTeacherCategories(dbContext);
            SeedDissertationTypes(dbContext);

            SeedFaculties(dbContext);
            SeedChairs(dbContext);
            SeedAcademicDisciplines(dbContext);
            SeedGroups(dbContext);
            SeedDisciplineFinals(dbContext);
            SeedCurricula(dbContext);
            SeedStudents(dbContext);
            SeedTeachers(dbContext);
            SeedAcademicAssignments(dbContext);
            SeedDissertations(dbContext);
            SeedFinalTeachers(dbContext);
            SeedLessons(dbContext);
            SeedTheses(dbContext);
            SeedFinalResults(dbContext);
        }

        private static void SeedGenders(AppDbContext dbContext)
        {
            dbContext.Genders.Add(new Gender {Name = "Male"});
            dbContext.Genders.Add(new Gender {Name = "Female"});
            
            dbContext.SaveChanges();
        }

        private static void SeedFinalTypes(AppDbContext dbContext)
        {
            dbContext.FinalTypes.Add(new FinalType {Name = "Exam"});
            dbContext.FinalTypes.Add(new FinalType {Name = "Credit"});
            dbContext.FinalTypes.Add(new FinalType {Name = "DiffCredit"});
            
            dbContext.SaveChanges();
        }

        private static void SeedLessonTypes(AppDbContext dbContext)
        {
            dbContext.LessonTypes.Add(new LessonType {Name = "Lecture"});
            dbContext.LessonTypes.Add(new LessonType {Name = "Seminar"});
            dbContext.LessonTypes.Add(new LessonType {Name = "Lab"});
            
            dbContext.SaveChanges();
        }

        private static void SeedTeacherCategories(AppDbContext dbContext)
        {
            dbContext.TeacherCategories.Add(new TeacherCategory {Name = "Assistant"});
            dbContext.TeacherCategories.Add(new TeacherCategory {Name = "Teacher"});
            dbContext.TeacherCategories.Add(new TeacherCategory {Name = "Associate Professor"});
            dbContext.TeacherCategories.Add(new TeacherCategory {Name = "Professor"});
            
            dbContext.SaveChanges();
        }

        private static void SeedDissertationTypes(AppDbContext dbContext)
        {
            dbContext.DissertationTypes.Add(new DissertationType {Name = "Candidate's"});
            dbContext.DissertationTypes.Add(new DissertationType {Name = "PhD's"});
            
            dbContext.SaveChanges();
        }

        private static void SeedFaculties(AppDbContext dbContext)
        {
            dbContext.Faculties.Add(new Faculty {Name = "IT Faculty"});
            dbContext.Faculties.Add(new Faculty {Name = "Foreign Languages Faculty"});
            
            dbContext.SaveChanges();
        }

        private static void SeedChairs(AppDbContext dbContext)
        {
            dbContext.Chairs.Add(new Chair {FacultyId = 1, Name = "KOI"});
            dbContext.Chairs.Add(new Chair {FacultyId = 1, Name = "SI"});
            dbContext.Chairs.Add(new Chair {FacultyId = 1, Name = "PV"});
            
            dbContext.Chairs.Add(new Chair {FacultyId = 2, Name = "KIA"});
            dbContext.Chairs.Add(new Chair {FacultyId = 2, Name = "SOYA"});
            dbContext.Chairs.Add(new Chair {FacultyId = 2, Name = "PIVO"});
            
            dbContext.SaveChanges();
        }

        private static void SeedAcademicDisciplines(AppDbContext dbContext)
        {
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Matan", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Proga", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Fizra", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Matan", Semester = 2});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Fizika", Semester = 2});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 1, Name = "Fizra", Semester = 2});

            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "English", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "Matan", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "Fizra", Semester = 1});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "English", Semester = 2});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "German", Semester = 2});
            dbContext.AcademicDisciplines.Add(new AcademicDiscipline {FacultyId = 2, Name = "Fizra", Semester = 2});
            
            dbContext.SaveChanges();
        }

        private static void SeedGroups(AppDbContext dbContext)
        {
            dbContext.Groups.Add(new Group {StartYear = 2016, EndYear = 2020, FacultyId = 1, GroupName = "16201"});
            dbContext.Groups.Add(new Group {StartYear = 2016, EndYear = 2020, FacultyId = 1, GroupName = "16202"});
            
            dbContext.Groups.Add(new Group {StartYear = 2017, EndYear = 2021, FacultyId = 1, GroupName = "17201"});
            dbContext.Groups.Add(new Group {StartYear = 2017, EndYear = 2021, FacultyId = 1, GroupName = "17202"});
            
            dbContext.Groups.Add(new Group {StartYear = 2016, EndYear = 2020, FacultyId = 2, GroupName = "16301"});
            dbContext.Groups.Add(new Group {StartYear = 2016, EndYear = 2020, FacultyId = 2, GroupName = "16302"});
            
            dbContext.Groups.Add(new Group {StartYear = 2017, EndYear = 2021, FacultyId = 2, GroupName = "17301"});
            dbContext.Groups.Add(new Group {StartYear = 2017, EndYear = 2021, FacultyId = 2, GroupName = "17302"});
            
            dbContext.SaveChanges();
        }

        private static void SeedDisciplineFinals(AppDbContext dbContext)
        {
            const int examDisciplinesAmount = 12;
            for (var i = 1; i <= examDisciplinesAmount; ++i)
            {
                dbContext.DisciplineFinals.Add(new DisciplineFinal {DisciplineId = i, FinalTypeId = 1});
            }
            
            dbContext.SaveChanges();
        }

        private static void SeedCurricula(AppDbContext dbContext)
        {
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 1, LessonTypeId = 1, HoursAmount = 20}); //1
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 1, LessonTypeId = 2, HoursAmount = 20}); //2
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 2, LessonTypeId = 1, HoursAmount = 20}); //3
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 2, LessonTypeId = 2, HoursAmount = 20}); //4
            dbContext.Curricula .Add(new Curriculum
                {DisciplineFinalId = 2, LessonTypeId = 3, HoursAmount = 20}); //5       

            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 3, LessonTypeId = 2, HoursAmount = 20}); //6
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 4, LessonTypeId = 1, HoursAmount = 20}); //7
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 4, LessonTypeId = 2, HoursAmount = 20}); //8
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 5, LessonTypeId = 1, HoursAmount = 20}); //9
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 5, LessonTypeId = 2, HoursAmount = 20}); //10
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 5, LessonTypeId = 3, HoursAmount = 20}); //11
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 6, LessonTypeId = 2, HoursAmount = 20}); //12
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 7, LessonTypeId = 1, HoursAmount = 20}); //13
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 7, LessonTypeId = 2, HoursAmount = 20}); //14
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 8, LessonTypeId = 1, HoursAmount = 20}); //15
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 8, LessonTypeId = 2, HoursAmount = 20}); //16
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 9, LessonTypeId = 2, HoursAmount = 20}); //17
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 10, LessonTypeId = 1, HoursAmount = 20}); //18
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 10, LessonTypeId = 2, HoursAmount = 20}); //19
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 11, LessonTypeId = 1, HoursAmount = 20}); //20
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 11, LessonTypeId = 2, HoursAmount = 20}); //21
            
            dbContext.Curricula.Add(new Curriculum
                {DisciplineFinalId = 12, LessonTypeId = 2, HoursAmount = 20}); //22
            
            dbContext.SaveChanges();
        }

        private static void SeedStudents(AppDbContext dbContext)
        {
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Kirsanov",
                MiddleName = "Viktorovich",
                FacultyId = 1,
                Scholarship = 3000,
                BirthDate = new DateTime(1998, 04, 16),
                ChildrenAmount = 0,
                GenderId = 1,
                GroupId = 1
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Petrovich",
                MiddleName = "Viktorovich",
                FacultyId = 1,
                Scholarship = 3000,
                BirthDate = new DateTime(1998, 11, 16),
                ChildrenAmount = 0,
                GenderId = 1,
                GroupId = 2
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Kirsanov",
                MiddleName = "Anatolich",
                FacultyId = 1,
                Scholarship = 5000,
                BirthDate = new DateTime(1998, 12, 16),
                ChildrenAmount = 3,
                GenderId = 1,
                GroupId = 3
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Vasilisa",
                SecondName = "Kirsanova",
                MiddleName = "Viktorovna",
                FacultyId = 1,
                Scholarship = 3000,
                BirthDate = new DateTime(1970, 04, 16),
                ChildrenAmount = 10,
                GenderId = 2,
                GroupId = 4
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Privet",
                MiddleName = "Viktorovich",
                FacultyId = 2,
                Scholarship = 3000,
                BirthDate = new DateTime(1997, 04, 16),
                ChildrenAmount = 0,
                GenderId = 1,
                GroupId = 5
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Kirsanov",
                MiddleName = "Evgenichna",
                FacultyId = 2,
                Scholarship = 0,
                BirthDate = new DateTime(1998, 04, 16),
                ChildrenAmount = 0,
                GenderId = 2,
                GroupId = 6
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Nikita",
                SecondName = "Kirsanov",
                MiddleName = "Jackson",
                FacultyId = 2,
                Scholarship = 0,
                BirthDate = new DateTime(1998, 08, 16),
                ChildrenAmount = 0,
                GenderId = 1,
                GroupId = 7
            });
            
            dbContext.Students.Add(new Student
            {
                FirstName = "Diman",
                SecondName = "Kirsanov",
                MiddleName = "Viktorovich",
                FacultyId = 2,
                Scholarship = 1000,
                BirthDate = new DateTime(1998, 01, 16),
                ChildrenAmount = 2,
                GenderId = 1,
                GroupId = 8
            });
            
            dbContext.SaveChanges();
        }

        private static void SeedTeachers(AppDbContext dbContext)
        {
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Dmitriy",
                SecondName = "Irtegov",
                MiddleName = "Valentinovich",
                ChairId = 1,
                Salary = 3000,
                BirthDate = new DateTime(1966, 04, 16),
                ChildrenAmount = 2,
                GenderId = 1,
                TeacherCategoryId = 2
            });
            
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Anton",
                SecondName = "Irtegov",
                MiddleName = "Valentinovich",
                ChairId = 2,
                Salary = 4000,
                BirthDate = new DateTime(1986, 04, 16),
                ChildrenAmount = 1,
                GenderId = 1,
                TeacherCategoryId = 3
            });
            
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Janna",
                SecondName = "Irtegova",
                MiddleName = "Valentinovna",
                ChairId = 3,
                Salary = 2000,
                BirthDate = new DateTime(1966, 02, 16),
                ChildrenAmount = 0,
                GenderId = 2,
                TeacherCategoryId = 2
            });
            
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Dmitriy",
                SecondName = "Irtegov",
                MiddleName = "Valentinestro",
                ChairId = 4,
                Salary = 7000,
                BirthDate = new DateTime(1956, 04, 16),
                ChildrenAmount = 2,
                GenderId = 1,
                TeacherCategoryId = 3
            });
            
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Dmitrina",
                SecondName = "Irtegovitra",
                MiddleName = "Ananasovna",
                ChairId = 5,
                Salary = 3000,
                BirthDate = new DateTime(1966, 04, 19),
                ChildrenAmount = 2,
                GenderId = 2,
                TeacherCategoryId = 2
            });
            
            dbContext.Teachers.Add(new Teacher
            {
                FirstName = "Dmitriy2",
                SecondName = "Irtegov2",
                MiddleName = "Valentinovich2",
                ChairId = 6,
                Salary = 3000,
                BirthDate = new DateTime(1963, 04, 16),
                ChildrenAmount = 5,
                GenderId = 1,
                TeacherCategoryId = 3
            });
            
            dbContext.SaveChanges();
        }

        private static void SeedAcademicAssignments(AppDbContext dbContext)
        {
            const int academicDisciplinesAmount = 6;
            const int groupsAmount = 4;
            const int chairsAmount = 3;
            for (var i = 1; i <= academicDisciplinesAmount; ++i)
            for (var j = 1; j <= groupsAmount; ++j)
            {
                dbContext.AcademicAssignments.Add(
                    new AcademicAssignment
                    {
                        DisciplineId = i, 
                        GroupId = j, 
                        ChairId = i % 3 + 1
                    });
                dbContext.AcademicAssignments.Add(
                    new AcademicAssignment
                    {
                        DisciplineId = i + academicDisciplinesAmount,
                        GroupId = j + groupsAmount, 
                        ChairId = i % 3 + 1 + chairsAmount
                    });
            }
            
            dbContext.SaveChanges();
        }

        private static void SeedDissertations(AppDbContext dbContext)
        {
            dbContext.Dissertations.Add(new Dissertation {DissertationTypeId = 1, TeacherId = 1});
            dbContext.Dissertations.Add(new Dissertation {DissertationTypeId = 2, TeacherId = 2});
            
            dbContext.SaveChanges();
        }

        private static void SeedFinalTeachers(AppDbContext dbContext)
        {
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 1, TeacherId = 1});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 2, TeacherId = 2});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 3, TeacherId = 3});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 4, TeacherId = 1});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 5, TeacherId = 2});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 6, TeacherId = 3});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 7, TeacherId = 4});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 8, TeacherId = 5});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 9, TeacherId = 6});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 10, TeacherId = 4});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 11, TeacherId = 5});
            dbContext.FinalTeachers.Add(new FinalTeacher {FinalId = 12, TeacherId = 6});
            
            dbContext.SaveChanges();
        }

        private static void SeedLessons(AppDbContext dbContext)
        {
            for (var i = 1; i <= 4; ++i)
            {
                dbContext.Lessons.Add(new Lesson {CurriculumId = 1, TeacherId = 1, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 2, TeacherId = 1, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 3, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 4, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 5, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 6, TeacherId = 3, GroupId = i});
                
                dbContext.Lessons.Add(new Lesson {CurriculumId = 7, TeacherId = 1, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 8, TeacherId = 1, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 9, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 10, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 11, TeacherId = 2, GroupId = i});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 12, TeacherId = 3, GroupId = i});
                
                dbContext.Lessons.Add(new Lesson {CurriculumId = 13, TeacherId = 4, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 14, TeacherId = 4, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 15, TeacherId = 5, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 16, TeacherId = 5, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 17, TeacherId = 6, GroupId = i + 4});
                
                dbContext.Lessons.Add(new Lesson {CurriculumId = 18, TeacherId = 4, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 19, TeacherId = 4, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 20, TeacherId = 5, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 21, TeacherId = 5, GroupId = i + 4});
                dbContext.Lessons.Add(new Lesson {CurriculumId = 22, TeacherId = 6, GroupId = i + 4});
            }
            
            dbContext.SaveChanges();
        }

        private static void SeedTheses(AppDbContext dbContext)
        {
            dbContext.Theses.Add(new Thesis
                {StudentId = 1, TeacherId = 1, Title = "Totally new way to write \"Hello World\""});
            dbContext.Theses.Add(new Thesis
                {StudentId = 2, TeacherId = 2, Title = "Random not interesting stuff"});
            
            dbContext.SaveChanges();
        }

        private static void SeedFinalResults(AppDbContext dbContext)
        {
            const int studentsAmount = 4;
            const int finalsAmount = 6;
            var grade = "3";
            
            for (var i = 1; i <= studentsAmount; i++)
            for (var j = 1; j <= finalsAmount; j++)
            {
                dbContext.FinalResults.Add(new FinalResult()
                {
                    DisciplineFinalId = j,
                    StudentId = i,
                    Grade = grade
                });
                grade = NextGrade(grade);
                
                dbContext.FinalResults.Add(new FinalResult()
                {
                    DisciplineFinalId = j + finalsAmount,
                    StudentId = i + studentsAmount,
                    Grade = grade
                });
                grade = NextGrade(grade);
            }
            
            dbContext.SaveChanges();
        }

        private static string NextGrade(string grade)
        {
            switch (grade)
            {
                case "3":
                {
                    grade = "4";
                    break;
                }
                case "4":
                {
                    grade = "5";
                    break;
                }
                case "5":
                {
                    grade = "3";
                    break;
                }
                default:
                    grade = "4";
                    break;
            }

            return grade;
        }
    }
}