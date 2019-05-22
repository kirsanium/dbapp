using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public sealed class GetTeachersRequest
    {
        public int? Year { get; set; }
        public List<int> ChairIds { get; set; }
        public int? GenderId { get; set; }
        public int? BirthYear{ get; set; }
        public int? Age { get; set; }
        public bool? HasChildren { get; set; }
        public int? ChildrenAmount { get; set; }
        public float? SalaryAmount { get; set; }
        
        public bool? isGraduateStudent { get; set; }
        
        public List<int> DissertationTypeIds { get; set; }
        
        public List<int> TeacherCategoryIds { get; set; }
        
        public DateTime? DateDissertationPresentedFrom { get; set; }
        
        public DateTime? DateDissertationPresentedTo { get; set; }
    }
}