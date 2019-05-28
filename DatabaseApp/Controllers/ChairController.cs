using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Dtos.Chair;
using DatabaseApp.Dtos.Group;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/chair")]
    [Produces("application/json")]
    [ApiController]
    public class ChairController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChairController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search chairs with specific parameters
        /// </summary>
        /// <param name="request">Request to get chairs</param>
        /// <returns>List of chairs matching the query</returns>
        [ProducesResponseType(200)]
        [HttpGet("lesson-conduction")]
        public async Task<ActionResult<IEnumerable<Chair>>> GetChairsConductingLessons([FromQuery] GetChairsLessonsRequest request)
        {
            var chairs = _context.Chairs
                .Where(c => (request.FacultyId ?? c.FacultyId) == c.FacultyId)
                .Where(c => c.AcademicAssignments
                    .Exists(aa =>
                        (request.GroupId ?? aa.GroupId) == aa.GroupId &&
                        (request.Years ?? new List<int> {(aa.Discipline.Semester - 1) / 2 + 1}).Contains((aa.Discipline.Semester - 1) / 2 + 1) &&
                        (request.Semesters ?? new List<int> {aa.Discipline.Semester}).Contains(aa.Discipline.Semester) &&
                        (request.DateFrom ?? DateTime.MinValue) <= aa.DateTo &&
                        (request.DateTo ?? DateTime.MaxValue) >= aa.DateFrom));

            return await chairs.ToListAsync();
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Chair>> Get(int id)
        {
            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }

            return Ok(chair);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Chair>> Post([FromBody] PostPutChairRequest request)
        {
            if (await _context.Faculties.FindAsync(request.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chair = await _context.Chairs.AddAsync(request.ToChair());
            await _context.SaveChangesAsync();
            return Created($"api/chair/{chair.Entity.Id}", chair.Entity);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Chair>> Put(int id, [FromBody] PostPutChairRequest request)
        {
            if (await _context.Faculties.FindAsync(request.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            _context.Chairs.Update(chair);
            chair.Name = request.Name;
            chair.FacultyId = request.FacultyId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            _context.Chairs.Remove(chair);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}