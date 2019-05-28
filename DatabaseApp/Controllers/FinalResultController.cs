using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.FinalResult;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/final-result")]
    [Produces("application/json")]
    [ApiController]
    public class FinalResultController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinalResultController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinalResult>>> GetAll()
        {
            return Ok(await _context.FinalResults.ToListAsync());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FinalResult>> Get(int id)
        {
            var result = await _context.FinalResults.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<FinalResult>> Post([FromBody] PostPutFinalResultRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDiscipline = await _context.FinalResults.AddAsync(request.ToFinalResult());
            await _context.SaveChangesAsync();
            return Created($"api/final-result/{newDiscipline.Entity.Id}", newDiscipline.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<FinalResult>> Put(int id, [FromBody] PostPutFinalResultRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _context.FinalResults.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _context.FinalResults.Update(result);
            result.StudentId = request.StudentId;
            result.DisciplineFinalId = request.DisciplineFinalId;
            result.Grade = request.Grade;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _context.FinalResults.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _context.FinalResults.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutFinalResultRequest request)
        {
            if (await _context.Students.FindAsync(request.StudentId) == null)
            {
                ModelState.AddModelError("StudentId", "Nonexistent StudentId");
            }
            
            if (await _context.DisciplineFinals.FindAsync(request.DisciplineFinalId) == null)
            {
                ModelState.AddModelError("DisciplineFinalId", "Nonexistent DisciplineFinalId");
            }
        }
    }
}