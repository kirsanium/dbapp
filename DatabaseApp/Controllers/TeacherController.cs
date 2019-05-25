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
        private const double TOLERANCE = 0.001;

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
        public ActionResult<IEnumerable<Teacher>> GetTeachers([FromQuery] GetTeachersRequest request)
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
                         d.DatePresented > (request.DateDissertationPresentedFrom ?? DateTime.MinValue) && 
                         d.DatePresented < (request.DateDissertationPresentedTo ?? DateTime.MaxValue))))
                .Where(t => ((request.TeacherCategoryIds ?? new List<int>{t.TeacherCategoryId}).Contains(t.TeacherCategoryId)));

            return teachers.ToList();
        }

        [HttpGet("lessons-conducted")]
        [ProducesResponseType(200)]
        public ActionResult<GetTeachersConductingLessonsResponse> GetTeachersConductingLessons(
            [FromQuery] GetTeachersConductingLessonsRequest request)
        {
            var teachers = _context.Teachers
                .Where(t => t.Lessons.Exists(l => (request.DisciplineId ?? l.Curriculum.DisciplineFinal.DisciplineId) == l.Curriculum.DisciplineFinal.DisciplineId))
                .Where(t => t.Lessons.Exists(l => (request.FacultyId ?? l.Group.FacultyId) == l.Group.FacultyId))
                .Where(t => t.Lessons.Exists(l => (request.GroupId ?? l.GroupId) == l.GroupId))
                .Where(t => t.Lessons.Exists(l => (request.Year ?? (DateTime.UtcNow - l.Group.StartDate).Days / 365 + 1) == (DateTime.UtcNow - l.Group.StartDate).Days / 365 + 1))
                .Where(t => t.Lessons.Exists(l => (request.LessonTypeIds ?? new List<int>{l.Curriculum.LessonTypeId}).Contains(l.Curriculum.LessonTypeId)))
                .Where(t => t.Lessons.Exists(l => (request.Semesters ?? new List<int>{l.Curriculum.DisciplineFinal.Discipline.Semester}).Contains(l.Curriculum.DisciplineFinal.Discipline.Semester)));

            return new GetTeachersConductingLessonsResponse
            {
                Teachers = teachers.ToList(),
                TotalElements = teachers.Count()
            };
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