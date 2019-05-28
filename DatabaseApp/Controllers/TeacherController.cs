using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{   
    [Route("api/teacher")]
    [Produces("application/json")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search teachers with specific parameters
        /// </summary>
        /// <param name="request">Request to get teachers</param>
        /// <returns>List of teachers matching the query</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers([FromQuery] GetTeachersRequest request)
        {
            var teachers = _context.Teachers
                .Where(t => t.BirthDate.AddYears(request.AgeFrom ?? -1000) < DateTime.UtcNow)
                .Where(t => t.BirthDate.AddYears(request.AgeTo ?? 1000) > DateTime.UtcNow)
                .Where(t => (request.BirthYearFrom ?? DateTime.MinValue.Year) <= t.BirthDate.Year)
                .Where(t => (request.BirthYearTo ?? DateTime.MaxValue.Year) >= t.BirthDate.Year)
                .Where(t => (request.GenderId ?? t.GenderId) == t.GenderId)
                .Where(t => (request.SalaryAmountFrom ?? t.Salary) <= t.Salary)
                .Where(t => (request.SalaryAmountTo ?? t.Salary) >= t.Salary)
                .Where(t => (request.ChildrenAmountFrom ?? t.ChildrenAmount) <= t.ChildrenAmount)
                .Where(t => (request.ChildrenAmountTo ?? t.ChildrenAmount) >= t.ChildrenAmount)
                .Where(t => (request.HasChildren ?? (t.ChildrenAmount != 0)) == (t.ChildrenAmount != 0))
                .Where(t => (request.isGraduateStudent ?? t.GraduateStudent) == t.GraduateStudent)
                .Where(t => (request.ChairIds ?? new List<int>{t.ChairId}).Contains(t.ChairId))
                .Where(t => t.Dissertations.Count == 0 
                    ? request.DissertationTypeIds == null
                      && request.DateDissertationPresentedFrom == null
                      && request.DateDissertationPresentedTo == null
                    : (t.Dissertations.Exists(
                    d => (request.DissertationTypeIds ?? new List<int>{d.DissertationTypeId}).Contains(d.DissertationTypeId) && 
                         d.DatePresented >= (request.DateDissertationPresentedFrom ?? DateTime.MinValue) && 
                         d.DatePresented <= (request.DateDissertationPresentedTo ?? DateTime.MaxValue))))
                .Where(t => ((request.TeacherCategoryIds ?? new List<int>{t.TeacherCategoryId}).Contains(t.TeacherCategoryId)));

            return await teachers.ToListAsync();
        }

        /// <summary>
        /// Search teachers conducting lessons with specific parameters
        /// </summary>
        /// <param name="request">Request to get teachers</param>
        /// <returns>List of teachers matching the query</returns>
        [HttpGet("lessons-conducted")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<GetTeachersConductingLessonsResponse>> GetTeachersConductingLessons(
            [FromQuery] GetTeachersConductingLessonsRequest request)
        {
            var teachers = _context.Teachers
                .Where(t => t.Lessons
                    .Exists(l =>
                        (request.DisciplineId ?? l.Curriculum.DisciplineFinal.DisciplineId) == l.Curriculum.DisciplineFinal.DisciplineId &&
                        (request.FacultyId ?? l.Group.FacultyId) == l.Group.FacultyId &&
                        (request.GroupId ?? l.GroupId) == l.GroupId &&
                        (request.Year ?? (DateTime.UtcNow - l.Group.StartDate).Days / 365 + 1) == (DateTime.UtcNow - l.Group.StartDate).Days / 365 + 1 &&
                        (request.LessonTypeIds ?? new List<int> {l.Curriculum.LessonTypeId}).Contains(l.Curriculum.LessonTypeId) &&
                        (request.Semesters ?? new List<int> {l.Curriculum.DisciplineFinal.Discipline.Semester}).Contains(l.Curriculum.DisciplineFinal.Discipline.Semester)));

            return new GetTeachersConductingLessonsResponse
            {
                Teachers = await teachers.ToListAsync(),
                TotalElements = await teachers.CountAsync()
            };
        }

        [HttpGet("by-finals")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersByFinals([FromQuery] GetTeachersByFinalsRequest request)
        {
            var finalTeachers = _context.FinalTeachers
                .Where(ft => (request.GroupIds ?? new List<int> {ft.GroupId}).Contains(ft.GroupId))
                .Where(ft =>
                    (request.DisciplineIds ?? new List<int> {ft.Final.DisciplineId}).Contains(ft.Final.DisciplineId))
                .Where(ft =>
                    (request.Semesters ?? new List<int> {ft.Final.Discipline.Semester}).Contains(ft.Final.Discipline
                        .Semester));

            var teachers = _context.Teachers
                .Where(t => finalTeachers.Any(ft => ft.TeacherId == t.Id));

            return await teachers.ToListAsync();
        }

        [HttpGet("thesis-teachers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetThesisTeachers(
            [FromQuery] GetThesisTeachersRequest request)
        {
            var theses = _context.Theses
                .Where(t => t.Teacher.ChairId == (request.ChairId ?? t.Teacher.ChairId))
                .Where(t => t.Teacher.Chair.FacultyId == (request.FacultyId ?? t.Teacher.Chair.FacultyId))
                .Where(t =>
                    (request.TeacherCategoryIds ?? new List<int> {t.Teacher.TeacherCategoryId}).Contains(
                        t.Teacher.TeacherCategoryId));

            
            var teachers = new List<Teacher>();
            var thesesList = theses.ToList();
            foreach (var thesis in thesesList)
            {
                if (!teachers.Exists(t => t.Id == thesis.TeacherId))
                {
                    teachers.Add(_context.Teachers.Find(thesis.TeacherId));
                }
            }

            return teachers;
        }

        [HttpGet("hours")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<TeacherHours>>> GetTeacherHours([FromQuery] GetTeacherHoursRequest request)
        {
            var lessons = _context.Lessons
                .Where(l => l.TeacherId == (request.TeacherId ?? l.TeacherId))
                .Where(l => l.Teacher.ChairId == (request.ChairId ?? l.Teacher.ChairId))
                .Where(l => l.Curriculum.DisciplineFinal.Discipline.Semester ==
                            (request.Semester ?? l.Curriculum.DisciplineFinal.Discipline.Semester));

            var teacherHoursList = new List<TeacherHours>();
            foreach (var lesson in lessons)
            {
                var teacher = await _context.Teachers.FindAsync(lesson.TeacherId);
                if (!teacherHoursList.Exists(d => d.TeacherId == teacher.Id))
                {
                    teacherHoursList.Add(new TeacherHours
                    {
                        TeacherId = teacher.Id, 
                        TeacherName = $"{teacher.SecondName} {teacher.FirstName} {teacher.MiddleName}", 
                        DisciplineHours = new List<DisciplineHours>(),
                        Hours = lessons.Where(l => l.TeacherId == teacher.Id).Sum(x => x.Curriculum.HoursAmount * x.Curriculum.Lessons.Where(z => z.TeacherId == teacher.Id).Sum(y => 1))
                    });
                }
            }

            foreach (var teacherHours in teacherHoursList)
            {
                var teacherLessons = lessons.Where(l => l.TeacherId == teacherHours.TeacherId);
                foreach (var lesson in teacherLessons)
                {
                    var curriculum = _context.Curricula.Find(lesson.CurriculumId);
                    var final = _context.DisciplineFinals.Find(curriculum.DisciplineFinalId);
                    var disciplineId = final.DisciplineId;
                    
                    if (!teacherHours.DisciplineHours.Exists(x =>
                        x.DisciplineId == disciplineId))
                    {        
                        var disciplineLessons = teacherLessons
                            .Where(l => l.Curriculum.DisciplineFinal.DisciplineId == disciplineId);
                        teacherHours.DisciplineHours.Add(new DisciplineHours
                        {
                            DisciplineId = disciplineId,
                            DisciplineName = _context.AcademicDisciplines
                                .Find(disciplineId).Name,
                            LessonTypeHours = new List<LessonTypeHours>(),
                            Hours = disciplineLessons.Sum(x => x.Curriculum.HoursAmount * x.Curriculum.Lessons.Where(z => z.TeacherId == teacherHours.TeacherId).Sum(y => 1))
                        });
                    }
                }

                foreach (var disciplineHours in teacherHours.DisciplineHours)
                {
                    var disciplineLessons = teacherLessons.Where(l =>
                        l.Curriculum.DisciplineFinal.DisciplineId == disciplineHours.DisciplineId);

                    foreach (var lesson in disciplineLessons)
                    {
                        var curriculum = _context.Curricula.Find(lesson.CurriculumId);
                        var final = _context.DisciplineFinals.Find(curriculum.DisciplineFinalId);
                        var disciplineId = final.DisciplineId;
                        if (!disciplineHours.LessonTypeHours.Exists(x =>
                            x.LessonTypeId == curriculum.LessonTypeId))
                        {
                            var lessonTypeLessons = disciplineLessons
                                .Where(l => l.Curriculum.LessonTypeId == lesson.Curriculum.LessonTypeId);
                            disciplineHours.LessonTypeHours.Add(new LessonTypeHours
                            {
                                LessonTypeId = curriculum.LessonTypeId,
                                LessonTypeName = _context.LessonTypes.Find(lesson.Curriculum.LessonTypeId)
                                    .Name,
                                Hours = lessonTypeLessons.Sum(x => x.Curriculum.HoursAmount * x.Curriculum.Lessons.Where(z => z.TeacherId == teacherHours.TeacherId).Sum(y => 1))
                            });
                        }
                    }
                }
            }

            return teacherHoursList;
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> Get(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Teacher>> Post([FromBody] PostPutTeacherRequest teacher)
        {
            if (await _context.Faculties.FindAsync(teacher.ChairId) == null)
            {
                ModelState.AddModelError("ChairId", "Nonexistent ChairId");
            }

            if (await _context.Genders.FindAsync(teacher.GenderId) == null)
            {
                ModelState.AddModelError("GenderId", "Nonexistent GenderId");
            }
            
            if (await _context.Groups.FindAsync(teacher.TeacherCategoryId) == null)
            {
                ModelState.AddModelError("TeacherCategoryId", "TeacherCategoryId GroupId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeacher = await _context.Teachers.AddAsync(teacher.ToTeacher());
            await _context.SaveChangesAsync();
            return Created($"api/teacher/{newTeacher.Entity.Id}", newTeacher.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> Put(int id, [FromBody] PostPutTeacherRequest request)
        {
            if (await _context.Faculties.FindAsync(request.ChairId) == null)
            {
                ModelState.AddModelError("ChairId", "Nonexistent ChairId");
            }

            if (await _context.Genders.FindAsync(request.GenderId) == null)
            {
                ModelState.AddModelError("GenderId", "Nonexistent GenderId");
            }
            
            if (await _context.Groups.FindAsync(request.TeacherCategoryId) == null)
            {
                ModelState.AddModelError("TeacherCategoryId", "TeacherCategoryId GroupId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.Teachers.Update(teacher);
            teacher.FirstName = request.FirstName;
            teacher.SecondName = request.SecondName;
            teacher.MiddleName = request.MiddleName;
            teacher.BirthDate = request.BirthDate;
            teacher.ChildrenAmount = request.ChildrenAmount;
            teacher.GraduateStudent = request.GraduateStudent;
            teacher.ChairId = request.ChairId;
            teacher.TeacherCategoryId = request.TeacherCategoryId;
            teacher.GenderId = request.GenderId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}