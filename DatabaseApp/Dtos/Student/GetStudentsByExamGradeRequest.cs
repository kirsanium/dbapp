using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Dtos
{
    public sealed class GetStudentsByExamGradeRequest
    {
        [Required]
        public int DisciplineId { get; set; }
        public List<int> GroupIds { get; set; }
        public string Grade { get; set; }
    }
}