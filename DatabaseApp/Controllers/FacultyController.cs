using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseApp.Dtos.Faculty;
using DatabaseApp.Dtos.Group;
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

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetAll()
        {
            return Ok(await _context.Faculties.ToListAsync());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Faculty>> Get(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Faculty>> Post([FromBody] PostPutFacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faculty = await _context.Faculties.AddAsync(request.ToFaculty());
            await _context.SaveChangesAsync();
            return Created($"api/faculty/{faculty.Entity.Id}", faculty.Entity);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Faculty>> Put(int id, [FromBody] PostPutFacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            _context.Faculties.Update(faculty);
            faculty.Name = request.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}