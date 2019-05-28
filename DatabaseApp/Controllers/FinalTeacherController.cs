using System.Threading.Tasks;
using DatabaseApp.Dtos.FinalTeacher;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/final-teacher")]
    [Produces("application/json")]
    [ApiController]
    public class FinalTeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinalTeacherController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FinalTeacher>> Get(int id)
        {
            var teacher = await _context.FinalTeachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<FinalTeacher>> Post([FromBody] PostPutFinalTeacherRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDiscipline = await _context.FinalTeachers.AddAsync(request.ToFinalTeacher());
            await _context.SaveChangesAsync();
            return Created($"api/final-teacher/{newDiscipline.Entity.Id}", newDiscipline.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<FinalTeacher>> Put(int id, [FromBody] PostPutFinalTeacherRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var teacher = await _context.FinalTeachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.FinalTeachers.Update(teacher);
            teacher.FinalId = request.FinalId;
            teacher.TeacherId = request.TeacherId;
            teacher.GroupId = request.GroupId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await _context.FinalTeachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.FinalTeachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutFinalTeacherRequest request)
        {
            if (await _context.DisciplineFinals.FindAsync(request.FinalId) == null)
            {
                ModelState.AddModelError("FinalId", "Nonexistent FinalId");
            }
            
            if (await _context.Teachers.FindAsync(request.TeacherId) == null)
            {
                ModelState.AddModelError("TeacherId", "Nonexistent TeacherId");
            }
            
            if (await _context.Groups.FindAsync(request.GroupId) == null)
            {
                ModelState.AddModelError("GroupId", "Nonexistent GroupId");
            }
        }
    }
}