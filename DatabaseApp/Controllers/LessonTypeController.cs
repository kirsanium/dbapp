using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.LessonType;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/lesson-type")]
    [Produces("application/json")]
    [ApiController]
    public class LessonTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LessonTypeController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonType>>> GetAll()
        {
            return Ok(await _context.LessonTypes.ToListAsync());
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonType>> Get(int id)
        {
            var type = await _context.LessonTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<LessonType>> Post([FromBody] PostPutLessonTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var type = await _context.LessonTypes.AddAsync(request.ToLessonType());
            await _context.SaveChangesAsync();
            return Created($"api/lesson-type/{type.Entity.Id}", type.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<LessonType>> Put(int id, [FromBody] PostPutLessonTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var type = await _context.LessonTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            _context.LessonTypes.Update(type);
            type.Name = request.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var type = await _context.LessonTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            _context.LessonTypes.Remove(type);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutLessonTypeRequest request)
        {
        }
    }
}