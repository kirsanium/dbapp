using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.DissertationType;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/dissertation-type")]
    [Produces("application/json")]
    [ApiController]
    public class DissertationTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DissertationTypeController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DissertationType>>> GetAll()
        {
            return Ok(await _context.DissertationTypes.ToListAsync());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DissertationType>> Get(int id)
        {
            var type = await _context.DissertationTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<DissertationType>> Post([FromBody] PostPutDissertationTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newType = await _context.DissertationTypes.AddAsync(request.ToDissertationType());
            await _context.SaveChangesAsync();
            return Created($"api/dissertation-type/{newType.Entity.Id}", newType.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<DissertationType>> Put(int id, [FromBody] PostPutDissertationTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var type = await _context.DissertationTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            _context.DissertationTypes.Update(type);
            type.Name = request.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var type = await _context.DissertationTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            _context.DissertationTypes.Remove(type);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutDissertationTypeRequest request)
        {
        }
    }
}