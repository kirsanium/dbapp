using System.Threading.Tasks;
using DatabaseApp.Dtos.Curriculum;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/academic-curriculum")]
    [Produces("application/json")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurriculumController(AppDbContext context)
        {
            _context = context;
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculum>> Get(int id)
        {
            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return Ok(curriculum);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Curriculum>> Post([FromBody] PostPutCurriculumRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCurriculum = await _context.Curricula.AddAsync(request.ToCurriculum());
            await _context.SaveChangesAsync();
            return Created($"api/curriculum/{newCurriculum.Entity.Id}", newCurriculum.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Curriculum>> Put(int id, [FromBody] PostPutCurriculumRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            _context.Curricula.Update(curriculum);
            curriculum.HoursAmount = request.HoursAmount;
            curriculum.DisciplineFinalId = request.DisciplineFinalId;
            curriculum.LessonTypeId = request.LessonTypeId;
            curriculum.DateFrom = request.DateFrom;
            curriculum.DateTo = request.DateTo;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            _context.Curricula.Remove(curriculum);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutCurriculumRequest request)
        {
            if (await _context.DisciplineFinals.FindAsync(request.DisciplineFinalId) == null)
            {
                ModelState.AddModelError("DisciplineFinalId", "Nonexistent DisciplineFinalId");
            }

            if (await _context.LessonTypes.FindAsync(request.LessonTypeId) == null)
            {
                ModelState.AddModelError("LessonTypeId", "Nonexistent LessonTypeId");
            }
        }
    }
}