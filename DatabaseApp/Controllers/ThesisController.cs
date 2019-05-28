using System.Threading.Tasks;
using DatabaseApp.Dtos.Thesis;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/lesson")]
    [Produces("application/json")]
    [ApiController]
    public class ThesisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ThesisController(AppDbContext context)
        {
            _context = context;
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Thesis>> Get(int id)
        {
            var lesson = await _context.Theses.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
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

            var lesson = await _context.Theses.AddAsync(request.ToThesis());
            await _context.SaveChangesAsync();
            return Created($"api/lesson/{lesson.Entity.Id}", lesson.Entity);
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

            var lesson = await _context.Theses.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Theses.Update(lesson);
            lesson.Title = request.Title;
            lesson.StudentId = request.StudentId;
            lesson.TeacherId = request.TeacherId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var lesson = await _context.Theses.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Theses.Remove(lesson);
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