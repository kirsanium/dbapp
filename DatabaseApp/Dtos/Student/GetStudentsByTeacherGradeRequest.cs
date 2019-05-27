using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetStudentsByTeacherGradeRequest
    {
        public List<int> GroupIds { get; set; }
        public int? TeacherId { get; set; }
        public string Grade { get; set; }
        public List<int> DisciplineIds { get; set; }
        public List<int> Semesters { get; set; }
        
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}