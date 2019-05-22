using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatabaseApp.Dtos;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Controllers
{   
    [Route("api/teacher")]
    [Produces("application/json")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const double TOLERANCE = 0.001;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Search teachers with specific parameters
        /// </summary>
        /// <param name="request">Request to get teachers</param>
        /// <returns>List of teachers matching the query</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Teacher>> GetTeachers([FromQuery] GetTeachersRequest request)
        {
            var teachers = _context.Teachers
                .Where(t => t.BirthDate.AddYears(request.Age ?? DateTime.MinValue.Year) < DateTime.UtcNow)
                .Where(t => (request.BirthYear ?? DateTime.MinValue.Year) <= t.BirthDate.Year)
                .Where(t => (request.GenderId ?? t.GenderId) == t.GenderId)
                .Where(t => (request.SalaryAmount ?? t.Salary) >= t.Salary)
                .Where(t => (request.ChildrenAmount ?? t.ChildrenAmount) == t.ChildrenAmount)
                .Where(t => (request.HasChildren ?? (t.ChildrenAmount != 0)) == (t.ChildrenAmount != 0))
                .Where(t => (request.isGraduateStudent ?? t.GraduateStudent) == t.GraduateStudent);

            if (request.ChairIds != null)
            { 
                foreach (var chairId in request.ChairIds)
                {
                    teachers = teachers.Where(t => _context.Chairs.First(c => c.Id == chairId) != null);
                }
            }

            IQueryable<Teacher> dissertationQueryResult = new EnumerableQuery<Teacher>(new List<Teacher>());
            var dissertationQueryResultList = new List<IQueryable<Teacher>>();
            if (request.DissertationTypeIds != null)
            {
                foreach (var dissertationType in request.DissertationTypeIds)
                {
                    dissertationQueryResultList.Add(teachers.Where(t => t.Dissertations.Exists(
                        d => dissertationType == d.DissertationTypeId &&
                             (request.DateDissertationPresentedFrom ?? DateTime.MinValue) < d.DatePresented &&
                             (request.DateDissertationPresentedTo ?? DateTime.MaxValue) > d.DatePresented)));
                }
                
                switch (dissertationQueryResultList.Count)
                {
                    case 0:
                        break;
                
                    case 1:
                        dissertationQueryResult = dissertationQueryResultList[0];
                        break;
                
                    default:
                        dissertationQueryResult = dissertationQueryResultList[0].Union(dissertationQueryResultList[1]);
                        for (var i = 2; i < dissertationQueryResultList.Count; ++i)
                        {
                            dissertationQueryResult = dissertationQueryResult.Union(dissertationQueryResultList[i]);
                        }
                        break;
                }
            }

            IQueryable<Teacher> categoryQueryResult = new EnumerableQuery<Teacher>(new List<Teacher>());
            var categoryQueryResultList = new List<IQueryable<Teacher>>();
            if (request.TeacherCategoryIds != null)
            {
                foreach (var categoryId in request.TeacherCategoryIds)
                {
                    categoryQueryResultList.Add(teachers.Where(t => t.TeacherCategoryId == categoryId));
                }
                
                switch (categoryQueryResultList.Count)
                {
                    case 0:
                        break;
                
                    case 1:
                        categoryQueryResult = categoryQueryResultList[0];
                        break;
                    
                    default:
                        categoryQueryResult = categoryQueryResultList[0].Union(categoryQueryResultList[1]);
                        for (var i = 2; i < categoryQueryResultList.Count; ++i)
                        {
                            categoryQueryResult = categoryQueryResult.Union(categoryQueryResultList[i]);
                        }
                        break;
                }
            }
            
            var result = teachers;

            if (request.DissertationTypeIds != null || request.TeacherCategoryIds != null)
            {
                result = dissertationQueryResult.Union(categoryQueryResult);
            }

            return result.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}