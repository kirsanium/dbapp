﻿using System;
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
    [Route("api/student")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const double TOLERANCE = 0.001;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search students with specific parameters
        /// </summary>
        /// <param name="id">Id of the faculty</param>
        /// <param name="request">Request to get students</param>
        /// <returns>List of students matching the query</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Student>> GetStudents([FromQuery] FacultyGetStudentsRequest request)
        {
            var students = _context.Students
                .Where(s => (request.FacultyId ?? s.FacultyId) == s.FacultyId)
                .Where(s => s.BirthDate.AddYears(request.AgeFrom ?? -1000) < DateTime.UtcNow)
                .Where(s => s.BirthDate.AddYears(request.AgeTo ?? 1000) > DateTime.UtcNow)
                .Where(s => (request.BirthYearFrom ?? DateTime.MinValue.Year) <= s.BirthDate.Year)
                .Where(s => (request.BirthYearTo ?? DateTime.MaxValue.Year) >= s.BirthDate.Year)
                .Where(s => (request.GenderId ?? s.GenderId) == s.GenderId)
                .Where(s => (request.ScholarshipAmountFrom ?? s.Scholarship) <=  s.Scholarship)
                .Where(s => (request.ScholarshipAmountTo ?? s.Scholarship) >= s.Scholarship)
                .Where(s => (request.HasScholarship ?? (Math.Abs(s.Scholarship) > TOLERANCE)) == (Math.Abs(s.Scholarship) > TOLERANCE))
                .Where(s => (request.ChildrenAmountFrom ?? s.ChildrenAmount) <= s.ChildrenAmount)
                .Where(s => (request.ChildrenAmountTo ?? s.ChildrenAmount) >= s.ChildrenAmount)
                .Where(s => (request.HasChildren ?? (s.ChildrenAmount != 0)) == (s.ChildrenAmount != 0))
                .Where(s => (request.Years ?? new List<int>{(DateTime.UtcNow - s.Group.StartDate).Days / 365 + 1})
                    .Contains((DateTime.UtcNow - s.Group.StartDate).Days / 365 + 1))
                .Where(s => (request.GroupIds ?? new List<int>{s.GroupId})
                    .Contains(s.GroupId));

            return Ok(students.ToList());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] PostPutStudentRequest student)
        {
            if (await _context.Faculties.FindAsync(student.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }

            if (await _context.Genders.FindAsync(student.GenderId) == null)
            {
                ModelState.AddModelError("GenderId", "Nonexistent GenderId");
            }
            
            if (await _context.Groups.FindAsync(student.GroupId) == null)
            {
                ModelState.AddModelError("GroupId", "Nonexistent GroupId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = await _context.Students.AddAsync(student.ToStudent());
            await _context.SaveChangesAsync();
            return Created($"api/student/{newStudent.Entity.Id}", newStudent.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id, [FromBody] PostPutStudentRequest request)
        {
            if (await _context.Faculties.FindAsync(request.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }

            if (await _context.Genders.FindAsync(request.GenderId) == null)
            {
                ModelState.AddModelError("GenderId", "Nonexistent GenderId");
            }
            
            if (await _context.Groups.FindAsync(request.GroupId) == null)
            {
                ModelState.AddModelError("GroupId", "Nonexistent GroupId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var student = await _context.Students.FindAsync(id);
            _context.Students.Update(student);
            student.FirstName = request.FirstName;
            student.SecondName = request.SecondName;
            student.MiddleName = request.MiddleName;
            student.BirthDate = request.BirthDate;
            student.ChildrenAmount = request.ChildrenAmount;
            student.Scholarship = request.Scholarship;
            student.FacultyId = request.FacultyId;
            student.GroupId = request.GroupId;
            student.GenderId = request.GenderId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}