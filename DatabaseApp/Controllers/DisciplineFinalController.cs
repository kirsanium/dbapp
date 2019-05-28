using System.Threading.Tasks;
using DatabaseApp.Dtos.DisciplineFinal;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/discipline-final")]
    [Produces("application/json")]
    [ApiController]
    public class DisciplineFinalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplineFinalController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineFinal>> Get(int id)
        {
            var final = await _context.DisciplineFinals.FindAsync(id);
            if (final == null)
            {
                return NotFound();
            }

            return Ok(final);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<DisciplineFinal>> Post([FromBody] PostPutDisciplineFinalRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDiscipline = await _context.DisciplineFinals.AddAsync(request.ToDisciplineFinal());
            await _context.SaveChangesAsync();
            return Created($"api/discipline-final/{newDiscipline.Entity.Id}", newDiscipline.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<DisciplineFinal>> Put(int id, [FromBody] PostPutDisciplineFinalRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var final = await _context.DisciplineFinals.FindAsync(id);
            if (final == null)
            {
                return NotFound();
            }
            _context.DisciplineFinals.Update(final);
            final.DisciplineId = request.DisciplineId;
            final.FinalTypeId = request.FinalTypeId;
            final.Date = request.Date;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var final = await _context.DisciplineFinals.FindAsync(id);
            if (final == null)
            {
                return NotFound();
            }
            _context.DisciplineFinals.Remove(final);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutDisciplineFinalRequest request)
        {
            if (await _context.AcademicDisciplines.FindAsync(request.DisciplineId) == null)
            {
                ModelState.AddModelError("DisciplineId", "Nonexistent DisciplineId");
            }
            
            if (await _context.FinalTypes.FindAsync(request.FinalTypeId) == null)
            {
                ModelState.AddModelError("FinalTypeId", "Nonexistent FinalTypeId");
            }
        }
    }
}