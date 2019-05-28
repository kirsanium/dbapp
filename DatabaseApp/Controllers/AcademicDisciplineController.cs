using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Dtos.AcademicDiscipline;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/academic-discipline")]
    [Produces("application/json")]
    [ApiController]
    public class AcademicDisciplineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AcademicDisciplineController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicDiscipline>> Get(int id)
        {
            var discipline = await _context.AcademicDisciplines.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }

            return Ok(discipline);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<AcademicDiscipline>> Post([FromBody] PostPutAcademicDisciplineRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDiscipline = await _context.AcademicDisciplines.AddAsync(request.ToAcademicDiscipline());
            await _context.SaveChangesAsync();
            return Created($"api/academic-discipline/{newDiscipline.Entity.Id}", newDiscipline.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<AcademicDiscipline>> Put(int id, [FromBody] PostPutAcademicDisciplineRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var discipline = await _context.AcademicDisciplines.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            _context.AcademicDisciplines.Update(discipline);
            discipline.FacultyId = request.FacultyId;
            discipline.Name = request.Name;
            discipline.Semester = request.Semester;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var discipline = await _context.AcademicDisciplines.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            _context.AcademicDisciplines.Remove(discipline);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutAcademicDisciplineRequest request)
        {
            if (await _context.Faculties.FindAsync(request.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }
        }
    }
}