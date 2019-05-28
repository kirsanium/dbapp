using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.Thesis;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/thesis")]
    [Produces("application/json")]
    [ApiController]
    public class ThesisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ThesisController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thesis>>> GetAll()
        {
            return Ok(await _context.Theses.ToListAsync());
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Thesis>> Get(int id)
        {
            var thesis = await _context.Theses.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }

            return Ok(thesis);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Thesis>> Post([FromBody] PostPutThesisRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thesis = await _context.Theses.AddAsync(request.ToThesis());
            await _context.SaveChangesAsync();
            return Created($"api/thesis/{thesis.Entity.Id}", thesis.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Thesis>> Put(int id, [FromBody] PostPutThesisRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thesis = await _context.Theses.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }

            _context.Theses.Update(thesis);
            thesis.Title = request.Title;
            thesis.StudentId = request.StudentId;
            thesis.TeacherId = request.TeacherId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var thesis = await _context.Theses.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }

            _context.Theses.Remove(thesis);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutThesisRequest request)
        {
            if (await _context.Students.FindAsync(request.StudentId) == null)
            {
                ModelState.AddModelError("StudentId", "Nonexistent StudentId");
            }
            
            if (await _context.Teachers.FindAsync(request.TeacherId) == null)
            {
                ModelState.AddModelError("TeacherId", "Nonexistent TeacherId");
            }
        }
    }
}