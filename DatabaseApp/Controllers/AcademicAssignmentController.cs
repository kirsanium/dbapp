using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Dtos.AcademicAssignment;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/academic-assignment")]
    [Produces("application/json")]
    [ApiController]
    public class AcademicAssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AcademicAssignmentController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicAssignment>>> GetAll()
        {
            return Ok(await _context.AcademicAssignments.ToListAsync());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicAssignment>> Get(int id)
        {
            var assignment = await _context.AcademicAssignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<AcademicAssignment>> Post([FromBody] PostPutAcademicAssignmentRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAssignment = await _context.AcademicAssignments.AddAsync(request.ToAcademicAssignment());
            await _context.SaveChangesAsync();
            return Created($"api/academic-assignment/{newAssignment.Entity.Id}", newAssignment.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<AcademicAssignment>> Put(int id, [FromBody] PostPutAcademicAssignmentRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var assignment = await _context.AcademicAssignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            _context.AcademicAssignments.Update(assignment);
            assignment.ChairId = request.ChairId;
            assignment.DateFrom = request.DateFrom;
            assignment.DateTo = request.DateTo;
            assignment.GroupId = request.GroupId;
            assignment.DisciplineId = request.DisciplineId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var assignment = await _context.AcademicAssignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            _context.AcademicAssignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutAcademicAssignmentRequest request)
        {
            if (await _context.Chairs.FindAsync(request.ChairId) == null)
            {
                ModelState.AddModelError("ChairId", "Nonexistent ChairId");
            }

            if (await _context.Groups.FindAsync(request.GroupId) == null)
            {
                ModelState.AddModelError("GroupId", "Nonexistent GroupId");
            }
            
            if (await _context.AcademicDisciplines.FindAsync(request.DisciplineId) == null)
            {
                ModelState.AddModelError("DisciplineId", "Nonexistent DisciplineId");
            }
        }
    }
}