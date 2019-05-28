using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseApp.Dtos.TeacherCategory;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{
    [Route("api/teacher-category")]
    [Produces("application/json")]
    [ApiController]
    public class TeacherCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherCategoryController(AppDbContext context)
        {
            _context = context;
        }
        
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherCategory>>> GetAll()
        {
            return Ok(await _context.TeacherCategories.ToListAsync());
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherCategory>> Get(int id)
        {
            var category = await _context.TeacherCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<ActionResult<TeacherCategory>> Post([FromBody] PostPutTeacherCategoryRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.TeacherCategories.AddAsync(request.ToTeacherCategory());
            await _context.SaveChangesAsync();
            return Created($"api/teacher-category/{category.Entity.Id}", category.Entity);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherCategory>> Put(int id, [FromBody] PostPutTeacherCategoryRequest request)
        {
            await CheckIdsExistence(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.TeacherCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.TeacherCategories.Update(category);
            category.Name = request.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _context.TeacherCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.TeacherCategories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private async Task CheckIdsExistence(PostPutTeacherCategoryRequest request)
        {
        }
    }
}