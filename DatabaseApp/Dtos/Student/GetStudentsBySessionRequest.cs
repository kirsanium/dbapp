using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Dtos
{
    public sealed class GetStudentsBySessionRequest
    {
        [Required]
        public int Semester { get; set; }
        public List<int> GroupIds { get; set; }
        public int? FacultyId { get; set; }
        public int? Year { get; set; }
        public List<string> Grades { get; set; }
    }
}