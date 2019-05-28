using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.FinalType;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/final-type")]
    [Produces("application/json")]
    [ApiController]
    public class FinalTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinalTypeController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinalType>>> GetAll()
        {
            return Ok(await _context.FinalTypes.ToListAsync());
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FinalType>> Get(int id)
        {
            var type = await _context.FinalTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<FinalType>> Post([FromBody] PostPutFinalTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDiscipline = await _context.FinalTypes.AddAsync(request.ToFinalType());
            await _context.SaveChangesAsync();
            return Created($"api/final-type/{newDiscipline.Entity.Id}", newDiscipline.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<FinalType>> Put(int id, [FromBody] PostPutFinalTypeRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var type = await _context.FinalTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            _context.FinalTypes.Update(type);
            type.Name = request.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var type = await _context.FinalTypes.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            _context.FinalTypes.Remove(type);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutFinalTypeRequest request)
        {
        }
    }
}