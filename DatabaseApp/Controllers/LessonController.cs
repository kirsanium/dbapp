using System.Threading.Tasks;
using DatabaseApp.Dtos.Lesson;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/lesson")]
    [Produces("application/json")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LessonController(AppDbContext context)
        {
            _context = context;
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> Get(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Lesson>> Post([FromBody] PostPutLessonRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lesson = await _context.Lessons.AddAsync(request.ToLesson());
            await _context.SaveChangesAsync();
            return Created($"api/lesson/{lesson.Entity.Id}", lesson.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Lesson>> Put(int id, [FromBody] PostPutLessonRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Update(lesson);
            lesson.GroupId = request.GroupId;
            lesson.CurriculumId = request.CurriculumId;
            lesson.TeacherId = request.TeacherId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutLessonRequest request)
        {
            if (await _context.Groups.FindAsync(request.GroupId) == null)
            {
                ModelState.AddModelError("GroupId", "Nonexistent GroupId");
            }
            
            if (await _context.Curricula.FindAsync(request.CurriculumId) == null)
            {
                ModelState.AddModelError("CurriculumId", "Nonexistent CurriculumId");
            }
            
            if (await _context.Teachers.FindAsync(request.TeacherId) == null)
            {
                ModelState.AddModelError("TeacherId", "Nonexistent TeacherId");
            }
        }
    }
}