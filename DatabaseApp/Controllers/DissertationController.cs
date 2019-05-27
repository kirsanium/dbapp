using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/dissertation")]
    [Produces("application/json")]
    [ApiController]
    public class DissertationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DissertationController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search dissertation themes with specific parameters
        /// </summary>
        /// <param name="request">Request to get dissertation themes</param>
        /// <returns>List of dissertation themes matching the query</returns>
        [ProducesResponseType(200)]
        [HttpGet("themes")]
        public ActionResult<GetDissertationThemesResult> GetThemes([FromQuery] GetDissertationThemesRequest request)
        {
            var dissertations = _context.Dissertations
                .Where(d => (request.DissertationTypeIds ?? new List<int>{d.DissertationTypeId}).Contains(d.DissertationTypeId))
                .Where(d => (request.ChairId ?? d.Teacher.ChairId) == d.Teacher.ChairId)
                .Where(d => (request.FacultyId ?? d.Teacher.Chair.FacultyId) == d.Teacher.Chair.FacultyId);

            var themes = new List<string>();
            foreach (var dissertation in dissertations)
            {
                themes.Add(dissertation.Theme);
            }
            
            return new GetDissertationThemesResult
            {
                Themes = themes, 
                TotalElements = themes.Count
            };
        }
        
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Dissertation>> Get(int id)
        {
            var dissertation = await _context.Dissertations.FindAsync(id);
            if (dissertation == null)
            {
                return NotFound();
            }

            return Ok(dissertation);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<Dissertation>> Post([FromBody] PostPutDissertationRequest dissertation)
        {
            if (await _context.DissertationTypes.FindAsync(dissertation.DissertationTypeId) == null)
            {
                ModelState.AddModelError("DissertationTypeId", "Nonexistent DissertationTypeId");
            }

            if (await _context.Teachers.FindAsync(dissertation.TeacherId) == null)
            {
                ModelState.AddModelError("TeacherId", "Nonexistent TeacherId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDissertation = await _context.Dissertations.AddAsync(dissertation.ToDissertation());
            await _context.SaveChangesAsync();
            return Created($"api/dissertation/{newDissertation.Entity.Id}", newDissertation.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Dissertation>> Put(int id, [FromBody] PostPutDissertationRequest request)
        {
            if (await _context.DissertationTypes.FindAsync(request.DissertationTypeId) == null)
            {
                ModelState.AddModelError("DissertationTypeId", "Nonexistent DissertationTypeId");
            }

            if (await _context.Teachers.FindAsync(request.TeacherId) == null)
            {
                ModelState.AddModelError("TeacherId", "Nonexistent TeacherId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var dissertation = await _context.Dissertations.FindAsync(id);
            if (dissertation == null)
            {
                return NotFound();
            }
            _context.Dissertations.Update(dissertation);
            dissertation.TeacherId = request.TeacherId;
            dissertation.DatePresented = request.DatePresented;
            dissertation.DissertationTypeId = request.DissertationTypeId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dissertation = await _context.Dissertations.FindAsync(id);
            if (dissertation == null)
            {
                return NotFound();
            }
            _context.Dissertations.Remove(dissertation);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}