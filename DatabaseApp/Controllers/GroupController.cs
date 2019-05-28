using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.Group;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/group")]
    [Produces("application/json")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAll()
        {
            return Ok(await _context.Groups.ToListAsync());
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Group>> Post([FromBody] PostPutGroupRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = await _context.Groups.AddAsync(request.ToGroup());
            await _context.SaveChangesAsync();
            return Created($"api/group/{group.Entity.Id}", group.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> Put(int id, [FromBody] PostPutGroupRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Groups.Update(group);
            group.GroupName = request.GroupName;
            group.StartDate = request.StartDate;
            group.EndDate = request.EndDate;
            group.FacultyId = request.FacultyId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutGroupRequest request)
        {
            if (await _context.Faculties.FindAsync(request.FacultyId) == null)
            {
                ModelState.AddModelError("FacultyId", "Nonexistent FacultyId");
            }
        }
    }
}