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
    [Route("api/faculty")]
    [Produces("application/json")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const double TOLERANCE = 0.001;

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search students with specific parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>  
        [HttpGet("{id}/students")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Student>> GetStudents([FromRoute] int id, [FromQuery] FacultyGetStudentsRequest request)
        {
            var students = _context.Students
                .Where(s => s.FacultyId == id)
                .Where(s => s.BirthDate.AddYears(request.Age ?? -1000) < DateTime.UtcNow)
                .Where(s => (request.BirthYear ?? DateTime.MinValue.Year) <= s.BirthDate.Year)
                .Where(s => (request.GenderId ?? s.GenderId) == s.GenderId)
                .Where(s => (request.ScholarshipAmount ?? s.Scholarship) >=  s.Scholarship)
                .Where(s => (request.HasScholarship ?? (Math.Abs(s.Scholarship) > TOLERANCE)) == (Math.Abs(s.Scholarship) > TOLERANCE))
                .Where(s => (request.ChildrenAmount ?? s.ChildrenAmount) == s.ChildrenAmount)
                .Where(s => (request.HasChildren ?? (s.ChildrenAmount != 0)) == (s.ChildrenAmount != 0));

            foreach (var groupId in request.GroupIds)
            {
                students = students.Where(s => _context.Groups.First(g => g.Id == groupId) != null);
            }

            return students.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}